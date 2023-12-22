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
        public Eigyou(DispEmplyeeDTO emplyeeDTO)
        {
            InitializeComponent();
            loginEmployee = emplyeeDTO;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(splitContainer1.Panel2.Controls.Count != 0)
            {
                Control RemCotl;
                RemCotl = splitContainer1.Panel2.Controls[0];
                splitContainer1.Panel2.Controls.Remove(RemCotl);
            }
            SalesManagement_SysDev.Kokyaku kokyaku = new Kokyaku();
            
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(kokyaku);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Zyutyuu zyutyuu = new Zyutyuu(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(zyutyuu);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Tyuumon tyuumon = new Tyuumon(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(tyuumon);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Nyuuka nyuuka = new Nyuuka(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(nyuuka);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Syukka syukka = new Syukka(loginEmployee);

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(syukka);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesManagement_SysDev.Uriage uriage = new Uriage();

            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Controls.Add(uriage);
            //uriage1.Visible = true;
        }
    }
}
