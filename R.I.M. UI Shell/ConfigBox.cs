using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R.I.M.UI_Shell
{
    public partial class ConfigBox : Form
    {
        private int COMPort;

        public ConfigBox()
        {
            InitializeComponent();
        }


        public int COMNumber {
            get { return COMPort; }
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string curport = PortList_lst.SelectedItem.ToString();
                COMPort = int.Parse(curport.TrimStart('C', 'O', 'M'));
                this.Close();
            }
            catch
            {
                MessageBox.Show("Please select a COM port");
            }
        }


        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigBox_Load(object sender, EventArgs e)
        {
            PortList_lst.Items.Clear();
            PortList_lst.Items.AddRange(SerialPort.GetPortNames());
        }
    }
}
