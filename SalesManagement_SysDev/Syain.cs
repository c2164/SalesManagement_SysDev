using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Syain : UserControl
    {

        private MessageDsp messageDsp = new MessageDsp();

        public Syain()
        {
            InitializeComponent();
        }

        private void Syain_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("社員情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            EmployeeDataAccess access = new EmployeeDataAccess();
            //社員情報の全件取得
            List<DispEmplyeeDTO> tb = access.GetEmployeeData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetDataGridView(List<DispEmplyeeDTO> tb)
        {
            dataGridView1.DataSource = tb;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー文字位置、セル文字位置、列幅の設定
            //社員ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //社員名
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[1].Width = 120;
            //営業所ID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //営業所名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 100;
            //役職ID(非表示)
            dataGridView1.Columns[4].Visible = false;
            //役職名
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 100;
            //入社年月日
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 157;
            //パスワード
            dataGridView1.Columns[7].Visible = false;
            //電話番号
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 100;
            //電話番号1(非表示)
            dataGridView1.Columns[9].Visible = false;
            //電話番号2(非表示)
            dataGridView1.Columns[10].Visible = false;
            //電話番号3(非表示)
            dataGridView1.Columns[11].Visible = false;
            //社員管理フラグ(非表示)
            dataGridView1.Columns[12].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[13].Visible = false;

        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesofficeDateAccess = new SalesOfficeDataAccess();
            PositionDataAccess positionDataAccess = new PositionDataAccess();

            //各テキストボックスに初期化(空白)
            textBox_Syain_Namae.Text = "";
            textBox_Syain_ID.Text = "";
            textBox_Dennwa.Text = "";
            textBox_Dennwa2.Text = "";
            textBox_Dennwa3.Text = "";
            textBox_Pass.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesofficeDateAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;
            comboBox_Yakusyoku_Namae.DisplayMember = "PoName";
            comboBox_Yakusyoku_Namae.ValueMember = "PoID";
            comboBox_Yakusyoku_Namae.DataSource = positionDataAccess.GetPositionData();
            comboBox_Yakusyoku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Yakusyoku_Namae.SelectedIndex = -1;

            //日付を現在の日付にする
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayEmployee();
        }

        private void ListDisplayEmployee()
        {
            //変数の宣言
            List<DispEmplyeeDTO> employee = new List<DispEmplyeeDTO>();
            List<DispEmplyeeDTO> sortedemployee = new List<DispEmplyeeDTO>();

            //テーブルデータ受け取り
            employee = GetTableData();

            //昇順に並び替える
            sortedemployee = SortEmployeeData(employee);

            //データグリッドビュー表示
            SetDataGridView(sortedemployee);
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

        private List<DispEmplyeeDTO> SortEmployeeData(List<DispEmplyeeDTO> dispEmployees)
        {
            //並び替え(昇順)
            dispEmployees.OrderBy(x => x.EmID);
            return dispEmployees;

        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }

        private void SelectEmployee()
        {
            //変数の宣言
            DispEmplyeeDTO employeeDTO = new DispEmplyeeDTO();
            List<DispEmplyeeDTO> DisplayEmployee = new List<DispEmplyeeDTO>();

            //データの読み取り
            employeeDTO = GetEmployeeInf();
            //データの検索
            DisplayEmployee = SelectEmployeeInf(employeeDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayEmployee);
        }

        private DispEmplyeeDTO GetEmployeeInf()
        {
            //変数の宣言
            DispEmplyeeDTO retEmployeeDTO = new DispEmplyeeDTO();

            //各コントロールから社員情報を読み取る
            retEmployeeDTO.EmName = textBox_Syain_Namae.Text.Trim();
            retEmployeeDTO.EmID = textBox_Syain_ID.Text.Trim();
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retEmployeeDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();
            retEmployeeDTO.SoName = comboBox_Eigyousyo.Text.Trim();
            if (!(comboBox_Yakusyoku_Namae.SelectedIndex == -1))
                retEmployeeDTO.PoID = comboBox_Yakusyoku_Namae.SelectedValue.ToString();
            retEmployeeDTO.PoName = comboBox_Yakusyoku_Namae.Text.Trim();
            retEmployeeDTO.EmHiredate = dateTimePicker1.Value;
            retEmployeeDTO.EmPhone = textBox_Dennwa.Text.Trim() + ('-') + textBox_Dennwa2.Text.Trim() + ('-') + textBox_Dennwa3.Text.Trim();
            retEmployeeDTO.EmPhone1 = textBox_Dennwa.Text.Trim();
            retEmployeeDTO.EmPhone2 = textBox_Dennwa2.Text.Trim();
            retEmployeeDTO.EmPhone3 = textBox_Dennwa3.Text.Trim();
            //Fax削除予定
            retEmployeeDTO.EmPassword = textBox_Pass.Text.Trim();

            return retEmployeeDTO;
        }

        private List<DispEmplyeeDTO> SelectEmployeeInf(DispEmplyeeDTO employeeDTO)
        {
            //変数の宣言
            List<DispEmplyeeDTO> retDispEmployee = new List<DispEmplyeeDTO>();
            //インスタンス化
            EmployeeDataAccess access = new EmployeeDataAccess();

            //社員情報検索
            retDispEmployee = access.GetEmployeeData(employeeDTO);
            return retDispEmployee;

        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void RemoveEmployee()
        {
            //変数の宣言
            string EmID;
            M_Employee Employee = new M_Employee();
            //データグリッドビューで選択されているデータの社員IDを受け取る
            EmID = GetEmployeeRecord();

            //取得した社員IDでデータベースを検索する
            Employee = SelectRemoveEmployee(EmID);
            if (Employee == null)
            {
                messageDsp.MessageBoxDsp_OK("社員情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }

            //社員管理フラグを0から2にする
            UpdateEmFlag(Employee);
        }

        private void UpdateEmFlag(M_Employee employee)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の社員を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //社員管理フラグの変更
            employee = ChangeEmFlag(employee);
            if (employee == null)
            {
                return;
            }
            //社員の更新
            flg = UpdateEmployeeRecord(employee);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象在庫を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象在庫の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateEmployeeRecord(M_Employee employee)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            EmployeeDataAccess access = new EmployeeDataAccess();
            flg = access.UpdateEmployeeData(employee);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private M_Employee ChangeEmFlag(M_Employee employee)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            employee.EmFlag = 2;
            employee.EmHidden = Hidden;
            return employee;
        }

        private M_Employee SelectRemoveEmployee(string EmID)
        {
            //変数の宣言
            M_Employee retemployee = new M_Employee();
            DispEmplyeeDTO dispEmployeeDTO = new DispEmplyeeDTO();
            List<DispEmplyeeDTO> dispEmployees = new List<DispEmplyeeDTO>();
            //データベースからデータを取得する
            dispEmployees = GetTableData();
            if (dispEmployees == null) //データの取得失敗
            {
                return null;
            }

            //Listの中を受け取った社員IDで検索
            dispEmployeeDTO = dispEmployees.Single(x => x.EmID == EmID);

            //検索結果を返却用にする
            retemployee = FormalizationEmployeeInputRecord(dispEmployeeDTO);

            return retemployee;
        }

        private M_Employee FormalizationEmployeeInputRecord(DispEmplyeeDTO dispEmployeeDTO)
        {
            //変数の宣言(登録のやつ)
            M_Employee employee = new M_Employee();

            M_Employee retemployee = new M_Employee();
            retemployee.EmID = int.Parse(dispEmployeeDTO.EmID);
            retemployee.EmName = dispEmployeeDTO.EmName;
            retemployee.SoID = int.Parse(dispEmployeeDTO.SoID);
            retemployee.PoID = int.Parse(dispEmployeeDTO.PoID);
            retemployee.EmHiredate = dispEmployeeDTO.EmHiredate;
            retemployee.EmPhone = dispEmployeeDTO.EmPhone;
            retemployee.EmPassword = dispEmployeeDTO.EmPassword;
            retemployee.EmFlag = 0;
            retemployee.EmHidden = dispEmployeeDTO.EmHidden;

            return retemployee;
        }

        private string GetEmployeeRecord()
        {
            //変数の宣言
            string retEmID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retEmID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retEmID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox_Syain_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            comboBox_Yakusyoku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString());
            textBox_Dennwa.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString().Split('-')[0];
            textBox_Dennwa2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString().Split('-')[1];
            textBox_Dennwa3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString().Split('-')[2];
            textBox_Pass.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
        }

        private void button_Touroku_Click(object sender, EventArgs e)
        {
            RegisterEmployee();
        }

        private void RegisterEmployee()
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult result;
            DispEmplyeeDTO dispEmployeeDTO = new DispEmplyeeDTO();

            //入力チェック済のデータを受け取る
            dispEmployeeDTO = GetCheckedEmployeeInf();
            //NULLなら失敗
            if (dispEmployeeDTO == null)
            {
                return;
            }

            //重複チェックを行う
            if (!DuplicationCheckEmployeeInputRecord(dispEmployeeDTO, out msg, out title, out icon))
            {
                result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //登録確認
            //須田オーダー
            result = messageDsp.MessageBoxDsp_OKCancel("社員を登録しますか？", "登録確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //データを登録する
            RegisrationEmployeeInf(dispEmployeeDTO);
        }

        private void RegisrationEmployeeInf(DispEmplyeeDTO dispEmployeeDTO)
        {
            //変数の宣言
            bool flg;
            M_Employee employee;

            //インスタンス化
            EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

            //登録用データに変換
            employee = FormalizationEmployeeInputRecord(dispEmployeeDTO);
            //登録処理
            flg = employeeDataAccess.RegisterEmployeeData(employee);
            if (flg)
            {
                //須田オーダー
                messageDsp.MessageBoxDsp_OK("社員を登録しました", "登録完了", MessageBoxIcon.Information);
            }
            else
            {
                //須田オーダー
                messageDsp.MessageBoxDsp_OK("社員の登録に失敗しました", "登録エラー", MessageBoxIcon.Error);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private bool DuplicationCheckEmployeeInputRecord(DispEmplyeeDTO dispEmployeeDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispEmplyeeDTO> employeetabledata = new List<DispEmplyeeDTO>();
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Question;

            //テーブルのデータを取得
            employeetabledata = GetTableData();

            //同じ社員IDに同じ社員がないかチェックする
            flg = employeetabledata.Any(x => x.EmID == dispEmployeeDTO.EmID);
            if (flg)
            {
                msg = "この社員IDは既に使用されています";
                title = "入力エラー";
                return false;
            }



            return true;
        }

        private DispEmplyeeDTO GetCheckedEmployeeInf()
        {
            //変数の宣言
            DispEmplyeeDTO dispEmployee = new DispEmplyeeDTO();
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;

            //各コントロールから登録する受注情報を取得
            dispEmployee = GetEmployeeInf();

            //取得した受注情報のデータ形式のチェック
            flg = CheckEmployeeInf(dispEmployee, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            return dispEmployee;

        }

        private bool CheckEmployeeInf(DispEmplyeeDTO checkdata, out string msg, out string title, out MessageBoxIcon icon)
        {
            //チェッククラスのインスタンス化
            DataInputFormCheck inputFormCheck = new DataInputFormCheck();

            //初期値代入(返却時エラー解消のため)
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            if (String.IsNullOrEmpty(checkdata.EmName))
            {
                msg = "社員名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (inputFormCheck.CheckNumeric(checkdata.EmID))
            {
                if (int.Parse(checkdata.EmID) <= 0)
                {
                    msg = "社員IDは1以上の半角数字を入力して下さい";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "社員IDには半角数字を入力してください";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.SoName))
            {
                msg = "営業所は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.PoName))
            {
                msg = "役職名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkdata.EmPassword))
            {
                msg = "パスワードは必須入力です";
                title = "入力エラー";
                return false;
            }

            if (!String.IsNullOrEmpty(checkdata.EmPhone))
            {
                if (!inputFormCheck.CheckPhoneAndFAX(checkdata.EmPhone))
                {
                    msg = "電話番号の値が不正です";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "電話番号は必須入力です";
                title = "入力エラー";
                return false;
            }

            return true;
        }

        private void button_Kousin_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void UpdateEmployee()
        {
            //変数の宣言
            DispEmplyeeDTO dispEmployeeDTO = new DispEmplyeeDTO();
            string EmID;
            bool flg;
            //チェック済みの入力情報を得る
            dispEmployeeDTO = GetCheckedEmployeeInf();
            if (dispEmployeeDTO == null)
            {
                return;
            }
            EmID = GetEmployeeRecord();
            if (EmID == null)
            {
                return;
            }
            dispEmployeeDTO.EmID = EmID;

            //存在チェック
            flg = ExistsCheck(dispEmployeeDTO);
            if (!flg)
            {
                return;
            }
            //入力情報で社員情報を更新する
            UpdateEmployeeInf(dispEmployeeDTO);
        }

        private void UpdateEmployeeInf(DispEmplyeeDTO dispEmployeeDTO)
        {
            //変数の宣言
            M_Employee UpEmployee = new M_Employee();
            bool flg;
            DialogResult result;
            //表示用データからテーブル用データに変換
            UpEmployee = FormalizationEmployeeInputRecord(dispEmployeeDTO);

            // 更新確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の社員を更新してもよろしいですか", "更新確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //更新実行
            flg = UpdateEmployeeRecord(UpEmployee);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象社員を更新しました", "更新完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象社員の更新に失敗しました", "エラー", MessageBoxIcon.Error);
            }

        }

        private bool ExistsCheck(DispEmplyeeDTO checkDispEmployee)
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            //DialogResult result = DialogResult.OK;
            bool flg;

            //存在チェック
            flg = ExistsCheckEmployeeInputRecord(checkDispEmployee, out msg, out title, out icon);


            return flg;
        }

        private bool ExistsCheckEmployeeInputRecord(DispEmplyeeDTO checkDispEmployee, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            List<DispEmplyeeDTO> dispEmoloyee = new List<DispEmplyeeDTO>();
            EmployeeDataAccess access = new EmployeeDataAccess();

            //テーブルのデータを取得
            dispEmoloyee = access.GetEmployeeData();
            if (dispEmoloyee == null)
            {
                msg = "社員情報が取得できんせんでした";
                title = "エラー";
                return false;
            }

            //ID以外が同じ内容か確認
            flg = dispEmoloyee.Any(x => x.EmName == checkDispEmployee.EmName && x.SoID == checkDispEmployee.SoID && x.PoID == checkDispEmployee.PoID && x.EmHiredate == checkDispEmployee.EmHiredate && x.EmPhone == checkDispEmployee.EmPhone && x.EmPassword == checkDispEmployee.EmPassword);
            if (flg)
            {
                msg = "既に同じ内容のデータが存在します\n本当に更新してもよろしいですか？";
                title = "警告";
                icon = MessageBoxIcon.Warning;
            }
            else
            {
                msg = "データを更新してもよろしいですか";
                title = "更新確認";
                icon = MessageBoxIcon.Information;
            }

            return true;
        }
    }
}
