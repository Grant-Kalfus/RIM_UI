using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            COMPort = (int)COMPortEntry_sel.Value;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
