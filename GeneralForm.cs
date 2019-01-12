using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ComListener
{
    public partial class GeneralForm : Form
    {
        private SerialPort serialPort;
        private CRC8 crc8 = new CRC8();
        private byte[] buffer;
        private byte[] command;
        private string portName;
        private string myDirectory = Directory.GetCurrentDirectory();
        private string logFile = "locallog.txt";
        byte[] receiverBytes = new byte[5];
        Thread receiverThread;
        bool threadStart = false;

        private void LogOut(string log)
        {
            textBoxCommand.Text += log + Environment.NewLine;
        }

        private void logWriting(string s)
        {
            using (StreamWriter sw = new StreamWriter(@myDirectory + "\\" + logFile, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(System.DateTime.Now.ToString());
                sw.WriteLine(s);
            }
        }
        // returns string with COM port and hex number of device. Args - none;
        private string askForDeviceInfo()
        {
            return string.Format("Port: {0}" + Environment.NewLine + "RS-485 address: {1}", portName, buffer[1].ToString("X"));
        }
        // try in monday ==================================================================
        private string SearchActiveComPort()
        {
            string[] ports = SerialPort.GetPortNames();
            command = crc8.GetCommandWithHash(new byte[] { 0x31, 0xFF, 0x06 });

            for (int i = ports.Length - 1; i != 0; i--)
            {
                ConnectToComPort(ports[i]);
                SendCommand(false);

                Thread.Sleep(25);

                if (buffer != null) { return ports[i]; }

                buffer = null;
            }

            return null;
        }
        // =================================================================================
        private void ConnectToComPort(string portName)
        {
            try
            {
                serialPort = new SerialPort();

                serialPort.PortName = portName;
                serialPort.BaudRate = 19200;          // speed in bods
                serialPort.Parity = Parity.None;      // parity
                serialPort.StopBits = StopBits.One;   // stop bit
                serialPort.DataBits = 8;              // bits
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                portName = serialPort.PortName;
                serialPort.Open();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Message(byte[] hashsumm)
        {
            try
            {
                int checksum = crc8.Calc_CRC_8(hashsumm, hashsumm.Length - 1);
                int checksum1 = Convert.ToInt32(hashsumm[hashsumm.Length - 1]);

                this.Invoke(
                    (MethodInvoker)delegate
                    {
                        if (checksum == checksum1)
                        {
                            labelHashStatus.Text = "Hash-functions are equal.";
                        }
                        else
                        {
                            labelHashStatus.Text = "Hash-functions are not equal :(";
                        }
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SendCommand(bool outData)
        {
            try
            {
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = false;

                serialPort.Write(command, 0, command.Length);      // send command

                serialPort.DtrEnable = false;
                serialPort.RtsEnable = true;

                if (outData)
                {
                    logWriting(string.Format("Command: {0}", BitConverter.ToString(command)));
                    return string.Format("Command: {0}", BitConverter.ToString(command));
                }
                return null;
            }
            catch (InvalidOperationException)
            {
                return "Port is closed";
            }
            catch (Exception ex)
            {
                return string.Format("Error:\n{0}", ex.ToString());
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(20);
            try
            {
                buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, serialPort.BytesToRead);

                if (buffer.Length > 0)
                {
                    receiverBytes = new byte[5];

                    if (command[1] != 0xFF && command[2] == 0x06)
                    {
                        for (int i = 0; i < receiverBytes.Length; i++)
                        {
                            receiverBytes[i] = buffer[i + 3];
                        }
                    }
                    this.Invoke(
                        (MethodInvoker)delegate
                        {
                            LogOut(string.Format("Answer: {0}", BitConverter.ToString(buffer)));
                            logWriting(string.Format("Answer: {0}", BitConverter.ToString(buffer)));
                            textBox5.Text = askForDeviceInfo();
                            textBoxReceiverBytes.Text = BitConverter.ToString(receiverBytes);
                        });

                    Message(buffer);
                }
                if (buffer.Length == 0)
                {
                    this.Invoke(
                        (MethodInvoker)delegate
                        {
                            LogOut(string.Format("Answer: 0x00"));
                        });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public GeneralForm()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                byte x = buffer[1]; // to verify the connection

                if (textBox4.Text.Length == 4)
                {
                    command = crc8.GetCommandWithHash(
                        new byte[]
                        {
                            Convert.ToByte(textBox1.Text, 16),
                            Convert.ToByte(textBox2.Text, 16),
                            Convert.ToByte(textBox3.Text, 16),
                            Convert.ToByte(textBox4.Text, 16)
                        });
                }
                else
                {
                    command = crc8.GetCommandWithHash(
                        new byte[]
                        {
                            Convert.ToByte(textBox1.Text, 16),
                            Convert.ToByte(textBox2.Text, 16),
                            Convert.ToByte(textBox3.Text, 16)
                        });
                }

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (FormatException)
            {
                MessageBox.Show("Example input format: 0x01-0xFE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                if (receiverThread.ThreadState == ThreadState.Running || receiverThread.ThreadState == ThreadState.Suspended)
                {
                    receiverThread.Abort();
                }
            }
            catch (Exception)
            {

            }
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    LogOut("Connected");
                    bConnect.Text = "Disconnect";
                    textBox5.Text = askForDeviceInfo();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Port is busy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                serialPort.Close();
                LogOut("Disconnected");
                bConnect.Text = "Connect";
                textBox5.Text = "No device connected";
            }
        }

        private void textBoxCommand_TextChanged(object sender, EventArgs e)
        {
            textBoxCommand.SelectionStart = textBoxCommand.Text.Length;
            textBoxCommand.ScrollToCaret();
        }

        private void dataReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, 0xFF, 0x06 });

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dBmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x23 });

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dBmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x27 });
                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dBmToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x30 });
                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dBmToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x32 });
                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dBmToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x35 });

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.CurrentId = buffer[1];
                Properties.Settings.Default.Save();

                AddressSettings addressSettings = new AddressSettings();

                if (addressSettings.ShowDialog() == DialogResult.OK)
                {
                    if (Properties.Settings.Default.DeviceId != null)
                    {
                        string deviceId = Properties.Settings.Default.DeviceId;
                        command = crc8.GetCommandWithHash(
                            new byte[]
                            {
                            0x31, buffer[1], 0x03, Convert.ToByte(deviceId, 16)
                            });
                        SendCommand(true);
                    }
                    else
                    {
                        MessageBox.Show("Faulty input, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Example input format: 0x01-0xFE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("buffer == null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();

                //ConnectToComPort(ports[ports.Length - 1]);
                // Delete center if didn't work
                //---------------------------------------------
                string resultSearchConnection = SearchActiveComPort();

                if (string.IsNullOrEmpty(resultSearchConnection)) resultSearchConnection = "Port not found";

                MessageBox.Show(resultSearchConnection);
                //---------------------------------------------
                if (serialPort.IsOpen)
                {
                    LogOut("Connected to " + serialPort.PortName);
                    bConnect.Text = "Disconnect";
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, 0xFF, 0x06 });

                    textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
                }
                else
                {
                    LogOut("Disconnect");
                    bConnect.Text = "Connect";
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Port is busy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogReader logReader = new LogReader();
            logReader.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                command = crc8.GetCommandWithHash(new byte[] { 0x31, 0xFF, 0x06 });

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.CurrentId = buffer[1];
                Properties.Settings.Default.Save();

                AddressSettings addressSettings = new AddressSettings();

                if (addressSettings.ShowDialog() == DialogResult.OK)
                {
                    if (Properties.Settings.Default.DeviceId != null)
                    {
                        string deviceId = Properties.Settings.Default.DeviceId;
                        command = crc8.GetCommandWithHash(
                            new byte[]
                            {
                            0x31, buffer[1], 0x03, Convert.ToByte(deviceId, 16)
                            });
                        SendCommand(true);
                    }
                    else
                    {
                        MessageBox.Show("Faulty input, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Example input format: 0x01-0xFE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("buffer == null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x23 });

                else if (radioButton2.Checked)
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x27 });

                else if (radioButton3.Checked)
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x30 });

                else if (radioButton4.Checked)
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x32 });

                else if (radioButton5.Checked)
                    command = crc8.GetCommandWithHash(new byte[] { 0x31, buffer[1], 0x22, 0x35 });
                else
                {
                    MessageBox.Show("select power level", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                textBoxCommand.Text += SendCommand(true) + Environment.NewLine;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetReceiverBytes()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(1500);

                    command = crc8.GetCommandWithHash(
                        new byte[]
                        {
                            0x31, buffer[1], 0x06
                        });

                    this.Invoke(
                        (MethodInvoker)delegate
                        {
                            textBoxCommand.Text += SendCommand(false) + Environment.NewLine;
                        });
                }
            }
            catch (ThreadAbortException)
            {

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No answer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Example input format: 0x01-0xFE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStatusUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (receiverThread == null)
                {
                    receiverThread = new Thread(GetReceiverBytes);
                    receiverThread.Start();
                }
                else if (receiverThread.ThreadState == ThreadState.Suspended && receiverThread != null)
                {
                    buttonStatusUpdate.Text = "Stop update";
                    threadStart = true;
                    receiverThread.Resume();
                }
                else if (receiverThread.ThreadState == ThreadState.Running && receiverThread != null)
                {
                    buttonStatusUpdate.Text = "Start update";
                    threadStart = false;
                    receiverThread.Suspend();
                }
            }
            catch (ThreadAbortException)
            {
                receiverThread.Join();
            }
        }
    }
}
