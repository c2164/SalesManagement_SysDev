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
    public partial class Buturyuu : UserControl
    {
        public Buturyuu()
        {
            InitializeComponent();

            syouhin1.Visible = false;
            zaiko1.Visible = false;
        }

        private void button_Syouhin_Kannri_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            syouhin1.Visible = true;
        }

        private void button_Zaiko_Kannri_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            zaiko1.Visible = true;
        }
    }
}
