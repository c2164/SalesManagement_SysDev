using SalesManagement_SysDev.Common;
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
    public partial class Roguin : UserControl
    {
        MessageDsp messageDsp = new MessageDsp();
        public Roguin()
        {
            InitializeComponent();
        }

        private void button_Roguin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            //変数の宣言
            DispEmplyeeDTO dispEmplyeeDTO = new DispEmplyeeDTO();
            dispEmplyeeDTO = GetCheckedLoginInf();
        }

        private DispEmplyeeDTO GetCheckedLoginInf()
        {
            //変数の宣言
            DispEmplyeeDTO retdispEmplyeeDTO = new DispEmplyeeDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon

            //各コントロールからログイン情報取得
            retdispEmplyeeDTO = GetLoginInf();

            flg = CheckLoginInf(retdispEmplyeeDTO, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }
        }

        private bool CheckLoginInf(DispEmplyeeDTO retdispEmplyeeDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
        }

        private DispEmplyeeDTO GetLoginInf()
        {
            //変数の宣言
            DispEmplyeeDTO retdispEmplyeeDTO = new DispEmplyeeDTO();

            retdispEmplyeeDTO.EmID = textBox_Syain_ID.Text;
            retdispEmplyeeDTO.EmPassword = textBox_Pass.Text;

            return retdispEmplyeeDTO;
        }
    }
}
