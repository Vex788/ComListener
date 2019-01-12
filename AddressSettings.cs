using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComListener
{
    public partial class AddressSettings : Form
    {
        public AddressSettings()
        {
            InitializeComponent();
            buttonSet.DialogResult = DialogResult.OK;
        }
        private bool newAddressCheck(string s)
        {
            if (s == "0x")
                return false;
            if (string.IsNullOrEmpty(s))
                return false;
            if (Convert.ToByte(s, 16) >= 0x01 && Convert.ToByte(s, 16) <= 0xFE)
                return true;
            else return false;
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length==4 && newAddressCheck(textBox1.Text))
            {
                Properties.Settings.Default.DeviceId = textBox1.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                Properties.Settings.Default.DeviceId = null;
                Properties.Settings.Default.Save();
                this.Close();
            }
            
        }
    }
}
