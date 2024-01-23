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
        public F_Login mainform;
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
            bool flg;

            //入力されたログイン情報の取得
            dispEmplyeeDTO = GetCheckedLoginInf();
            if(dispEmplyeeDTO == null)
            {
                return;
            }
            //パスワード照合
            flg = ComparePassword(dispEmplyeeDTO, out dispEmplyeeDTO);
            if (!flg)
            {
                return;
            }

            //ログイン判定
            SetFormView(dispEmplyeeDTO);

        }

        private void SetFormView(DispEmplyeeDTO dispEmplyeeDTO)
        {
            //役職判定
            JudgeLimitButton(dispEmplyeeDTO);

            //ログイン画面を閉じる
            this.Dispose();
        }

        private void JudgeLimitButton(DispEmplyeeDTO dispEmplyeeDTO)
        {
            switch (dispEmplyeeDTO.PoID)
            {
                case "1":
                    {
                        LimitBottunAdministrator(dispEmplyeeDTO);
                        break;
                    }
                case "2":
                    {
                        LimitBottunSales(dispEmplyeeDTO);
                        break;
                    }
                case "3":
                    {
                        LimitBottunLogistics(dispEmplyeeDTO);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void LimitBottunAdministrator(DispEmplyeeDTO dispEmplyeeDTO)
        {
            mainform.LoginEmployee = dispEmplyeeDTO;
            mainform.LimitBottunAdministrator();
        }

        private void LimitBottunSales(DispEmplyeeDTO dispEmplyeeDTO)
        {
            mainform.LoginEmployee = dispEmplyeeDTO;
            mainform.LimitBottunSales();
        }

        private void LimitBottunLogistics(DispEmplyeeDTO dispEmplyeeDTO)
        {
            mainform.LoginEmployee = dispEmplyeeDTO;
            mainform.LimitBottunLogistics();
        }

        private string JudgePosition(DispEmplyeeDTO dispEmplyeeDTO)
        {
            return dispEmplyeeDTO.PoID;
        }

        private bool ComparePassword(DispEmplyeeDTO dispEmplyeeDTO, out DispEmplyeeDTO dispEmplyee)
        {
            //変数の宣言
            bool flg;

            //社員情報を取得
            dispEmplyee = GetEmployeeRecord(dispEmplyeeDTO);
            if(dispEmplyee == null)
            {
                messageDsp.MessageBoxDsp_OK("社員情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return false;
            }

            //パスワード照合
            flg = CompareLoginAndEmployee(dispEmplyee, dispEmplyeeDTO);
            if(!flg)
            {
                messageDsp.MessageBoxDsp_OK("入力された社員IDまたはパスワードに誤りがあります", "", MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private DispEmplyeeDTO GetEmployeeRecord(DispEmplyeeDTO dispEmplyeeDTO)
        {
            //変数の宣言
            List<DispEmplyeeDTO> dispEmplyees = new List<DispEmplyeeDTO>();
            DispEmplyeeDTO retdispEmplyeeDTO = new DispEmplyeeDTO();

            //社員情報取得
            dispEmplyees = GetTableData();
            //取得した社員情報から社員IDで絞り込む
            if (dispEmplyeeDTO != null)
            {
                retdispEmplyeeDTO = dispEmplyees.SingleOrDefault(x => x.EmID == dispEmplyeeDTO.EmID);
            }

            return retdispEmplyeeDTO;

        }

        private bool CompareLoginAndEmployee(DispEmplyeeDTO dispEmplyee, DispEmplyeeDTO dispEmplyeeDTO)
        {
            //パスワード照合
            if(!(dispEmplyee.EmPassword == dispEmplyeeDTO.EmPassword))
            {
                return false;
            }
            return true;
        }

        private List<DispEmplyeeDTO> GetTableData()
        {
            //変数の宣言
            List<DispEmplyeeDTO> employee = new List<DispEmplyeeDTO>();

            //インスタンス化
            EmployeeDataAccess EmAccess = new EmployeeDataAccess();

            //データベースからデータを取得
            employee = EmAccess.GetEmployeeData();


            return employee;
        }

        private DispEmplyeeDTO GetCheckedLoginInf()
        {
            //変数の宣言
            DispEmplyeeDTO retdispEmplyeeDTO = new DispEmplyeeDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //各コントロールからログイン情報取得
            retdispEmplyeeDTO = GetLoginInf();

            flg = CheckLoginInf(retdispEmplyeeDTO, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return retdispEmplyeeDTO;
        }

        private bool CheckLoginInf(DispEmplyeeDTO retdispEmplyeeDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            if (String.IsNullOrEmpty(retdispEmplyeeDTO.EmID))
            {
                msg = "社員IDは必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(retdispEmplyeeDTO.EmPassword))
            {
                msg = "パスワードは必須入力です";
                title = "入力エラー";
                return false;
            }

            return true;
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
