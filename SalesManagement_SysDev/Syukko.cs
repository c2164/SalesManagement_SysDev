﻿using SalesManagement_SysDev.Common;
using SalesManagement_SysDev.CommonMethod;
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
    public partial class Syukko : UserControl
    {
        private MessageDsp messageDsp = new MessageDsp();
        private DispEmplyeeDTO loginEmployee;
        private int DataGridViewState;
        private int checkbox_stateflag = 0;
        public Syukko(DispEmplyeeDTO emplyeeDTO)
        {
            InitializeComponent();
            loginEmployee = emplyeeDTO;
        }

        private void Syukko_load(object sender, EventArgs e)
        {
            //各コントロールの初期設定
            SetCtrlFormat();

            //データの取得
            if (!GetSelectData())
            {
                messageDsp.MessageBoxDsp_OK("出庫情報が獲得できませんでした", "エラー", MessageBoxIcon.Error);
                return;
            }
        }

        private bool GetSelectData()
        {
            SyukkoDataAccess access = new SyukkoDataAccess();
            //入庫情報の全件取得
            List<DispSyukkoDTO> tb = access.GetSyukkoData(checkbox_stateflag);
            List<DispSyukkoDTO> disptb = new List<DispSyukkoDTO>();
            if (tb == null)
                return false;
            //データグリッドビューへの設定
            disptb = GetDataGridViewData(tb);

            SetDataGridView(disptb);
            return true;
        }

        private List<DispSyukkoDTO> GetDataGridViewData(List<DispSyukkoDTO> tb)
        {
            List<DispSyukkoDTO> disptb = new List<DispSyukkoDTO>();
            var grouptb = tb.GroupBy(x => x.ChID).ToList();
            foreach (var groupingsyukkotb in grouptb)
            {
                foreach (var syukkotb in groupingsyukkotb)
                {
                    DispSyukkoDTO syukkoDTO = new DispSyukkoDTO();
                    syukkoDTO.SyID = syukkotb.SyID;
                    syukkoDTO.SoID = syukkotb.SoID;
                    syukkoDTO.SoName = syukkotb.SoName;
                    syukkoDTO.ChumonEmID = syukkotb.ChumonEmID;
                    syukkoDTO.ChumonEmName = syukkotb.ChumonEmName;
                    syukkoDTO.ConfEmID = syukkotb.ConfEmID;
                    syukkoDTO.ConfEmName = syukkotb.ConfEmName;
                    syukkoDTO.ClID = syukkotb.ClID;
                    syukkoDTO.ClName = syukkotb.ClName;
                    syukkoDTO.ChID = syukkotb.ChID;
                    syukkoDTO.OrID = syukkotb.OrID;
                    syukkoDTO.SyDate = syukkotb.SyDate;
                    if (syukkotb.SyStateFlag == "1")
                    {
                        syukkoDTO.SyStateFlag = "済";
                    }
                    else
                    {
                        syukkoDTO.SyStateFlag = "未";
                    }
                    syukkoDTO.SyFlag = syukkotb.SyFlag;
                    syukkoDTO.SyHidden = syukkotb.SyHidden;

                    disptb.Add(syukkoDTO);
                    break;
                }
            }
            return disptb;
        }

        private bool GetSelectDetailData(string SyID)
        {
            SyukkoDataAccess access = new SyukkoDataAccess();
            DispSyukkoDTO dispOrder = new DispSyukkoDTO()
            {
                SyID = SyID,
                ChumonEmName = "",
                OrID = "",
                ClName = "",
                ConfEmName = "",
                SyDetailID = "",
                MaName = "",
                SoName = "",
                PrName = "",
                SyStateFlag = checkbox_stateflag.ToString()
            };
            //出荷情報の全件取得
            List<DispSyukkoDTO> tb = access.GetSyukkoData(dispOrder);

            if (tb == null)
                return false;
            //データグリッドビューへの設定
            SetDetailDataGridView(tb);
            return true;
        }

        private void SetCtrlFormat()
        {
            SalesOfficeDataAccess salesOfficeDataAccess = new SalesOfficeDataAccess();
            MakerDateAccess makerDateAccess = new MakerDateAccess();
            ProductDataAccess productDataAccess = new ProductDataAccess();
            ClientDataAccess clientDataAccess = new ClientDataAccess();
            //各テキストボックスに初期化(空白)
            textBox_Kakutei_Syain_Namae.Text = "";
            textBox_Syain.Text = "";
            textBox_Syukkosyousai_ID.Text = "";
            textBox_Zyutyuu_ID.Text = "";
            textBox_Syukko_ID.Text = "";


            //各コンボボックスを初期化
            comboBox_Eigyousyo.DisplayMember = "SoName";
            comboBox_Eigyousyo.ValueMember = "SoID";
            comboBox_Eigyousyo.DataSource = salesOfficeDataAccess.GetSalesOfficeData();
            comboBox_Eigyousyo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Eigyousyo.SelectedIndex = -1;

            comboBox_Kokyaku.DisplayMember = "ClName";
            comboBox_Kokyaku.ValueMember = "ClID";
            comboBox_Kokyaku.DataSource = clientDataAccess.GetClientData();
            comboBox_Kokyaku.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Kokyaku.SelectedIndex = -1;

            comboBox_Meka_Namae.DisplayMember = "MaName";
            comboBox_Meka_Namae.ValueMember = "MaID";
            comboBox_Meka_Namae.DataSource = makerDateAccess.GetMakerData();
            comboBox_Meka_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Meka_Namae.SelectedIndex = -1;

            comboBoxSyouhin_Namae.DisplayMember = "PrName";
            comboBoxSyouhin_Namae.ValueMember = "PrID";
            comboBoxSyouhin_Namae.DataSource = productDataAccess.GetProductData();
            comboBoxSyouhin_Namae.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSyouhin_Namae.SelectedIndex = -1;

            //数量の初期化
            domainUpDown_Suuryou.Value = 0;

            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void SetDataGridView(List<DispSyukkoDTO> tb)
        {
            dataGridView1.DataSource = tb;
            DataGridViewState = 1;
            //列幅自動設定解除
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //ヘッダーの高さ
            dataGridView1.ColumnHeadersHeight = 50;
            //ヘッダーの折り返し表示
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //行単位選択
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //ヘッダー文字位置、セル文字位置、列幅の設定
            dataGridView1.TopLeftHeaderCell.Value = "";
            //出庫ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //出庫詳細ID
            dataGridView1.Columns[1].Visible = false;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].Visible = false;
            //数量
            dataGridView1.Columns[4].Visible = false;
            //営業所ID
            dataGridView1.Columns[5].Visible = false;
            //営業所名
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].Width = 80;
            //顧客ID
            dataGridView1.Columns[7].Visible = false;
            //顧客名
            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].Width = 80;
            //注文ID
            dataGridView1.Columns[9].Visible = true;
            dataGridView1.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].Width = 30;
            //注文社員ID
            dataGridView1.Columns[10].Visible = false;
            //注文社員名
            dataGridView1.Columns[11].Visible = true;
            dataGridView1.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].Width = 103;
            //確定社員ID
            dataGridView1.Columns[12].Visible = false;
            //確定社員名
            dataGridView1.Columns[13].Visible = true;
            dataGridView1.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[13].Width = 103;
            //確定社員ID
            dataGridView1.Columns[14].Visible = false;
            //メーカー名
            dataGridView1.Columns[15].Visible = false;
            //受注ID
            dataGridView1.Columns[16].Visible = true;
            dataGridView1.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[16].Width = 30;
            //確定社員ID
            dataGridView1.Columns[17].Visible = false;
            //出庫年月日
            dataGridView1.Columns[18].Visible = true;
            dataGridView1.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[18].Width = 90;
            //出庫状態フラグ
            dataGridView1.Columns[19].Visible = true;
            dataGridView1.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[19].Width = 80;
            //出庫管理フラグ(非表示)
            dataGridView1.Columns[20].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[21].Visible = false;

        }

        private void SetDetailDataGridView(List<DispSyukkoDTO> tb)
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
            //出庫ID
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].Width = 30;
            //出庫詳細ID
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[1].Width = 45;
            //商品ID
            dataGridView1.Columns[2].Visible = false;
            //商品名
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].Width = 120;
            //数量
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[4].Width = 100;
            //営業所ID
            dataGridView1.Columns[5].Visible = false;
            //営業所名
            dataGridView1.Columns[6].Visible = false;
            //顧客ID
            dataGridView1.Columns[7].Visible = false;
            //顧客名
            dataGridView1.Columns[8].Visible = false;
            //注文ID
            dataGridView1.Columns[9].Visible = false;
            //注文社員ID
            dataGridView1.Columns[10].Visible = false;
            //注文社員名
            dataGridView1.Columns[11].Visible = false;
            //確定社員ID
            dataGridView1.Columns[12].Visible = false;
            //確定社員名
            dataGridView1.Columns[13].Visible = false;
            //確定社員ID
            dataGridView1.Columns[14].Visible = false;
            //メーカー名
            dataGridView1.Columns[15].Visible = true;
            dataGridView1.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].Width = 120;
            //受注ID
            dataGridView1.Columns[16].Visible = false;
            //確定社員ID
            dataGridView1.Columns[17].Visible = false;
            //出庫年月日
            dataGridView1.Columns[18].Visible = false;
            //出庫状態フラグ
            dataGridView1.Columns[19].Visible = false;
            //出庫管理フラグ(非表示)
            dataGridView1.Columns[20].Visible = false;
            //非表示理由(非表示)
            dataGridView1.Columns[21].Visible = false;

        }

        private void button_Kuria_Click(object sender, EventArgs e)
        {
            GetSelectData();
            SetCtrlFormat();
            cmbclia();
        }

        private void button_Itiranhyouzi_Click(object sender, EventArgs e)
        {
            ListDisplaySyukko();
        }

        private void ListDisplaySyukko()
        {
            //変数の宣言
            List<DispSyukkoDTO> syukko = new List<DispSyukkoDTO>();
            List<DispSyukkoDTO> sortedsyukko = new List<DispSyukkoDTO>();

            //テーブルデータ受け取り
            syukko = GetTableData();

            //グループ化
            syukko = GetDataGridViewData(syukko);

            //昇順に並び替える
            sortedsyukko = SortSyukkoData(syukko);

            //データグリッドビュー表示
            SetDataGridView(sortedsyukko);

        }

        private List<DispSyukkoDTO> GetTableData()
        {
            //変数の宣言
            List<DispSyukkoDTO> syukko = new List<DispSyukkoDTO>();

            //インスタンス化
            SyukkoDataAccess SyAccess = new SyukkoDataAccess();

            //データベースからデータを取得
            syukko = SyAccess.GetSyukkoData(checkbox_stateflag);


            return syukko;
        }

        private List<DispSyukkoDTO> SortSyukkoData(List<DispSyukkoDTO> dispSyukkos)
        {
            //並び替え(昇順)
            dispSyukkos.OrderBy(x => x.SyID);
            return dispSyukkos;
        }

        private void button_Kennsaku_Click(object sender, EventArgs e)
        {
            SelectSyukko();
        }

        private void SelectSyukko()
        {

            //変数の宣言
            DispSyukkoDTO syukkoDTO = new DispSyukkoDTO();
            List<DispSyukkoDTO> DisplaySyukko = new List<DispSyukkoDTO>();

            //データ読み取り
            syukkoDTO = GetSyukkoInf();
            //データの検索
            DisplaySyukko = SelectSyukkoInf(syukkoDTO);
            //データグリッドビューに表示
            SetDataGridView(DisplaySyukko);
        }


        private DispSyukkoDTO GetSyukkoInf()
        {
            //変数の宣言
            DispSyukkoDTO retSyukkoDTO = new DispSyukkoDTO();

            //各コントロールから出庫情報を読み取る
            retSyukkoDTO.SyID = textBox_Syukko_ID.Text.ToString().Trim();//出庫ID
            if (!(comboBox_Eigyousyo.SelectedIndex == -1))
                retSyukkoDTO.SoID = comboBox_Eigyousyo.SelectedValue.ToString();//営業所ID
            retSyukkoDTO.SoName = comboBox_Eigyousyo.Text.Trim();//営業所名
            retSyukkoDTO.ChumonEmName = textBox_Syain.Text.Trim();//注文社員名
            if (!(comboBox_Kokyaku.SelectedIndex == -1))
                retSyukkoDTO.ClID = comboBox_Kokyaku.SelectedValue.ToString();//顧客ID
            retSyukkoDTO.ClName = comboBox_Kokyaku.Text.Trim();//顧客名
            retSyukkoDTO.OrID = textBox_Zyutyuu_ID.Text.Trim();//受注ID
            retSyukkoDTO.ConfEmName = textBox_Kakutei_Syain_Namae.Text.Trim();//確定社員名
            retSyukkoDTO.SyDetailID = textBox_Syukkosyousai_ID.Text.Trim();//出庫詳細ID
            if (!(comboBox_Meka_Namae.SelectedIndex == -1))
                retSyukkoDTO.MaID = comboBox_Meka_Namae.SelectedValue.ToString();//メーカーID
            retSyukkoDTO.MaName = comboBox_Meka_Namae.Text.Trim();//メーカー名
            if (!(comboBoxSyouhin_Namae.SelectedIndex == -1))
                retSyukkoDTO.PrID = comboBoxSyouhin_Namae.SelectedValue.ToString();//商品ID
            retSyukkoDTO.PrName = comboBoxSyouhin_Namae.Text.Trim();//商品名
            retSyukkoDTO.SyQuantity = domainUpDown_Suuryou.Value.ToString();//数量
            retSyukkoDTO.SyStateFlag = checkbox_stateflag.ToString();


            return retSyukkoDTO;
        }

        private List<DispSyukkoDTO> SelectSyukkoInf(DispSyukkoDTO syukkoDTO)
        {
            //変数の宣言
            List<DispSyukkoDTO> retDispSyukko = new List<DispSyukkoDTO>();
            //インスタンス化
            SyukkoDataAccess access = new SyukkoDataAccess();
            //出庫情報検索
            retDispSyukko = access.GetSyukkoData(syukkoDTO);
            //データグリッドビューに表示できるように変換
            retDispSyukko = GetDataGridViewData(retDispSyukko);

            return retDispSyukko;



        }

        private void button_Sakuzyo_Click(object sender, EventArgs e)
        {
            RemoveSyukko();
        }

        private void RemoveSyukko()
        {
            //変数の宣言
            string SyID;
            T_Syukko syukko = new T_Syukko();
            //データグリッドビューで選択されているデータの出庫IDを受け取る
            SyID = GetSyukkoRecord();
            if (SyID == null)
            {
                return;
            }

            //取得した出庫IDでデータベースを検索する
            syukko = SelectRemoveSyukko(SyID);
            if (syukko == null)
            {
                return;
            }

            //出庫管理フラグを0から2にする
            UpdateSyFlag(syukko);
        }

        private void UpdateSyFlag(T_Syukko syukko)
        {
            //変数の宣言
            DialogResult result;
            bool flg;

            //非表示実行確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の出庫情報を非表示にしてよろしいですか", "確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //出庫管理フラグの変更
            syukko = ChangeSyFlag(syukko);
            if (syukko == null)
            {
                return;
            }
            //出庫の更新
            flg = UpdateSyukkoRecord(syukko);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("対象出庫情報を非表示にしました", "非表示完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("対象出庫情報の非表示に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }

        private bool UpdateSyukkoRecord(T_Syukko syukko)
        {
            //変数の宣言
            bool flg;

            //データベース接続のインスタンス化
            SyukkoDataAccess access = new SyukkoDataAccess();
            flg = access.UpdateSyukkoData(syukko);

            SetCtrlFormat();
            GetSelectData();

            return flg;
        }

        private T_Syukko ChangeSyFlag(T_Syukko syukko)
        {
            string Hidden;
            Hidden = Microsoft.VisualBasic.Interaction.InputBox("非表示理由を入力してください", "非表示理由", "", -1, -1).Trim();
            if (string.IsNullOrEmpty(Hidden))
            {
                messageDsp.MessageBoxDsp_OK("非表示を中断します", "中断", MessageBoxIcon.Information);
            }
            syukko.SyFlag = 2;
            syukko.SyHidden = Hidden;
            return syukko;
        }

        private T_Syukko SelectRemoveSyukko(string SyID)
        {
            //変数の宣言
            T_Syukko retsyukko = new T_Syukko();
            DispSyukkoDTO dispSyukkoDTO = new DispSyukkoDTO();
            List<DispSyukkoDTO> dispSyukkos = new List<DispSyukkoDTO>();
            //データベースからデータを取得する
            dispSyukkos = GetTableData();
            if (dispSyukkos == null) //データの取得失敗
            {
                messageDsp.MessageBoxDsp_OK("出庫情報を受け取ることができませんでした", "エラー", MessageBoxIcon.Error);
                return null;
            }

            //Listの中を受け取った出庫IDで検索
            dispSyukkoDTO = dispSyukkos.First(x => x.SyID == SyID);

            //検索結果を返却用にする
            retsyukko = FormalizationSyukkoInputRecord(dispSyukkoDTO);

            return retsyukko;
        }

        private T_Syukko FormalizationSyukkoInputRecord(DispSyukkoDTO dispSyukkoDTO)
        {
            T_Syukko retsyukko = new T_Syukko();
            retsyukko.SyID = int.Parse(dispSyukkoDTO.SyID);
            if (dispSyukkoDTO.ConfEmID != "")
                retsyukko.EmID = int.Parse(dispSyukkoDTO.ConfEmID);
            retsyukko.ClID = int.Parse(dispSyukkoDTO.ClID);
            retsyukko.SoID = int.Parse(dispSyukkoDTO.SoID);
            retsyukko.OrID = int.Parse(dispSyukkoDTO.OrID);
            retsyukko.SyDate = dispSyukkoDTO.SyDate;
            retsyukko.SyStateFlag = int.Parse(dispSyukkoDTO.SyStateFlag);
            retsyukko.SyFlag = int.Parse(dispSyukkoDTO.SyFlag);
            retsyukko.SyHidden = dispSyukkoDTO.SyHidden;
            return retsyukko;
        }

        private T_SyukkoDetail FormalizationSyukkoDetailInputRecord(DispSyukkoDTO dispSyukkoDetailDTO)
        {
            T_SyukkoDetail retsyukkodetail = new T_SyukkoDetail();
            retsyukkodetail.SyDetailID = int.Parse(dispSyukkoDetailDTO.SyDetailID);
            retsyukkodetail.SyID = int.Parse(dispSyukkoDetailDTO.SyID);
            retsyukkodetail.PrID = int.Parse(dispSyukkoDetailDTO.PrID);
            retsyukkodetail.SyQuantity = int.Parse(dispSyukkoDetailDTO.SyQuantity);

            return retsyukkodetail;

        }

        private string GetSyukkoRecord()
        {
            //変数の宣言
            string retSyID;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                messageDsp.MessageBoxDsp_OK("表から確定対象を選択してください", "エラー", MessageBoxIcon.Error);
                return null;
            }
            retSyID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            return retSyID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewState == 1)
            {
                textBox_Syukko_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                comboBox_Eigyousyo.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
                textBox_Syain.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
                comboBox_Kokyaku.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
                textBox_Zyutyuu_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[16].Value.ToString();
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[13].Value == null)
                {
                    textBox_Kakutei_Syain_Namae.Text = "";
                }
                else
                {
                    textBox_Kakutei_Syain_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[13].Value.ToString();
                }
                string SyID;
                SyID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                GetSelectDetailData(SyID);
            }
            else
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    if ((e.ColumnIndex == -1) && (e.RowIndex == -1))
                    {
                        GetSelectData();
                    }
                    else
                    {
                        textBox_Syukkosyousai_ID.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                        comboBox_Meka_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[15].Value.ToString();
                        comboBoxSyouhin_Namae.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                        domainUpDown_Suuryou.Value = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
                    }
                }
            }

        }

        private void button_Kakutei_Click(object sender, EventArgs e)
        {
            DecisionSyukko();
        }

        private void DecisionSyukko()
        {
            //変数の宣言
            string SyID;
            bool flg;
            T_Syukko syukko = new T_Syukko();
            List<T_SyukkoDetail> syukkoDetail = new List<T_SyukkoDetail>();
            T_Arrival arrival = new T_Arrival();
            List<T_ArrivalDetail> ListArrival = new List<T_ArrivalDetail>();
            DialogResult result;

            //確定対象の出庫IDを取得
            SyID = GetSyukkoRecord();
            if (SyID == null)
            {
                return;
            }

            //出庫IDから出庫情報を取得
            syukko = GetSyukkoAndSyDetailRecord(SyID, out syukkoDetail);
            if (syukko == null)
            {
                return;
            }

            //確定確認
            result = messageDsp.MessageBoxDsp_OKCancel("対象の注文を確定してもよろしいですか？", "確定確認", MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //注文レコードの登録
            flg = RegisrationArrivalInf(syukko, syukkoDetail);
            if (!flg)
            {
                return;
            }

            //出庫状態フラグの変更
            UpdateSyStateFlag(syukko, syukkoDetail[0]);

        }
        private void UpdateSyStateFlag(T_Syukko syukko, T_SyukkoDetail syukkoDetail)
        {
            //変数の宣言
            bool flg;

            //出庫状態フラグを0から1にする
            syukko = FormalizationSyukkoRecord(syukko);
            //出庫情報を更新する
            flg = UpdateSyukkoRecord(syukko);
            if (flg)
            {
                messageDsp.MessageBoxDsp_OK("出庫情報を確定しました", "確定完了", MessageBoxIcon.Information);
            }
            else
            {
                messageDsp.MessageBoxDsp_OK("出庫情報の確定に失敗しました", "エラー", MessageBoxIcon.Error);
            }
        }
        private T_Syukko FormalizationSyukkoRecord(T_Syukko syukko)
        {
            syukko.EmID = int.Parse(loginEmployee.EmID);
            syukko.SyDate = DateTime.Now;
            syukko.SyStateFlag = 1;
            return syukko;
        }

        private bool RegisrationArrivalInf(T_Syukko syukko, List<T_SyukkoDetail> syukkoDetail)
        {
            //変数の宣言
            bool flg;
            string msg;
            string title;
            MessageBoxIcon icon;
            T_Arrival arrival;
            List<T_ArrivalDetail> ListArrivalDetail;

            //入荷と入荷詳細のレコードを作成
            arrival = CreateArrivalInputRecord(syukko, syukkoDetail, out ListArrivalDetail);

            //入荷と入荷詳細の情報を登録
            flg = RegisrationArrivalRecord(arrival, ListArrivalDetail, out msg, out title, out icon);
            if (!flg)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return false;
            }

            return true;

        }

        private bool RegisrationArrivalRecord(T_Arrival arrival, List<T_ArrivalDetail> ListArrivalDetail, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            bool flg = false;
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;
            //インスタンス化
            ArraivalDataAccess access = new ArraivalDataAccess();
            flg = access.RegisterArrivalsData(arrival, ListArrivalDetail);

            if (!flg)
            {
                msg = "入荷情報の登録中にエラーが発生しました";
                title = "エラー";
                return false;
            }

            return true;

        }

        private T_Syukko GetSyukkoAndSyDetailRecord(string syID, out List<T_SyukkoDetail> ListSyukkoDetail)
        {
            //変数の宣言
            List<DispSyukkoDTO> syukkoDTO = new List<DispSyukkoDTO>();
            T_Syukko syukko = new T_Syukko();
            string msg;
            string title;
            MessageBoxIcon icon;
            //初期値代入
            ListSyukkoDetail = new List<T_SyukkoDetail>();

            //出庫情報取得
            syukkoDTO = CreateSyukkoRecord(syID, out msg, out title, out icon);
            if (syukkoDTO == null)
            {
                messageDsp.MessageBoxDsp_OK(msg, title, icon);
                return null;
            }
            //出庫情報をテーブルデータに形式化
            syukko = FormalizationSyukkoInputRecord(syukkoDTO[0]);
            foreach (var SyukkoDTO in syukkoDTO)
            {
                ListSyukkoDetail.Add(FormalizationSyukkoDetailInputRecord(SyukkoDTO));
            }

            return syukko;


        }
        private T_Arrival CreateArrivalInputRecord(T_Syukko syukko, List<T_SyukkoDetail> ListSyukkoDetail, out List<T_ArrivalDetail> ListarrivalDetail)
        {
            //変数の宣言
            T_Arrival retArrival = new T_Arrival();
            ListarrivalDetail = new List<T_ArrivalDetail>();

            //入荷レコードの作成
            retArrival.OrID = syukko.OrID;
            retArrival.EmID = null;
            retArrival.SoID = syukko.SoID;
            retArrival.ClID = syukko.ClID;
            retArrival.ArDate = DateTime.Now;
            retArrival.ArStateFlag = 0;
            retArrival.ArFlag = 0;
            retArrival.ArHidden = null;

            //入荷詳細レコードの作成
            foreach (var syukkodetail in ListSyukkoDetail)
            {
                T_ArrivalDetail arrivalDetail = new T_ArrivalDetail();
                arrivalDetail.PrID = syukkodetail.PrID;
                arrivalDetail.ArQuantity = syukkodetail.SyQuantity;
                ListarrivalDetail.Add(arrivalDetail);
            }

            return retArrival;
        }

        private List<DispSyukkoDTO> CreateSyukkoRecord(string syID, out string msg, out string title, out MessageBoxIcon icon)
        {
            //変数の宣言
            List<DispSyukkoDTO> DispSyukkos = new List<DispSyukkoDTO>();
            //初期値代入
            msg = "";
            title = "";
            icon = MessageBoxIcon.Error;

            //出庫IDの一致する受注情報を取得
            DispSyukkos = GetTableData().Where(x => x.SyID == syID).ToList();
            if (DispSyukkos == null || DispSyukkos.Count == 0)
            {
                msg = "出庫情報を取得できませんでした";
                title = "エラー";
                return null;
            }
            if (DispSyukkos[0].SyStateFlag == "1")
            {
                msg = "既に確定済みです";
                title = "エラー";
                return null;
            }

            return DispSyukkos;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label10.ForeColor = Color.LightGray;
            domainUpDown_Suuryou.Enabled = false;
            domainUpDown_Suuryou.BackColor = Color.LightGray;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textBox_Syukko_ID.Enabled = false;
            textBox_Syukko_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            comboBox_Eigyousyo.Enabled = false;
            comboBox_Eigyousyo.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            textBox_Syain.Enabled = false;
            textBox_Syain.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            comboBox_Kokyaku.Enabled = false;
            comboBox_Kokyaku.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textBox_Zyutyuu_ID.Enabled = false;
            textBox_Zyutyuu_ID.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            textBox_Kakutei_Syain_Namae.Enabled = false;
            textBox_Kakutei_Syain_Namae.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            textBox_Syukkosyousai_ID.Enabled = false;
            textBox_Syukkosyousai_ID.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            comboBox_Meka_Namae.Enabled = false;
            comboBox_Meka_Namae.BackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            comboBoxSyouhin_Namae.Enabled = false;
            comboBoxSyouhin_Namae.BackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
            domainUpDown_Suuryou.Enabled = false;
            domainUpDown_Suuryou.BackColor = Color.LightGray;
            checkBox_Kakutei.Enabled = false;
            checkBox_Kakutei.ForeColor = Color.LightGray;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cmbclia();
            label1.ForeColor = Color.LightGray;
            textBox_Syukko_ID.Enabled = false;
            textBox_Syukko_ID.BackColor = Color.LightGray;
            label2.ForeColor = Color.LightGray;
            comboBox_Eigyousyo.Enabled = false;
            comboBox_Eigyousyo.BackColor = Color.LightGray;
            label3.ForeColor = Color.LightGray;
            textBox_Syain.Enabled = false;
            textBox_Syain.BackColor = Color.LightGray;
            label4.ForeColor = Color.LightGray;
            comboBox_Kokyaku.Enabled = false;
            comboBox_Kokyaku.BackColor = Color.LightGray;
            label5.ForeColor = Color.LightGray;
            textBox_Zyutyuu_ID.Enabled = false;
            textBox_Zyutyuu_ID.BackColor = Color.LightGray;
            label6.ForeColor = Color.LightGray;
            textBox_Kakutei_Syain_Namae.Enabled = false;
            textBox_Kakutei_Syain_Namae.BackColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;
            textBox_Syukkosyousai_ID.Enabled = false;
            textBox_Syukkosyousai_ID.BackColor = Color.LightGray;
            label8.ForeColor = Color.LightGray;
            comboBox_Meka_Namae.Enabled = false;
            comboBox_Meka_Namae.BackColor = Color.LightGray;
            label9.ForeColor = Color.LightGray;
            comboBoxSyouhin_Namae.Enabled = false;
            comboBoxSyouhin_Namae.BackColor = Color.LightGray;
            label10.ForeColor = Color.LightGray;
            domainUpDown_Suuryou.Enabled = false;
            domainUpDown_Suuryou.BackColor = Color.LightGray;
            checkBox_Kakutei.Enabled = false;
            checkBox_Kakutei.ForeColor = Color.LightGray;
        }

        private void cmbclia()
        {
            label1.ForeColor = Color.Black;
            textBox_Syukko_ID.Enabled = true;
            textBox_Syukko_ID.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            comboBox_Eigyousyo.Enabled = true;
            comboBox_Eigyousyo.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            textBox_Syain.Enabled = true;
            textBox_Syain.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            comboBox_Kokyaku.Enabled = true;
            comboBox_Kokyaku.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            textBox_Zyutyuu_ID.Enabled = true;
            textBox_Zyutyuu_ID.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            textBox_Kakutei_Syain_Namae.Enabled = true;
            textBox_Kakutei_Syain_Namae.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            textBox_Syukkosyousai_ID.Enabled = true;
            textBox_Syukkosyousai_ID.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            comboBox_Meka_Namae.Enabled = true;
            comboBox_Meka_Namae.BackColor = Color.White;
            label9.ForeColor = Color.Black;
            comboBoxSyouhin_Namae.Enabled = true;
            comboBoxSyouhin_Namae.BackColor = Color.White;
            label10.ForeColor = Color.Black;
            domainUpDown_Suuryou.Enabled = true;
            domainUpDown_Suuryou.BackColor = Color.White;
            checkBox_Kakutei.Enabled = true;
            checkBox_Kakutei.ForeColor = Color.Black;
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