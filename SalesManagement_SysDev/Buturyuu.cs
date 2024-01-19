using SalesManagement_SysDev.Entity;
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
        private DispEmplyeeDTO loginEmployee;

        public F_Login mainform;
        public Buturyuu(DispEmplyeeDTO emplyeeDTO)
        {
            InitializeComponent();
            loginEmployee = emplyeeDTO;
        }

        private void button_Syouhin_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syouhin syouhin = new Syouhin();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syouhin);
            mainform.setlabeltext("商品管理");
        }

        private void button_Zaiko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Zaiko zaiko = new Zaiko();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(zaiko);
            mainform.setlabeltext("在庫管理");
        }

        private void button_Syukko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syukko syukko = new Syukko(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syukko);
            mainform.setlabeltext("出庫管理");
        }

        private void button_Hattyuu_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Hattyuu hattyuu = new Hattyuu(loginEmployee);
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            splitContainer1.Panel2.Controls.Add(hattyuu);
            mainform.setlabeltext("発注管理");
        }

        private void button_Nyuuko_Kannri_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Nyuuko nyuuko = new Nyuuko(loginEmployee);
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;

            splitContainer1.Panel2.Controls.Add(nyuuko);
            mainform.setlabeltext("入庫管理");
        }
    }
}
