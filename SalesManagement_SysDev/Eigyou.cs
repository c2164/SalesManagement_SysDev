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
    public partial class Eigyou : UserControl
    {
        private DispEmplyeeDTO loginEmployee;
        public F_Login mainform;
        public Eigyou(DispEmplyeeDTO emplyeeDTO)
        {
            InitializeComponent();
            loginEmployee = emplyeeDTO;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (splitContainer1.Panel2.Controls.Count != 0)
            {
                Control RemCotl;
                RemCotl = splitContainer1.Panel2.Controls[0];
                splitContainer1.Panel2.Controls.Remove(RemCotl);
            }
            SalesManagement_SysDev.Kokyaku kokyaku = new Kokyaku();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(kokyaku);
            mainform.setlabeltext("顧客管理");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Zyutyuu zyutyuu = new Zyutyuu(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(zyutyuu);
            mainform.setlabeltext("受注管理");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Tyuumon tyuumon = new Tyuumon(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(tyuumon);
            mainform.setlabeltext("注文管理");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Nyuuka nyuuka = new Nyuuka(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(nyuuka);
            mainform.setlabeltext("入荷管理");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syukka syukka = new Syukka(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syukka);
            mainform.setlabeltext("出荷管理");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Uriage uriage = new Uriage();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(uriage);
            mainform.setlabeltext("売上管理");
            //uriage1.Visible = true;
        }
    }
}
