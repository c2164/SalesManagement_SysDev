﻿using Microsoft.VisualBasic;
using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Kokyaku : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();

        public Kokyaku()
        {
            InitializeComponent();
        }

        private void Kokyaku_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("顧客情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            ClientDataAccess access = new ClientDataAccess();
            //顧客情報の全件取得
            List<DispClientDTO> tb = access.GetClientData();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Kokyaku_Namae.Text = "";
            textBox_Kokyaku_ID.Text = "";
            textBox_Yuubin.Text = "";
            textBox_Zyuusyo.Text = "";
            textBox_Dennwa1.Text = "";
            textBox_Dennwa2.Text = "";
            textBox_Dennwa3.Text = "";
            textBox_FAX1.Text = "";
            textBox_FAX2.Text = "";
            textBox_FAX3.Text = "";

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

        }

        private void SetDataGridView(List<DispClientDTO> tb)
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
            //顧客ID
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //顧客名
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 80;
            //営業所ID(非表示)
            dataGridView1.Columns[2].Visible = false;
            //営業所名
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;
            //住所
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 190;
            //電話番号
            dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].Width = 80;
            //電話番号1(非表示)
            dataGridView1.Columns[6].Visible = false;
            //電話番号2(非表示)
            dataGridView1.Columns[7].Visible = false;
            //電話番号3(非表示)
            dataGridView1.Columns[8].Visible = false;
            //郵便番号
            //dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 65;
            //FAX
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].Width = 83;
            //FAX1(非表示)
            dataGridView1.Columns[11].Visible = false;
            //FAX2(非表示)
            dataGridView1.Columns[12].Visible = false;
            //FAX3(非表示)
            dataGridView1.Columns[13].Visible = false;
            //顧客管理フラグ(非表示)
            dataGridView1.Columns[14].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[15].Visible = false;

        }

        private void button_Touroku_Click(object sender, EventArgs e)
        {

            RegisterClient();
        }

        private void RegisterClient()
        {
            //変数の宣言
            DispClientDTO dispClientDTO = new DispClientDTO();
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult result;

            //チェック済データの取得
            dispClientDTO = GetCheckedClientInf();
            if (dispClientDTO == null)
            {
                return;
            }
            dispClientDTO.ClID = "0";

            //
            if (!DuplicationCheckCliantInputRecord(dispClientDTO, out msg, out title, out icon))
            {
                result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            //登録確認
            result = messageDsp.MessageBoxDsp_OKCancel("登録しますか?", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //データを登録する
            RegisrationClientInf(dispClientDTO);
        }

        private DispClientDTO GetCheckedClientInf()
        {
            DispClientDTO retDispClient = new DispClientDTO();
            string msg;
            string title;
            MessageBoxIcon icon;
            bool flg;

            retDispClient = GetClientInf();
            flg = CheckClientInf(retDispClient, out msg, out title, out icon);
            if (!flg)
            {

                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }
            return retDispClient;
        }

        private DispClientDTO GetClientInf()
        {
            //変数の宣言
            DispClientDTO retDispClient = new DispClientDTO();

            //各コントロールから顧客情報を読み取る
            retDispClient.ClID = Strings.StrConv(textBox_Kokyaku_ID.Text.Trim(), VbStrConv.Narrow);//顧客ID
            retDispClient.ClName = textBox_Kokyaku_Namae.Text.Trim();//顧客名
            retDispClient.ClPostal = Strings.StrConv(textBox_Yuubin.Text.Trim(), VbStrConv.Narrow);//郵便番号
            retDispClient.ClPhone = Strings.StrConv(textBox_Dennwa1.Text.Trim(), VbStrConv.Narrow) + ('-') + Strings.StrConv(textBox_Dennwa2.Text.Trim(), VbStrConv.Narrow) + ('-') + Strings.StrConv(textBox_Dennwa3.Text.Trim(), VbStrConv.Narrow);//電話番号
            retDispClient.ClPhone1 = Strings.StrConv(textBox_Dennwa1.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClPhone2 = Strings.StrConv(textBox_Dennwa2.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClPhone3 = Strings.StrConv(textBox_Dennwa3.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClFAX = Strings.StrConv(textBox_FAX1.Text.Trim(), VbStrConv.Narrow) + ('-') + Strings.StrConv(textBox_FAX2.Text.Trim(), VbStrConv.Narrow) + ('-') + Strings.StrConv(textBox_FAX3.Text.Trim(), VbStrConv.Narrow);//FAX
            retDispClient.ClFAX1 = Strings.StrConv(textBox_FAX1.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClFAX2 = Strings.StrConv(textBox_FAX2.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClFAX3 = Strings.StrConv(textBox_FAX3.Text.Trim(), VbStrConv.Narrow);
            retDispClient.ClAddress = textBox_Zyuusyo.Text.Trim();//住所
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retDispClient.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所ID
            retDispClient.SoName = comboBox_Eigyousyo.Text.Trim();//営業所名

            return retDispClient;
        }

        private bool CheckClientInf(DispClientDTO checkClientDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            DataInputFormCheck formCheck = new DataInputFormCheck();

            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            if (String.IsNullOrEmpty(checkClientDTO.ClName))
            {
                msg = "顧客名は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkClientDTO.SoName))
            {
                msg = "営業所は必須項目です";
                title = "入力エラー";
                return false;
            }

            if (!String.IsNullOrEmpty(checkClientDTO.ClPostal))
            {
                if (!formCheck.CheckPostal(checkClientDTO.ClPostal))
                {
                    msg = "郵便番号の値が不正です";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "郵便番号は必須項目です";
                title = "入力エラー";
                return false;
            }

            if (String.IsNullOrEmpty(checkClientDTO.ClAddress))
            {
                msg = "住所は必須入力です";
                title = "入力エラー";
                return false;
            }

            if (!String.IsNullOrEmpty(checkClientDTO.ClPhone))
            {
                if (!formCheck.CheckPhoneAndFAX(checkClientDTO.ClPhone))
                {
                    msg = "電話番号の値が不正です";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "電話番号は必須項目";
                title = "入力エラー";
                return false;
            }

            if (!String.IsNullOrEmpty(checkClientDTO.ClFAX))
            {
                if (!formCheck.CheckPhoneAndFAX(checkClientDTO.ClFAX))
                {
                    msg = "FAXの値が不正です";
                    title = "入力エラー";
                    return false;
                }
            }
            else
            {
                msg = "FAXは必須項目です";
                title = "入力エラー";
                return false;
            }



            return true;

        }

        private void RegisrationClientInf(DispClientDTO dispClientDTO)
        {
            //変数の宣言
            bool flg;
            M_Client client;

            //インスタンス化
            ClientDataAccess clientDataAccess = new ClientDataAccess();

            //登録用にデータに変換
            client = FormalizationClientInputRecord(dispClientDTO);

            //登録処理
            flg = clientDataAccess.RegisterClientData(client);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("登録しました", "登録完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("失敗しました", "登録失敗", MessageBoxIcon.Error);
            }

            SetCtrlFormat();
            GetSelectData();
        }

        private bool DuplicationCheckCliantInputRecord(DispClientDTO clientDTO, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispClientDTO> clienttabledata = new List<DispClientDTO>();
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Question;

            //テーブルのデータを取得
            clienttabledata = GetTableData();

            //顧客IDに同じ商品がないかチェックする
            flg = clienttabledata.Any(x => x.SoID == clientDTO.SoID && x.ClName == clientDTO.ClName && x.ClPostal == clientDTO.ClPostal && x.ClAddress == clientDTO.ClAddress && x.ClPhone == clientDTO.ClPhone && x.ClFAX == clientDTO.ClFAX);
            if (flg)
            {
                msg = "同じ顧客が登録されていますがよろしいですか?";
                title = "確認";
                return false;
            }

            return true;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
            cmbclia();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayClient();
        }

        private void ListDisplayClient()
        {
            //変数の宣言
            List<DispClientDTO> client = new List<DispClientDTO>();
            List<DispClientDTO> sortedclient = new List<DispClientDTO>();

            //テーブルデータ受け取り
            client = GetTableData();

            //昇順に並び替える
            sortedclient = SortClientData(client);

            //データグリッドビュー表示
            SetDataGridView(sortedclient);

        }

        private List<DispClientDTO> GetTableData()
        {
            //変数の宣言
            List<DispClientDTO> client = new List<DispClientDTO>();

            //インスタンス化
            ClientDataAccess ClAccess = new ClientDataAccess();

            //データベースからデータを取得
            client = ClAccess.GetClientData();


            return client;
        }

        private List<DispClientDTO> SortClientData(List<DispClientDTO> dispClients)
        {
            //並び替え(昇順)
            dispClients.OrderBy(x => x.ClID);
            return dispClients;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectClient();
        }

        private void SelectClient()
        {
            //変数の宣言
            DispClientDTO clientDTO = new DispClientDTO();
            List<DispClientDTO> DisplayClient = new List<DispClientDTO>();

            //データの読み取り
            clientDTO = GetClientInf();
            //データの検索
            DisplayClient = SelectClientInf(clientDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplayClient);
        }

        private List<DispClientDTO> SelectClientInf(DispClientDTO clientDTO)
        {
            //変数の宣言
            List<DispClientDTO> retDispClient = new List<DispClientDTO>();
            //インスタンス化
            ClientDataAccess access = new ClientDataAccess();

            //顧客情報検索
            retDispClient = access.GetClientData(clientDTO);
            return retDispClient;
        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveClient();
        }

        private void RemoveClient()
        {
            //変数の宣言
            string ClID;
            M_Client client = new M_Client();

            //データグリッドビューで選択しているデータの顧客ID
            ClID = GetClientRecord();
            if (ClID == null)
            {
                return;
            }

            //取得した顧客IDでデータベースを検索する
            client = SelectReoveClient(ClID);
            if (client == null)
            {
                return;
            }

            //顧客管理フラグを0から2にする
            UpdateClFlag(client);
        }

        private void UpdateClFlag(M_Client client)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の顧客を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //商品管理フラグの変更
            client = ChangeClFlag(client);
            if (client == null)
            {
                return;
            }
            //商品の更新
            flg = UpdateProductRecord(client);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象顧客の更新に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象顧客を更新しました", "更新完了", MessageBoxIcon.Information);
            }
        }

        private bool UpdateProductRecord(M_Client client)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ClientDataAccess access = new ClientDataAccess();
            flg = access.UpdateClientData(client);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private M_Client ChangeClFlag(M_Client client)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            client.ClFlag = 2;
            client.ClHidden = Hidden;
            return client;
        }

        private M_Client SelectReoveClient(string ClID)
        {
            //変数の宣言
            M_Client retclient = new M_Client();
            DispClientDTO dispClientDTO = new DispClientDTO();
            List<DispClientDTO> dispClients = new List<DispClientDTO>();
            //データベースからデータを取得する
            dispClients = GetTableData();
            if (dispClients == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("顧客情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った商品IDで検索
            dispClientDTO = dispClients.Single(x => x.ClID == ClID);

            //検索結果を返却用にする
            retclient = FormalizationClientInputRecord(dispClientDTO);

            return retclient;
        }

        private M_Client FormalizationClientInputRecord(DispClientDTO dispClientDTO)
        {
            //変数の宣言
            M_Client retclient = new M_Client();

            //表示用からテーブル用にする
            retclient.ClID = int.Parse(dispClientDTO.ClID);
            retclient.SoID = int.Parse(dispClientDTO.SoID);
            retclient.ClName = dispClientDTO.ClName;
            retclient.ClAddress = dispClientDTO.ClAddress;
            retclient.ClPostal = dispClientDTO.ClPostal;
            retclient.ClPhone = dispClientDTO.ClPhone;
            retclient.ClFAX = dispClientDTO.ClFAX;
            retclient.ClFlag = 0;

            return retclient;
        }

        private string GetClientRecord()
        {
            string ClID;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            ClID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return ClID;
        }
        private void button_Kousin_Click(object sender, EventArgs e)
        {
            UpdateClient();
        }

        private void UpdateClient()
        {
            //変数の宣言
            DispClientDTO dispClientDTO = new DispClientDTO();
            bool flg;

            //入力チェック済みのデータを取得
            dispClientDTO = GetCheckedClientInf();
            if (dispClientDTO == null)
            {
                return;
            }
            //存在チェック
            flg = ExistsCheck(dispClientDTO);
            if (!flg)
            {
                return;
            }

            //入力情報で顧客情報を更新する
            UpdateClientInf(dispClientDTO);


        }

        private bool ExistsCheck(DispClientDTO dispClientDTO)
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            DialogResult result = DialogResult.OK;

            //存在チェック
            ExistsCheckCliantInputRecord(dispClientDTO, out msg, out title, out icon);

            result = messageDsp.MessageBoxDsp_OKCancel(msg, title, icon);
            if (result == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }

        private void ExistsCheckCliantInputRecord(DispClientDTO checkDispClient, out string msg, out string title, out MessageBoxIcon icon)
        {
            //初期値代入
            bool flg;
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            List<DispClientDTO> dispClient = new List<DispClientDTO>();
            ClientDataAccess access = new ClientDataAccess();

            //テーブルのデータを取得
            dispClient = access.GetClientData();

            //ID以外が同じ内容か確認
            flg = dispClient.Any(x => x.ClName == checkDispClient.ClName && x.SoID == checkDispClient.SoID && x.ClPostal == checkDispClient.ClPostal && x.ClAddress == checkDispClient.ClAddress && x.ClPhone == checkDispClient.ClPhone && x.ClFAX == checkDispClient.ClFAX);
            if (flg)
            {
                msg = "既に同じ内容のデータが存在します\n本当に更新してもよろしいですか?";
                title = "警告";
                icon = MessageBoxIcon.Warning;
            }
            else
            {
                msg = "データを更新してもよろしいですか";
                title = "更新確認";
                icon = MessageBoxIcon.Information;
            }
        }

        private void UpdateClientInf(DispClientDTO dispClientDTO)
        {
            //変数の宣言
            M_Client UpClirnt = new M_Client();
            bool flg;

            //表示用データからテーブル用データに変換
            UpClirnt = FormalizationClientInputRecord(dispClientDTO);
            flg = UpdateProductRecord(UpClirnt);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK("対象顧客の更新に失敗しました", "エラー", MessageBoxIcon.Error);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象顧客を更新しました", "更新完了", MessageBoxIcon.Information);
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Kokyaku_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox_Kokyaku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox_Yuubin.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
            textBox_Zyuusyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();

            textBox_Dennwa1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString().Split('-')[0];
            textBox_Dennwa2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString().Split('-')[1];
            textBox_Dennwa3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString().Split('-')[2];

            textBox_FAX1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString().Split('-')[0];
            textBox_FAX2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString().Split('-')[1];
            textBox_FAX3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString().Split('-')[2];



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label2.ForeColor = Color.LightGray;
            textBox_Kokyaku_ID.Enabled = false;
            textBox_Kokyaku_ID.BackColor = Color.LightGray;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label2.ForeColor = Color.LightGray;
            textBox_Kokyaku_ID.Enabled = false;
            textBox_Kokyaku_ID.BackColor = Color.LightGray;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textBox_Kokyaku_Namae.Enabled = false;
            textBox_Kokyaku_Namae.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            textBox_Kokyaku_ID.Enabled = false;
            textBox_Kokyaku_ID.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            comboBox_Eigyousyo.Enabled = false;
            comboBox_Eigyousyo.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            textBox_Yuubin.Enabled = false;
            textBox_Yuubin.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textBox_Zyuusyo.Enabled = false;
            textBox_Zyuusyo.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            textBox_Dennwa1.Enabled = false;
            textBox_Dennwa1.BackColor = Color.LightGray;
            textBox_Dennwa2.Enabled = false;
            textBox_Dennwa2.BackColor = Color.LightGray;
            textBox_Dennwa3.Enabled = false;
            textBox_Dennwa3.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            textBox_FAX1.Enabled = false;
            textBox_FAX1.BackColor = Color.LightGray;
            textBox_FAX2.Enabled = false;
            textBox_FAX2.BackColor = Color.LightGray;
            textBox_FAX3.Enabled = false;
            textBox_FAX3.BackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
            label11.ForeColor = Color.LightGray;
        }

        private void cmbclia()
        {
            label1.ForeColor = Color.Black;
            textBox_Kokyaku_Namae.Enabled = true;
            textBox_Kokyaku_Namae.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            textBox_Kokyaku_ID.Enabled = true;
            textBox_Kokyaku_ID.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            comboBox_Eigyousyo.Enabled = true;
            comboBox_Eigyousyo.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            textBox_Yuubin.Enabled = true;
            textBox_Yuubin.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            textBox_Zyuusyo.Enabled = true;
            textBox_Zyuusyo.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            textBox_Dennwa1.Enabled = true;
            textBox_Dennwa1.BackColor = Color.White;
            textBox_Dennwa2.Enabled = true;
            textBox_Dennwa2.BackColor = Color.White;
            textBox_Dennwa3.Enabled = true;
            textBox_Dennwa3.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            textBox_FAX1.Enabled = true;
            textBox_FAX1.BackColor = Color.White;
            textBox_FAX2.Enabled = true;
            textBox_FAX2.BackColor = Color.White;
            textBox_FAX3.Enabled = true;
            textBox_FAX3.BackColor = Color.White;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
        }
    }
}
