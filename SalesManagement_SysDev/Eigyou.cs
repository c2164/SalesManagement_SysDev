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
            tyuumon1.Visible = false;
            nyuuka1.Visible = false;
            syukka1.Visible = false;
            uriage1.Visible = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            tyuumon1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            nyuuka1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            syukka1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            uriage1.Visible = true;
        }
    }
}
