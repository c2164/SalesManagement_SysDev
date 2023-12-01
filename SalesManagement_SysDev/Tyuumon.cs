using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
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
    public partial class Tyuumon : UserControl
    {
        public Tyuumon()
        {
            InitializeComponent();
        }

        private void Tyuumon_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            /*if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp("出荷情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }*/


        }
        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();

            textbox_Tyuumon_ID.Text = "";
            textbox_Syouhin_Namae.Text = "";
            textbox_Tyuumonsyousai_ID.Text = "";
            textbox_Zyutyuusyousai.Text = "";
            textbox_Kokyaku_Namae.Text = "";
            textbox_Syain_Namae.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;


        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            //GetSelectData();
            SetCtrlFormat();
        }
    }
}
