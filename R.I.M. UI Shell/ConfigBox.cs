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
        public ConfigBox()
        {
            InitializeComponent();
            First_time_load = true;
            Param_Enables = false;

            PortList_lst.Items.Clear();
            PortList_lst.Items.AddRange(SerialPort.GetPortNames());
        }

        public bool First_time_load { get; set; }

        public Main_wnd.Motor_Settings CfgBox_Motor_Settings { get; set; }

        public bool Param_Enables
        {
            get { return Dev_Config.Enabled; }
            set
            {
                Dev_Config.Enabled = value;
                Ok_btn.Enabled = value;
            }
        }


        public int COMNumber { get; private set; }






        private void Ok_btn_Click(object sender, EventArgs e)
        {
                Close();
        }


        private void ConfigBox_Load(object sender, EventArgs e)
        {
            M1MaxSpeed_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].max_speed;
            M1MaxDecel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].decel;
            M1MaxAccel_entry.Value = CfgBox_Motor_Settings.All_Motor_Settings[0].accel;
        }

        private void Fetch_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string curport = PortList_lst.SelectedItem.ToString();
                COMNumber = int.Parse(curport.TrimStart('C', 'O', 'M'));
                Close();
            }
            catch
            {
                MessageBox.Show("Please select a COM port");
            }
        }
    }
}
