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

        }

        private void button_Syouhin_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syouhin syouhin = new Syouhin();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syouhin);
        }

        private void button_Zaiko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Zaiko zaiko = new Zaiko();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(zaiko);

        }

        private void button_Syukko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syukko syukko = new Syukko();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syukko);
        }

        private void button_Hattyuu_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Hattyuu hattyuu = new Hattyuu();
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            splitContainer1.Panel2.Controls.Add(hattyuu);
        }

        private void button_Nyuuko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Nyuuko nyuuko = new Nyuuko();
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            splitContainer1.Panel2.Controls.Add(nyuuko);
        }
    }
}
