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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Tyuumon : UserControl
    {
        private DispEmplyeeDTO loginEmployee;
        private MessageDsp messageDsp = new MessageDsp();
        private int DataGridViewState;
        private int checkbox_stateflag = 0;
        public Tyuumon(DispEmplyeeDTO dispEmplyee)
        {
            loginEmployee = dispEmplyee;
            InitializeComponent();
        }

        private void Tyuumon_Load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("出荷情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }


        }

        private bool GetSelectData()
        {
            ChumonDataAccess access = new ChumonDataAccess();
            //出荷情報の全件取得
            List<DispChumonDTO> tb = access.GetChumonData(checkbox_stateflag);
            List<DispChumonDTO> disptb = new List<DispChumonDTO>();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            disptb = GetDataGridViewData(tb);

            SetDataGridView(disptb);
            return true;
        }

        private List<DispChumonDTO> GetDataGridViewData(List<DispChumonDTO> tb)
        {
            List<DispChumonDTO> disptb = new List<DispChumonDTO>();
            var grouptb = tb.GroupBy(x => x.ChID).ToList();
            foreach (var groupingchumontb in grouptb)
            {
                foreach (var chumontb in groupingchumontb)
                {
                    DispChumonDTO chumonDTO = new DispChumonDTO();
                    chumonDTO.OrID = chumontb.OrID;
                    chumonDTO.SoID = chumontb.SoID;
                    chumonDTO.SoName = chumontb.SoName;
                    chumonDTO.EmID = chumontb.EmID;
                    chumonDTO.EmName = chumontb.EmName;
                    chumonDTO.ClID = chumontb.ClID;
                    chumonDTO.ClName = chumontb.ClName;
                    chumonDTO.ChID = chumontb.ChID;
                    chumonDTO.ChDate = chumontb.ChDate;
                    if (chumontb.ChStateFlag == "1")
                    {
                        chumonDTO.ChStateFlag = "済";
                    }
                    else
                    {
                        chumonDTO.ChStateFlag = "未";
                    }
                    chumonDTO.ChFlag = chumontb.ChFlag;
                    chumonDTO.ChHidden = chumontb.ChHidden;

                    disptb.Add(chumonDTO);
                    break;
                }
            }
            return disptb;
        }

        private bool GetSelectDetailData(string ChID)
        {
            ChumonDataAccess access = new ChumonDataAccess();
            DispChumonDTO dispChumon = new DispChumonDTO()
            {
                ChID = ChID,
                PrID = "",
                PrName = "",
                EmName = "",
                ClName = "",
                OrID = "",
                ChDetailID = "",
                SoName = "",
                ChStateFlag = checkbox_stateflag.ToString()
            };
            //出荷情報の全件取得
            List<DispChumonDTO> tb = access.GetChumonData(dispChumon);

            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDetailDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
            ClientDataAccess clientDataAccess = new ClientDataAccess();

            textbox_Tyuumon_ID.Text = "";
            textbox_Tyuumonsyousai_ID.Text = "";
            textbox_Zyutyuusyousai.Text = "";
            numericUPDown_Syouhin_Namae.Value = 0;
            dateTimePicker_Tyuumon_Nenngetu.Value = DateTime.Now;

            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            comboBox_Syouhin_Namae.DisplayMember = "PrName";
            comboBox_Syouhin_Namae.ValueMember = "PrID";
            comboBox_Syouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBox_Syouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syouhin_Namae.SelectedIndex = -1;

            comboBox_Syain_Namae.DisplayMember = "EmName";
            comboBox_Syain_Namae.ValueMember = "EmID";
            comboBox_Syain_Namae.DataSource = employeeDataAccess.GetEmployeeData();
            comboBox_Syain_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Syain_Namae.SelectedIndex = -1;

            comboBox_Kokyaku_Namae.DisplayMember = "ClName";
            comboBox_Kokyaku_Namae.ValueMember = "ClID";
            comboBox_Kokyaku_Namae.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku_Namae.SelectedIndex = -1;

            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }



        private void SetDataGridView(List<DispChumonDTO> tb)
        {
            dataGridView1.DataSource = tb;
            DataGridViewState = 1;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー文字位置、セル文字位置、列幅の設定
            dataGridView1.TopLeftHeaderCell.Value = "";
            //注文ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;

            //注文詳細ID
            dataGridView1.Columns[1].Visible = false;

            //商品ID(非表示)
            dataGridView1.Columns[2].Visible = false;

            //商品名
            dataGridView1.Columns[3].Visible = false;

            //数量
            dataGridView1.Columns[4].Visible = false;

            //営業所ID(非表示)
            dataGridView1.Columns[5].Visible = false;

            //営業所名
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 150;

            //社員ID(非表示)
            dataGridView1.Columns[7].Visible = false;

            //社員名
            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 120;

            //顧客ID(非表示)
            dataGridView1.Columns[9].Visible = false;

            //顧客名
            dataGridView1.Columns[10].Visible = true;
            dataGridView1.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].Width = 80;

            //受注ID
            dataGridView1.Columns[11].Visible = true;
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 30;

            //注文年月日
            dataGridView1.Columns[12].Visible = true;
            dataGridView1.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].Width = 90;

            //注文状態フラグ
            dataGridView1.Columns[13].Visible = true;
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 80;

            //注文管理フラグ(非表示)
            dataGridView1.Columns[14].Visible = false;

            //非表示理由(非表示)
            dataGridView1.Columns[15].Visible = false;
        }

        private void SetDetailDataGridView(List<DispChumonDTO> tb)
        {
            dataGridView1.DataSource = tb;
            DataGridViewState = 2;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー文字位置、セル文字位置、列幅の設定
            dataGridView1.TopLeftHeaderCell.Value = "戻る";

            //注文ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;

            //注文詳細ID
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 45;

            //商品ID(非表示)
            dataGridView1.Columns[2].Visible = false;

            //商品名
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 80;

            //数量
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].Width = 100;

            //営業所ID(非表示)
            dataGridView1.Columns[5].Visible = false;

            //営業所名
            dataGridView1.Columns[6].Visible = false;

            //社員ID(非表示)
            dataGridView1.Columns[7].Visible = false;

            //社員名
            dataGridView1.Columns[8].Visible = false;

            //顧客ID(非表示)
            dataGridView1.Columns[9].Visible = false;

            //顧客名
            dataGridView1.Columns[10].Visible = false;

            //受注ID
            dataGridView1.Columns[11].Visible = false;

            //注文年月日
            dataGridView1.Columns[12].Visible = false;

            //注文状態フラグ
            dataGridView1.Columns[13].Visible = false;

            //注文管理フラグ(非表示)
            dataGridView1.Columns[14].Visible = false;

            //非表示理由(非表示)
            dataGridView1.Columns[15].Visible = false;
        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
            cmbclia();
        }

        private void button_Itirannhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplayChumon();
        }

        private void ListDisplayChumon()
        {
            //変数の宣言
            List<DispChumonDTO> chumon = new List<DispChumonDTO>();
            List<DispChumonDTO> sortedchumon = new List<DispChumonDTO>();

            //データの受け取り
            chumon = GetTableData();

            //グループ化
            chumon = GetDataGridViewData(chumon);

            //昇順に並び変え
            sortedchumon = SortChumonDate(chumon);

            //データグリッドビューに表示
            SetDataGridView(sortedchumon);
        }

        private List<DispChumonDTO> GetTableData()
        {
            //変数の宣言
            List<DispChumonDTO> chumon = new List<DispChumonDTO>();

            //インスタンス化
            ChumonDataAccess chAccess = new ChumonDataAccess();

            //データベースからデータを取得
            chumon = chAccess.GetChumonData(checkbox_stateflag);

            return chumon;
        }

        private List<DispChumonDTO> SortChumonDate(List<DispChumonDTO> dispchumons)
        {
            //並び変え(昇順)
            dispchumons.OrderBy(x => x.ChID);
            return dispchumons;
        }

        private void button_Kensaku_Click(object sender, EventArgs e)
        {
            SelectChumon();
        }

        private void SelectChumon()
        {
            //変数の宣言
            DispChumonDTO chumonDTO = new DispChumonDTO();
            List<DispChumonDTO> DisplayChumon = new List<DispChumonDTO>();

            //データの読み取り
            chumonDTO = GetChumonInf();

            //データの検索
            DisplayChumon = SelectChumonInf(chumonDTO);

            //データグリッドビューに表示
            SetDataGridView(DisplayChumon);
        }

        private DispChumonDTO GetChumonInf()
        {
            //変数の宣言
            DispChumonDTO retChumonDTO = new DispChumonDTO();

            //各コントロールから情報を読み取る
            retChumonDTO.ChID = textbox_Tyuumon_ID.Text.Trim();//注文ID

            if (!(comboBox_Syouhin_Namae.SelectedIndex == -1))
                retChumonDTO.PrID = comboBox_Syouhin_Namae.SelectedValue.ToString();//商品ID

            retChumonDTO.PrName = comboBox_Syouhin_Namae.Text.Trim();//商品名

            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retChumonDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所ID

            retChumonDTO.SoName = comboBox_Eigyousyo.Text;//営業所名

            retChumonDTO.ChDetailID = textbox_Tyuumonsyousai_ID.Text.Trim();//注文詳細ID

            retChumonDTO.OrID = textbox_Tyuumonsyousai_ID.Text.Trim();//受注ID

            retChumonDTO.ClName = comboBox_Kokyaku_Namae.Text;//顧客名

            if (!(comboBox_Syain_Namae.SelectedIndex == -1))
                retChumonDTO.EmID = comboBox_Syain_Namae.SelectedValue.ToString();//社員ID

            retChumonDTO.EmName = comboBox_Syain_Namae.Text.Trim();//社員名

            //retChumonDTO.ChDate = dateTimePicker_Tyuumon_Nenngetu.Value;//注文年月日

            retChumonDTO.ChQuantity = numericUPDown_Syouhin_Namae.Value.ToString();//数量

            if (checkBox_Kakutei.Checked == true)
                retChumonDTO.ChStateFlag = "1"; //確定済み
            else
                retChumonDTO.ChStateFlag = "0";

            return retChumonDTO;
        }

        private List<DispChumonDTO> SelectChumonInf(DispChumonDTO ChumonDTO)
        {
            //変数の宣言
            List<DispChumonDTO> retDispChumon = new List<DispChumonDTO>();

            //インスタンス化
            ChumonDataAccess access = new ChumonDataAccess();

            //注文情報検索
            retDispChumon = access.GetChumonData(ChumonDTO);

            //データグリッドビューに表示できるように変換
            retDispChumon = GetDataGridViewData(retDispChumon);

            return retDispChumon;
        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveChumon();
        }

        private void RemoveChumon()
        {
            //変数宣言
            string ChID;
            T_Chumon Chumon = new T_Chumon();
            T_ChumonDetail ChumonDetail = new T_ChumonDetail();

            //データグリッドビューに表示されているデータの注文IDを受け取る
            ChID = GetChumonRecode();
            if (ChID == null)
            {
                return;
            }


            //取得した注文IDでデータベースを検索する
            Chumon = SelectRemoveChumon(ChID);
            if (Chumon == null)
            {
                return;
            }

            //注文フラグを0から2へ変更する
            UpdateChFlag(Chumon);
        }

        private string GetChumonRecode()
        {
            //変数の宣言
            string retChumonID;

            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から削除対象を選択してください", "エラー", MessageBoxIcon.Error);

                return null;
            }

            retChumonID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            return retChumonID;
        }

        private T_Chumon SelectRemoveChumon(string ChID)
        {
            //変数の宣言
            T_Chumon retchumon = new T_Chumon();
            DispChumonDTO dispChumonDTO = new DispChumonDTO();
            List<DispChumonDTO> dispChumons = new List<DispChumonDTO>();

            //データベースからデータを取得する
            dispChumons = GetTableData();
            if (dispChumons == null)
            {
                messageDsp.MessageBoxDsp_OK("注文情報を取得できませんでした", "エラー", MessageBoxIcon.Error);

                return null;
            }

            //LIstの中を受け取った注文IDで検索
            dispChumonDTO = dispChumons.First(x => x.ChID == ChID);

            //検索結果を返却用にする
            retchumon = FormalizationChumonInputRecord(dispChumonDTO);

            return retchumon;
        }

        private T_Chumon FormalizationChumonInputRecord(DispChumonDTO dispChumonDTO)
        {
            T_Chumon retchumon = new T_Chumon();

            retchumon.ChID = int.Parse(dispChumonDTO.ChID);
            retchumon.SoID = int.Parse(dispChumonDTO.SoID);
            if (dispChumonDTO.EmID != "")
            {
                retchumon.EmID = int.Parse(dispChumonDTO.EmID);
            }
            retchumon.ClID = int.Parse(dispChumonDTO.ClID);
            retchumon.OrID = int.Parse(dispChumonDTO.OrID);
            retchumon.ChDate = dispChumonDTO.ChDate;
            retchumon.ChStateFlag = int.Parse(dispChumonDTO.ChStateFlag);
            retchumon.ChFlag = int.Parse(dispChumonDTO.ChFlag);
            retchumon.ChHidden = dispChumonDTO.ChHidden;

            return retchumon;
        }

        private T_ChumonDetail FormalizationChumonDetailRecord(DispChumonDTO dispChumonDTO)
        {
            T_ChumonDetail retchumonDetail = new T_ChumonDetail();

            retchumonDetail.ChDetailID = int.Parse(dispChumonDTO.ChDetailID);
            retchumonDetail.ChID = int.Parse(dispChumonDTO.ChID);
            retchumonDetail.PrID = int.Parse(dispChumonDTO.PrID);
            retchumonDetail.ChQuantity = int.Parse(dispChumonDTO.ChQuantity);

            return retchumonDetail;
        }

        private void UpdateChFlag(T_Chumon chumon)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示の実行
            result = messageDsp.MessageBoxDsp_OKCancel("非表示にしてよろしいですか", "エラー", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //注文管理フラグの変更
            chumon = ChangeChFlag(chumon);
            if (chumon == null)
            {
                return;
            }

            //注文の更新
            flg = UpdateChumonRecord(chumon);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Chumon ChangeChFlag(T_Chumon chumon)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
                return null;
            }

            chumon.ChFlag = 2;
            chumon.ChHidden = Hidden;

            return chumon;
        }

        private bool UpdateChumonRecord(T_Chumon chumon)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            ChumonDataAccess access = new ChumonDataAccess();
            flg = access.UpdateChumonData(chumon);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }


        private void button_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionChumon();
        }

        private void DecisionChumon()
        {
            //変数の宣言
            string ChID;
            bool flg;
            T_Chumon chumon = new T_Chumon();
            List<T_ChumonDetail> ListChumonDetail = new List<T_ChumonDetail>();
            T_Syukko syukko = new T_Syukko();
            List<T_SyukkoDetail> ListSyukkoDetail = new List<T_SyukkoDetail>();
            DialogResult result;

            //確定対象の注文IDを取得
            ChID = GetChumonRecode();

            //注文IDから注文情報を取得
            chumon = GetChumonAndChDetailRecord(ChID, out ListChumonDetail);
            if (chumon == null)
            {
                return;
            }

            //確定確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の注文を確定してもよろしいですか？", "確定確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //出庫レコードの作成
            flg = RegisrationSyukkoInf(chumon, ListChumonDetail);
            if (!flg)
            {
                return;
            }

            //在庫の数量変更
            flg = SubStQuantity(ListChumonDetail);
            if (!flg)
            {
                return;
            }

            //注文状態フラグの変更
            UpdateChStateFlag(chumon);
        }

        private void UpdateChStateFlag(T_Chumon chumon)
        {
            //変数の宣言
            bool flg;

            //注文状態フラグを0から1にする
            chumon = FormalizationChumonRecord(chumon);

            //注文情報を更新する
            flg = UpdateChumonRecord(chumon);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("注文情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("注文情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private T_Chumon FormalizationChumonRecord(T_Chumon chumon)
        {
            chumon.ChStateFlag = 1;
            chumon.EmID = int.Parse(loginEmployee.EmID);
            return chumon;
        }

        private bool RegisrationSyukkoInf(T_Chumon chumon, List<T_ChumonDetail> listChumonDetail)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Syukko syukko;
            List<T_SyukkoDetail> ListSyukkoDetail;

            //出庫と出庫詳細のレコードを作成
            syukko = CreateSyukkoRecord(chumon, listChumonDetail, out ListSyukkoDetail);

            //出庫と出庫詳細の情報を登録
            flg = RegisrationSyukkoRecord(syukko, ListSyukkoDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;
        }

        private bool RegisrationSyukkoRecord(T_Syukko syukko, List<T_SyukkoDetail> listSyukkoDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            //インスタンス化
            SyukkoDataAccess access = new SyukkoDataAccess();
            flg = access.RegisterSyukkoData(syukko, listSyukkoDetail);

            if (!flg)
            {
                msg = "出庫情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;
        }

        private T_Syukko CreateSyukkoRecord(T_Chumon chumon, List<T_ChumonDetail> listChumonDetail, out List<T_SyukkoDetail> listSyukkoDetail)
        {
            //変数の宣言
            T_Syukko syukko = new T_Syukko();
            //初期値代入
            listSyukkoDetail = new List<T_SyukkoDetail>();

            //出庫レコードの作成
            syukko.SoID = chumon.SoID;
            syukko.EmID = null;
            syukko.ClID = chumon.ClID;
            syukko.OrID = chumon.OrID;
            syukko.SyDate = null;
            syukko.SyFlag = 0;
            syukko.SyStateFlag = 0;
            syukko.SyHidden = null;

            //出庫詳細レコードの作成
            foreach (var chumondetail in listChumonDetail)
            {
                T_SyukkoDetail syukkodetail = new T_SyukkoDetail();
                syukkodetail.PrID = chumondetail.PrID;
                syukkodetail.SyQuantity = chumondetail.ChQuantity;
                listSyukkoDetail.Add(syukkodetail);
            }

            return syukko;

        }

        private bool SubStQuantity(List<T_ChumonDetail> ListChumonDetail)
        {
            //変数の宣言
            string msg;
            string title;
            MessageBoxIcon icon;
            bool flg;
            List<T_Stock> ListStock = new List<T_Stock>();

            //注文詳細に存在する商品の在庫情報を受け取る
            ListStock = GetStockRecord(ListChumonDetail, out msg, out title, out icon);
            if (ListStock == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }
            //在庫数を注文数分減らす
            ListStock = SubStockRecord(ListStock, ListChumonDetail, out msg, out title, out icon);
            if (ListStock == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }
            //在庫登録
            flg = UpdateStockRecord(ListStock, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;
        }

        private bool UpdateStockRecord(List<T_Stock> listStock, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;
            //インスタンス化
            StockDataAccess access = new StockDataAccess();
            //初期値
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //変更した在庫数で更新
            foreach (var upStock in listStock)
            {
                flg = access.UpdateStockData(upStock);
                if (!flg)
                {
                    msg = "在庫の更新に失敗しました";
                    title = "エラー";
                    return false;
                }
            }

            return true;
        }

        private List<T_Stock> SubStockRecord(List<T_Stock> listStock, List<T_ChumonDetail> listChumonDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<T_Stock> retStock = new List<T_Stock>();
            int Quantity;
            //初期値の代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //在庫数を減らす
            foreach (var Stock in listStock)
            {
                Quantity = Stock.StQuantity - listChumonDetail.Single(x => x.PrID == Stock.PrID).ChQuantity;
                if (Quantity < 0)
                {
                    msg = "在庫数が足りない商品が存在します";
                    title = "在庫不足";
                    return null;
                }
                Stock.StQuantity = Quantity;
                retStock.Add(Stock);
            }

            return retStock;
        }

        private List<T_Stock> GetStockRecord(List<T_ChumonDetail> ListChumonDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispStockDTO> ListDispStockDTO = new List<DispStockDTO>();
            List<T_Stock> retListStock = new List<T_Stock>();
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //インスタンス化
            StockDataAccess access = new StockDataAccess();

            //データベースから在庫テーブルのデータを取得
            ListDispStockDTO = access.GetStockData().Where(x => ListChumonDetail.Any(y => y.PrID.ToString() == x.PrID)).ToList();
            if (ListDispStockDTO == null)
            {
                msg = "在庫情報を取得できませんでした";
                title = "エラー";
                return null;
            }

            //表示用からテーブル形式に変換
            foreach (var stock in ListDispStockDTO)
            {
                T_Stock inputStockData = new T_Stock();
                inputStockData.StID = int.Parse(stock.StID);
                inputStockData.PrID = int.Parse(stock.PrID);
                inputStockData.StQuantity = int.Parse(stock.StQuantity);
                inputStockData.StFlag = int.Parse(stock.StFlag);

                retListStock.Add(inputStockData);
            }

            return retListStock;

        }

        private T_Chumon GetChumonAndChDetailRecord(string chID, out List<T_ChumonDetail> ListChumonDetail)
        {
            //変数の宣言
            List<DispChumonDTO> chumonDTO = new List<DispChumonDTO>();
            T_Chumon retchumon = new T_Chumon();
            string msg;
            string title;
            MessageBoxIcon icon;
            //初期値代入
            ListChumonDetail = new List<T_ChumonDetail>();

            //注文情報取得
            chumonDTO = CreateChumonRecord(chID, out msg, out title, out icon);
            if (chumonDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }

            //注文情報をテーブルデータに形式化
            retchumon = FormalizationChumonInputRecord(chumonDTO[0]);
            //注文詳細情報をテーブルデータに形式化
            foreach (var AddChumonDTO in chumonDTO)
            {
                ListChumonDetail.Add(FormalizationChumonDetailRecord(AddChumonDTO));
            }

            return retchumon;
        }

        private List<DispChumonDTO> CreateChumonRecord(string chID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispChumonDTO> ListDispChumon = new List<DispChumonDTO>();
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //注文IDの一致する注文情報を取得
            ListDispChumon = GetTableData().Where(x => x.ChID == chID).ToList();
            if (ListDispChumon == null || ListDispChumon.Count == 0)
            {
                msg = "注文情報を取得できませんでした";
                title = "エラー";
                return null;
            }
            if (ListDispChumon[0].ChStateFlag == "1")
            {
                msg = "既に確定済みです";
                title = "エラー";
                return null;
            }

            return ListDispChumon;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewState == 1)
            {
                textbox_Tyuumon_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                comboBox_Kokyaku_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value != null)
                    comboBox_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
                dateTimePicker_Tyuumon_Nenngetu.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString());
                string ChID;
                ChID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                GetSelectDetailData(ChID);
            }
            else
            {
                if ((e.ColumnIndex == -1) && (e.RowIndex == -1))
                {
                    GetSelectData();
                }
                else
                {
                    textbox_Zyutyuusyousai.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    comboBox_Syouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    textbox_Tyuumonsyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    dateTimePicker_Tyuumon_Nenngetu.Value = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString());
                    numericUPDown_Syouhin_Namae.Value = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
                }
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label8.ForeColor = Color.LightGray;
            dateTimePicker_Tyuumon_Nenngetu.Enabled = false;
            dateTimePicker_Tyuumon_Nenngetu.CalendarTitleBackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            numericUPDown_Syouhin_Namae.Enabled = false;
            numericUPDown_Syouhin_Namae.BackColor = Color.LightGray;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textbox_Tyuumon_ID.Enabled = false;
            textbox_Tyuumon_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            comboBox_Syouhin_Namae.Enabled = false;
            comboBox_Syouhin_Namae.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            comboBox_Eigyousyo.Enabled = false;
            comboBox_Eigyousyo.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            textbox_Tyuumonsyousai_ID.Enabled = false;
            textbox_Tyuumonsyousai_ID.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textbox_Zyutyuusyousai.Enabled = false;
            textbox_Zyutyuusyousai.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            comboBox_Kokyaku_Namae.Enabled = false;
            comboBox_Kokyaku_Namae.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            comboBox_Syain_Namae.Enabled = false;
            comboBox_Syain_Namae.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            dateTimePicker_Tyuumon_Nenngetu.Enabled = false;
            dateTimePicker_Tyuumon_Nenngetu.CalendarTitleBackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            numericUPDown_Syouhin_Namae.Enabled = false;
            numericUPDown_Syouhin_Namae.BackColor = Color.LightGray;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textbox_Tyuumon_ID.Enabled = false;
            textbox_Tyuumon_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            comboBox_Syouhin_Namae.Enabled = false;
            comboBox_Syouhin_Namae.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            comboBox_Eigyousyo.Enabled = false;
            comboBox_Eigyousyo.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            textbox_Tyuumonsyousai_ID.Enabled = false;
            textbox_Tyuumonsyousai_ID.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textbox_Zyutyuusyousai.Enabled = false;
            textbox_Zyutyuusyousai.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            comboBox_Kokyaku_Namae.Enabled = false;
            comboBox_Kokyaku_Namae.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            comboBox_Syain_Namae.Enabled = false;
            comboBox_Syain_Namae.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            dateTimePicker_Tyuumon_Nenngetu.Enabled = false;
            dateTimePicker_Tyuumon_Nenngetu.CalendarTitleBackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            numericUPDown_Syouhin_Namae.Enabled = false;
            numericUPDown_Syouhin_Namae.BackColor = Color.LightGray;
        }

        private void cmbclia()
        {
            label1.ForeColor = Color.Black;
            textbox_Tyuumon_ID.Enabled = true;
            textbox_Tyuumon_ID.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            comboBox_Syouhin_Namae.Enabled = true;
            comboBox_Syouhin_Namae.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            comboBox_Eigyousyo.Enabled = true;
            comboBox_Eigyousyo.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            textbox_Tyuumonsyousai_ID.Enabled = true;
            textbox_Tyuumonsyousai_ID.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            textbox_Zyutyuusyousai.Enabled = true;
            textbox_Zyutyuusyousai.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            comboBox_Kokyaku_Namae.Enabled = true;
            comboBox_Kokyaku_Namae.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            comboBox_Syain_Namae.Enabled = true;
            comboBox_Syain_Namae.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            dateTimePicker_Tyuumon_Nenngetu.Enabled = true;
            dateTimePicker_Tyuumon_Nenngetu.CalendarTitleBackColor = Color.White;
            label9.ForeColor = Color.Black;
            numericUPDown_Syouhin_Namae.Enabled = true;
            numericUPDown_Syouhin_Namae.BackColor = Color.White;
        }

        private void checkBox_Kakutei_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Kakutei.Checked == true)
            {
                checkbox_stateflag = 1;
            }
            else
            {
                checkbox_stateflag = 0;
            }
            GetSelectData();
        }
    }
}
