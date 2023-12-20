using SalesManagement_SysDev.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    class ArraivalDataAccess
    {
        public bool RegisterArrivalsData(T_Arrival RegArrival, List<T_ArrivalDetail> ListRegArrivalDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Arrivals.Add(RegArrival);
                    context.SaveChanges();
                    int ArID = context.T_Arrivals.Max(x => x.ArID);
                    foreach (var RegArrivalDetail in ListRegArrivalDetail)
                    {
                        RegArrivalDetail.ArID = ArID;
                        context.T_Arrivals.Add(RegArrival);
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

        public bool UpdateArrivalData(T_Arrival UpArrival,T_ArrivalDetail UpArrivalDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Arrivals.Single(x => x.ArID == UpArrival.ArID);
                    var UpdateTargetDetail = context.T_ArrivalDetails.Single(x => x.ArDetailID == UpArrivalDetail.ArID);
                    UpdateTarget = UpArrival;
                    UpdateTargetDetail = UpArrivalDetail;

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

        public List<DispArrivalDTO> GetArrivalData(DispArrivalDTO dispArrivalDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Arrival」テーブルから「M_SalesOffice」「M_Employee] 「M_Client] [T_Order]を参照
                var tb = from ArrivalDetail in context.T_ArrivalDetails
                         join Arrival in context.T_Arrivals
                         on ArrivalDetail.ArID equals Arrival.ArID
                         join Product in context.M_Products
                         on ArrivalDetail.PrID equals Product.PrID
                         join SalesOffice in context.M_SalesOffices
                         on Arrival.SoID equals SalesOffice.SoID
                         join Employee in context.M_Employees
                         on Arrival.EmID equals Employee.EmID
                         join Client in context.M_Clients
                         on Arrival.ClID equals Client.ClID
                         join Order in context.T_Orders
                         on Arrival.OrID equals Order.OrID
                         join Chumon in context.T_Chumons
                         on Arrival.OrID equals Chumon.OrID
                         join ChumonEm in context.M_Employees
                         on Chumon.EmID equals ChumonEm.EmID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         where
                         Client.ClName.Contains(dispArrivalDTO.ClName) && //顧客名
                         (dispArrivalDTO.ArID.Equals("") ? true:
                         ArrivalDetail.ArID.ToString().Equals(dispArrivalDTO.ArID)) && //入荷ID
                         SalesOffice.SoName.Contains(dispArrivalDTO.SoName) && //営業所名
                         ChumonEm.EmName.Contains(dispArrivalDTO.ArrivalEmName) && //入荷社員名
                         (dispArrivalDTO.OrID.Equals("")? true:
                         Arrival.OrID.ToString().Contains(dispArrivalDTO.OrID)) && //受注ID
                         Product.PrName.Contains(dispArrivalDTO.PrName) && //商品名
                         Employee.EmID.ToString().Contains(dispArrivalDTO.ConfEmName) && //確定社員名
                         (dispArrivalDTO.ArDetailID.Equals("")? true:
                         ArrivalDetail.ArDetailID.ToString().Contains(dispArrivalDTO.ArDetailID)) && //入荷詳細ID
                         Maker.MaName.Contains(dispArrivalDTO.MaName) && //メーカー名
                         Arrival.ArStateFlag.ToString() == dispArrivalDTO.ArStateFlag &&//入荷状態フラグ
                         Arrival.ArFlag == 0 //非表示フラグ


                         select new DispArrivalDTO
                         {
                             ArID = Arrival.ArID.ToString(),
                             ArDetailID = ArrivalDetail.ArDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             ArQuantity = ArrivalDetail.ArQuantity.ToString(),
                             SoID = Arrival.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ArrivalEmID = Chumon.ClID.ToString(),
                             ArrivalEmName = ChumonEm.EmName.ToString(),
                             ConfEmID = Arrival.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             ClID = Arrival.ClID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Arrival.OrID.ToString(),
                             ArDate = Arrival.ArDate,
                             ArStateFlag = Arrival.ArStateFlag.ToString()

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

        public List<DispArrivalDTO> GetArrivalData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Arrival」テーブルから「M_SalesOffice」「M_Employee] 「M_Client] [T_Order]を参照
                var tb = from ArrivalDetail in context.T_ArrivalDetails
                         join Arrival in context.T_Arrivals
                         on ArrivalDetail.ArID equals Arrival.ArID
                         join Product in context.M_Products
                         on ArrivalDetail.PrID equals Product.PrID
                         join SalesOffice in context.M_SalesOffices
                         on Arrival.SoID equals SalesOffice.SoID
                         join Employee in context.M_Employees
                         on Arrival.EmID equals Employee.EmID
                         join Client in context.M_Clients
                         on Arrival.ClID equals Client.ClID
                         join Order in context.T_Orders
                         on Arrival.OrID equals Order.OrID
                         join Chumon in context.T_Chumons
                         on Arrival.OrID equals Chumon.OrID
                         join ChumonEm in context.M_Employees
                         on Chumon.EmID equals ChumonEm.EmID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID


                         select new DispArrivalDTO
                         {
                             ArID = Arrival.ArID.ToString(),
                             ArDetailID = ArrivalDetail.ArDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             ArQuantity = ArrivalDetail.ArQuantity.ToString(),
                             SoID = Arrival.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ArrivalEmID = Chumon.ClID.ToString(),
                             ArrivalEmName = ChumonEm.EmName.ToString(),
                             ConfEmID = Arrival.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             ClID = Arrival.ClID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Arrival.OrID.ToString(),
                             ArDate = Arrival.ArDate,
                             ArStateFlag = Arrival.ArStateFlag.ToString()

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
