using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class ShipmentDataAccess
    {
        public bool RegisterShipmentData(T_Shipment RegShipment, List<T_ShipmentDetail> ListRegShipmentDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Shipments.Add(RegShipment);
                    context.SaveChanges();
                    int ShID = context.T_Shipments.Max(x => x.ShID);
                    foreach (var RegShipmentDetail in ListRegShipmentDetail)
                    {
                        RegShipmentDetail.ShID = ShID;
                        context.T_ShipmentDetails.Add(RegShipmentDetail);
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

        public bool UpdateShipmentData(T_Shipment UpShipment, T_ShipmentDetail UpShipmentDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Shipments.Single(x => x.ShID == UpShipment.ShID);
                    var UpdateTargetDetails = context.T_ShipmentDetails.Single(x => x.ShDetailID == UpShipmentDetail.ShDetailID);

                    UpdateTarget.ShID = UpShipment.ShID;
                    UpdateTarget.ClID = UpShipment.ClID;
                    UpdateTarget.EmID = UpShipment.EmID;
                    UpdateTarget.SoID = UpShipment.SoID;
                    UpdateTarget.OrID = UpShipment.OrID;
                    UpdateTarget.ShStateFlag = UpShipment.ShStateFlag;
                    UpdateTarget.ShFinishDate = UpShipment.ShFinishDate;
                    UpdateTarget.ShFlag = UpShipment.ShFlag;
                    UpdateTarget.ShHidden = UpShipment.ShHidden;

                    UpdateTargetDetails.ShDetailID = UpShipmentDetail.ShDetailID;
                    UpdateTargetDetails.ShID = UpShipmentDetail.ShID;
                    UpdateTargetDetails.PrID = UpShipmentDetail.PrID;
                    UpdateTargetDetails.ShQuantity = UpShipmentDetail.ShQuantity;

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

        public List<DispShipmentDTO> GetShipmentData(DispShipmentDTO dispShipmentDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Shipment」テーブルから「M_Product」「M_Client」「M_Employee] 「M_SalesOffice] [T_Order]を参照
                var tb = from ShipmentDetail in context.T_ShipmentDetails
                         join Shipment in context.T_Shipments
                         on ShipmentDetail.ShID equals Shipment.ShID
                         join Product in context.M_Products
                         on ShipmentDetail.PrID equals Product.PrID
                         join Client in context.M_Clients
                         on Shipment.ClID equals Client.ClID
                         join SalesOffice in context.M_SalesOffices
                         on Shipment.SoID equals SalesOffice.SoID
                         join Employee in context.M_Employees
                         on Shipment.EmID equals Employee.EmID into em
                         from Employee in em.DefaultIfEmpty()
                         join Order in context.T_Orders
                         on Shipment.OrID equals Order.OrID
                         join Arrival in context.T_Arrivals
                         on Shipment.OrID equals Arrival.OrID
                         join ArrivalEmployee in context.M_Employees
                         on Arrival.EmID equals ArrivalEmployee.EmID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID

                         where
                         Client.ClName.Contains(dispShipmentDTO.ClName) && //顧客名

                         (dispShipmentDTO.ShID.Equals("") ? true :
                         Shipment.ShID.ToString().Equals(dispShipmentDTO.ShID)) && //出荷ID

                         SalesOffice.SoName.Contains(dispShipmentDTO.SoName) && //営業所名

                         ArrivalEmployee.EmName.Contains(dispShipmentDTO.ArrivalEmName) && //入荷社員名

                         (dispShipmentDTO.OrID.Equals("") ? true :
                         Order.OrID.ToString().Equals(dispShipmentDTO.OrID)) && //受注ID

                         Product.PrName.Contains(dispShipmentDTO.PrName) && //商品名

                         (Employee.EmName == null && dispShipmentDTO.ConfEmName == "" ? true :
                         Employee.EmName.Contains(dispShipmentDTO.ConfEmName)) && //確定社員名

                         (dispShipmentDTO.ShDetailID.Equals("") ? true :
                         ShipmentDetail.ShDetailID.ToString().Equals(dispShipmentDTO.ShDetailID)) && //出荷詳細ID

                         Maker.MaName.Contains(dispShipmentDTO.MaName) && //メーカー名

                        (dispShipmentDTO.ShStateFlag == "1" ? true :
                         Shipment.ShStateFlag == 0) &&

                         Shipment.ShFlag == 0 //非表示フラグ


                         select new DispShipmentDTO
                         {
                             ShID = Shipment.ShID.ToString(),
                             ShDetailID = ShipmentDetail.ShDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName,
                             ShQuantity = ShipmentDetail.ShQuantity.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             ArrivalEmID = ArrivalEmployee.EmID.ToString(),
                             ArrivalEmName = ArrivalEmployee.EmName,
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName,
                             ClID = Client.ClID.ToString(),
                             ClName = Client.ClName,
                             OrID = Order.OrID.ToString(),
                             ShStateFlag = Shipment.ShStateFlag.ToString(),
                             ShFlag = Shipment.ShFlag.ToString(),
                             ShHidden = Shipment.ShHidden,
                             ShFinishDate=Shipment.ShFinishDate,
                             EmID = Employee.EmID.ToString(),
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

        public List<DispShipmentDTO> GetShipmentData(int stateflag)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Shipment」テーブルから「M_Product」「M_Client」「M_Employee] 「M_SalesOffice] [T_Order]を参照
                var tb = from ShipmentDetail in context.T_ShipmentDetails
                         join Shipment in context.T_Shipments
                         on ShipmentDetail.ShID equals Shipment.ShID
                         join Product in context.M_Products
                         on ShipmentDetail.PrID equals Product.PrID
                         join Client in context.M_Clients
                         on Shipment.ClID equals Client.ClID
                         join SalesOffice in context.M_SalesOffices
                         on Shipment.SoID equals SalesOffice.SoID
                         join Employee in context.M_Employees
                         on Shipment.EmID equals Employee.EmID into em
                         from Employee in em.DefaultIfEmpty()
                         join Order in context.T_Orders
                         on Shipment.OrID equals Order.OrID
                         join Arrival in context.T_Arrivals
                         on Shipment.OrID equals Arrival.OrID
                         join ArrivalEmployee in context.M_Employees
                         on Arrival.EmID equals ArrivalEmployee.EmID into Arem
                         from ArrivalEmployee in Arem.DefaultIfEmpty()
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         where
                         Shipment.ShFlag == 0  &&//非表示フラグ
                         (stateflag == 1 ? true :
                         Shipment.ShStateFlag == 0)

                         select new DispShipmentDTO
                         {
                             ShID = Shipment.ShID.ToString(),
                             ShDetailID = ShipmentDetail.ShDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName,
                             MaID = Maker.MaID.ToString(),
                             MaName = Maker.MaName,
                             ShQuantity = ShipmentDetail.ShQuantity.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             ArrivalEmID = ArrivalEmployee.EmID.ToString(),
                             ArrivalEmName = ArrivalEmployee.EmName,
                             ConfEmID = Employee.EmID.ToString(),
                             ConfEmName = Employee.EmName,
                             ClID = Client.ClID.ToString(),
                             ClName = Client.ClName,
                             OrID = Order.OrID.ToString(),
                             ShStateFlag = Shipment.ShStateFlag.ToString(),
                             ShFlag = Shipment.ShFlag.ToString(),
                             ShHidden = Shipment.ShHidden,
                             ShFinishDate = Shipment.ShFinishDate,
                             EmID = Employee.EmID.ToString(),
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
