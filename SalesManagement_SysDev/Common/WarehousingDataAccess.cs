﻿using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class WarehousingDataAccess
    {
        //入庫情報登録(登録情報)
        public bool RegisterWerehousingData(T_Warehousing RegWerehousing, List<T_WarehousingDetail> warehousingDetails)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Warehousings.Add(RegWerehousing);
                    context.SaveChanges();
                    int WaID = context.T_Warehousings.Max(x => x.WaID);
                    foreach (var RegWaDetail in warehousingDetails)
                    {
                        RegWaDetail.WaID = WaID;
                        context.T_WarehousingDetails.Add(RegWaDetail);
                        context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        //入庫情報アップデート(アップデート情報)
        public bool UpdateWarehousingData(T_Warehousing UpWarehousing, T_WarehousingDetail UpwarehousingDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Warehousings.Single(x => x.WaID == UpWarehousing.WaID);
                    UpdateTarget.WaID = UpWarehousing.WaID;
                    UpdateTarget.HaID = UpWarehousing.HaID;
                    UpdateTarget.EmID = UpWarehousing.EmID;
                    UpdateTarget.WaDate = UpWarehousing.WaDate;
                    UpdateTarget.WaShelfFlag = UpWarehousing.WaShelfFlag;
                    UpdateTarget.WaFlag = UpWarehousing.WaFlag;
                    UpdateTarget.WaHidden = UpWarehousing.WaHidden;

                    var UpdateTargetDetail = context.T_WarehousingDetails.Single(x => x.WaDetailID == UpwarehousingDetail.WaDetailID);

                    UpdateTargetDetail.WaDetailID = UpwarehousingDetail.WaDetailID;
                    UpdateTargetDetail.WaID = UpwarehousingDetail.WaID;
                    UpdateTargetDetail.PrID = UpwarehousingDetail.PrID;
                    UpdateTargetDetail.WaQuantity = UpwarehousingDetail.WaQuantity;

                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        //入庫検索(検索項目)：オーバーロード
        public List<DispWarehousingDTO> GetWarehousingData(DispWarehousingDTO dispWarehousingDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Werehousing」テーブルから「T_WarehousingDetail」「M_Product] 「M_Maker] 「M_hattyu] 「M_Employee] 「M_HattyuEmployee] を参照
                var tb = from WarehousingDetail in context.T_WarehousingDetails
                         join Warehousing in context.T_Warehousings
                         on WarehousingDetail.WaID equals Warehousing.WaID
                         join Product in context.M_Products
                         on WarehousingDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         join Hattyu in context.T_Hattyus
                         on Warehousing.HaID equals Hattyu.HaID
                         join Employee in context.M_Employees
                         on Warehousing.EmID equals Employee.EmID into em
                         from Employee in em.DefaultIfEmpty()
                         join HattyuEmployee in context.M_Employees
                         on Hattyu.EmID equals HattyuEmployee.EmID
                         where
                          ((dispWarehousingDTO.WaID == "") ? true :
                         Warehousing.WaID.ToString().Equals(dispWarehousingDTO.WaID)) &&//入庫ID
                          ((dispWarehousingDTO.HaID == "") ? true :
                         Hattyu.HaID.ToString().Equals(dispWarehousingDTO.HaID)) && //発注ID
                          ((dispWarehousingDTO.WaDetailID == "") ? true :
                         WarehousingDetail.WaDetailID.ToString().Equals(dispWarehousingDTO.WaDetailID)) && //入庫詳細ID
                         HattyuEmployee.EmName.Contains(dispWarehousingDTO.HattyuEmName) && //発注社員名
                         (dispWarehousingDTO.ConfEmID == "" && Employee.EmName == null ? true :
                         Employee.EmName.Contains(dispWarehousingDTO.ConfEmName)) && //確定社員名
                         Maker.MaName.Contains(dispWarehousingDTO.MaName) && //メーカー名
                         Product.PrName.Contains(dispWarehousingDTO.PrName) && //商品名
                         (dispWarehousingDTO.WaShelfFlag == "1" ? true :
                         Warehousing.WaShelfFlag == 0) //確定フラグ


                         select new DispWarehousingDTO
                         {
                             WaID = Warehousing.WaID.ToString(),
                             HaID = Hattyu.HaID.ToString(),
                             WaDetailID = WarehousingDetail.WaDetailID.ToString(),
                             HattyuEmID = HattyuEmployee.EmID.ToString(),
                             HattyuEmName = HattyuEmployee.EmName.ToString(),
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             WaQuantity = WarehousingDetail.WaQuantity.ToString(),
                             WaShelfFlag = Warehousing.WaShelfFlag.ToString(),
                             WaDate = Warehousing.WaDate,
                             WaFlag = Warehousing.WaFlag.ToString(),
                             WaHidden = Warehousing.WaHidden.ToString(),

                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //入庫全表示：オーバーロード
        public List<DispWarehousingDTO> GetWarehousingData(int stateflag)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Werehousing」テーブルから「T_WarehousingDetail」「M_Product] 「M_Maker] 「M_hattyu] 「M_Employee] 「M_HattyuEmployee] を参照
                var tb = from WarehousingDetail in context.T_WarehousingDetails
                         join Warehousing in context.T_Warehousings
                         on WarehousingDetail.WaID equals Warehousing.WaID
                         join Product in context.M_Products
                         on WarehousingDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         join Hattyu in context.T_Hattyus
                         on Warehousing.HaID equals Hattyu.HaID
                         join Employee in context.M_Employees
                         on Warehousing.EmID equals Employee.EmID
                         join HattyuEmployee in context.M_Employees
                         on Hattyu.EmID equals HattyuEmployee.EmID

                         where
                         Warehousing.WaFlag == 0 &&
                         (stateflag == 1 ? true :
                         Warehousing.WaShelfFlag == 0) //確定フラグ


                         select new DispWarehousingDTO
                         {
                             WaID = Warehousing.WaID.ToString(),
                             HaID = Hattyu.HaID.ToString(),
                             WaDetailID = WarehousingDetail.WaDetailID.ToString(),
                             HattyuEmID = HattyuEmployee.EmID.ToString(),//
                             HattyuEmName = HattyuEmployee.EmName.ToString(),//
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             WaQuantity = WarehousingDetail.WaQuantity.ToString(),
                             WaShelfFlag = Warehousing.WaShelfFlag.ToString(),
                             WaDate = Warehousing.WaDate,
                             WaFlag = Warehousing.WaFlag.ToString(),
                             WaHidden = Warehousing.WaHidden.ToString(),
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("在庫データ取得時に例外エラーが発生しました", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
    }
}

