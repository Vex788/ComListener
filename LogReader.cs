using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComListener
{
    public partial class LogReader : Form
    {
        private string myDirectory = Directory.GetCurrentDirectory();
        private string logFile = "locallog.txt";

        public LogReader()
        {
            InitializeComponent();
        }

        private void logReading()
        {
            using (StreamReader sr = new StreamReader(@myDirectory +"\\"+ logFile, System.Text.Encoding.Default))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }
        private void LogReader_Load(object sender, EventArgs e)
        {
            logReading();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

