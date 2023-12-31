﻿using SalesManagement_SysDev.Entity;
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
        public bool RegisterShipmentData(T_Shipment RegShipment, T_ShipmentDetail RegShipmentDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    int ShID = RegShipment.ShID;
                    if(!context.T_Shipments.Any(x => x.ShID == RegShipment.ShID))
                    {
                        context.T_Shipments.Add(RegShipment);
                        context.SaveChanges();
                        ShID = context.T_Shipments.Max(x => x.ShID);
                    }
                    RegShipmentDetail.ShID = ShID;
                    context.T_ShipmentDetails.Add(RegShipmentDetail);
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

        public bool UpdateShipmentData(T_Shipment UpShipment)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Shipments.Single(x => x.ShID == UpShipment.ShID);
                    UpdateTarget = UpShipment;

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
                         on Shipment.EmID equals Employee.EmID
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
                         dispShipmentDTO.ShID.Equals("")? true:
                         Shipment.ShID.ToString().Equals(dispShipmentDTO.ShID) && //出荷ID
                         SalesOffice.SoName.Contains(dispShipmentDTO.SoName) && //営業所名
                         ArrivalEmployee.EmName.Contains(dispShipmentDTO.ArrivalEmName) && //入荷社員名
                         dispShipmentDTO.OrID.Equals("")?true:
                         Shipment.OrID.ToString().Equals(dispShipmentDTO.OrID) && //受注ID
                         Product.PrName.Contains(dispShipmentDTO.PrName) && //商品名
                         Employee.EmID.ToString().Contains(dispShipmentDTO.ConfEmName) && //確定社員名
                         dispShipmentDTO.ShDetailID.Equals("")? true:
                         ShipmentDetail.ShDetailID.ToString().Equals(dispShipmentDTO.ShDetailID) && //出荷詳細ID
                         Maker.MaName.Contains(dispShipmentDTO.MaName) && //メーカー名
                         dispShipmentDTO.ArQuantity.Equals("")? true:
                         ShipmentDetail.ShQuantity.ToString().Equals(dispShipmentDTO.ArQuantity)  &&//数量
                         dispShipmentDTO.ShStateFlag.Contains("2") ? true:
                         Shipment.ShStateFlag.ToString() == dispShipmentDTO.ShStateFlag &&//出荷状態フラグ
                         Shipment.ShFlag == 0 //非表示フラグ


                         select new DispShipmentDTO
                         {
                             ShID = Shipment.ShID.ToString(),
                             ShDetailID = ShipmentDetail.ShDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             ArQuantity = ShipmentDetail.ShDetailID.ToString(),
                             SoID = Shipment.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ArrivalEmID = Arrival.ClID.ToString(),
                             ArrivalEmName = ArrivalEmployee.EmName.ToString(),
                             ConfEmID = Shipment.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             ClID = Shipment.ClID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Shipment.OrID.ToString(),
                             ShDate = Shipment.ShFinishDate,
                             ShStateFlag = Shipment.ShStateFlag.ToString()

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

        public List<DispShipmentDTO> GetShipmentData()
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
                         on Shipment.EmID equals Employee.EmID
                         join Order in context.T_Orders
                         on Shipment.OrID equals Order.OrID
                         join Arrival in context.T_Arrivals
                         on Shipment.OrID equals Arrival.OrID
                         join ArrivalEmployee in context.M_Employees
                         on Arrival.EmID equals ArrivalEmployee.EmID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID
                         where
                         Shipment.ShFlag == 0  //非表示フラグ


                         select new DispShipmentDTO
                         {
                             ShID = Shipment.ShID.ToString(),
                             ShDetailID = ShipmentDetail.ShDetailID.ToString(),
                             PrID = Product.PrID.ToString(),
                             PrName = Product.PrName.ToString(),
                             MaID = Product.MaID.ToString(),
                             MaName = Maker.MaName.ToString(),
                             ArQuantity = ShipmentDetail.ShDetailID.ToString(),
                             SoID = Shipment.SoID.ToString(),
                             SoName = SalesOffice.SoName.ToString(),
                             ArrivalEmID = Arrival.ClID.ToString(),
                             ArrivalEmName = ArrivalEmployee.EmName.ToString(),
                             ConfEmID = Shipment.EmID.ToString(),
                             ConfEmName = Employee.EmName.ToString(),
                             ClID = Shipment.ClID.ToString(),
                             ClName = Client.ClName.ToString(),
                             OrID = Shipment.OrID.ToString(),
                             ShDate = Shipment.ShFinishDate,
                             ShStateFlag = Shipment.ShStateFlag.ToString()
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
