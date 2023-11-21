using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Eigyou : UserControl
    {
        public Eigyou()
        {
            InitializeComponent();

            kokyaku1.Visible = false;
            zyutyuu1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            kokyaku1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            zyutyuu1.Visible = true;
        }
    }
}
