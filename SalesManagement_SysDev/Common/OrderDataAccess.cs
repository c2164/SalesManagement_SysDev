﻿using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class OrderDataAccess
    {

        //受注情報登録(登録情報)
        public bool RegisterOrderData(T_Order RegOrder, T_OrderDetail RegOrderDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    int OrID = RegOrder.OrID;
                    if (!context.T_Orders.Any(x => x.OrID == OrID))
                    {
                        context.T_Orders.Add(RegOrder);
                        context.SaveChanges();
                        OrID = context.T_Orders.Max(x => x.OrID);
                    }
                    RegOrderDetail.OrID = OrID;
                    context.T_OrderDetails.Add(RegOrderDetail);
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

        //受注情報アップデート(アップデート情報)
        public bool UpdateOrderData(T_Order UpOrder, T_OrderDetail UpOrderDetail)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Orders.Single(x => x.OrID == UpOrder.OrID);
                    var UpdateTargetDetail = context.T_OrderDetails.Single(x => x.OrDetailID == UpOrderDetail.OrID);

                    UpdateTarget.OrID= UpOrder.OrID;
                    UpdateTarget.SoID = UpdateTarget.SoID;
                    UpdateTarget.EmID=UpdateTarget.EmID;
                    UpdateTarget.ClID=UpdateTarget.ClID;
                    UpdateTarget.ClCharge=UpdateTarget.ClCharge;
                    UpdateTarget.OrDate=UpdateTarget.OrDate;
                    UpdateTarget.OrStateFlag=UpdateTarget.OrStateFlag;
                    UpdateTarget.OrFlag=UpdateTarget.OrFlag;
                    UpdateTarget.OrHidden=UpdateTarget.OrHidden;

                    UpdateTargetDetail.OrDetailID=UpdateTargetDetail.OrDetailID;
                    UpdateTargetDetail.OrID=UpdateTargetDetail.OrID;
                    UpdateTargetDetail.PrID=UpdateTargetDetail.PrID;
                    UpdateTargetDetail.OrQuantity=UpdateTargetDetail.OrQuantity;
                    UpdateTargetDetail.OrTotalPrice=UpdateTargetDetail.OrTotalPrice;

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

        //受注検索(検索項目)：オーバーロード
        public List<DispOrderDTO> GetOrderData(DispOrderDTO dispOrderDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Order」テーブルから「M_SalesOffice」「M_Client」「Employee」を参照
                var tb = from Order in context.T_Orders
                         join SalesOffice in context.M_SalesOffices
                         on Order.SoID equals SalesOffice.SoID
                         join Client in context.M_Clients
                         on Order.ClID equals Client.ClID
                         join Employee in context.M_Employees
                         on Order.EmID equals Employee.EmID
                         join OrderDetail in context.T_OrderDetails
                         on Order.OrID equals OrderDetail.OrID
                         join Product in context.M_Products
                         on OrderDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID

                         where
                         Client.ClName.Contains(dispOrderDTO.ClName) && //顧客名

                         Order.ClCharge.Contains(dispOrderDTO.ClCharge) &&//顧客担当社員名
                         Employee.EmName.Contains(dispOrderDTO.EmName) &&//社員名
                         (dispOrderDTO.OrID.Equals("") ? true:
                         Order.OrID.ToString().Contains(dispOrderDTO.OrID)) &&//受注ID
                         (dispOrderDTO.OrDetailID.Equals("") ? true:
                         OrderDetail.OrDetailID.ToString().Equals(dispOrderDTO.OrDetailID)) &&//受注詳細ID
                         Maker.MaName.Contains(dispOrderDTO.MaName) && //メーカー名
                         Maker.MaName.Contains(dispOrderDTO.MaName) && // 営業所
                         Product.PrName.Contains(dispOrderDTO.PrName) && //商品名



                         Product.PrFlag == 0 //非表示フラグ

                         select new DispOrderDTO
                         {
                             ClName = Client.ClName,
                             ClCharge = Order.ClCharge,
                             EmName = Employee.EmName,
                             OrID = Order.OrID.ToString(),
                             OrDetailID = OrderDetail.OrDetailID.ToString(),
                             SoName = SalesOffice.SoName,
                             PrName = Product.PrName,
                             OrTotalPrice = (Order.OrStateFlag == 0 ? context.M_Products.FirstOrDefault(x => x.PrID == OrderDetail.PrID).Price * OrderDetail.OrQuantity :
                             OrderDetail.OrTotalPrice).ToString().Replace("0.00", ""),
                             OrQuantity = OrderDetail.OrQuantity.ToString(),
                             MaName = Maker.MaName.ToString(),
                             Price = Product.Price.ToString(),
                         };

       
                
                
                
                
                
                
                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //受注全表示：オーバーロード
        public List<DispOrderDTO> GetOrderData()
        {
            var context = new SalesManagement_DevContext();
            try
            {

                //「T_Order」テーブルから「M_SalesOffice」「M_Client」「Employee」を参照
                var tb = from Order in context.T_Orders
                         join SalesOffice in context.M_SalesOffices
                         on Order.SoID equals SalesOffice.SoID
                         join Client in context.M_Clients
                         on Order.ClID equals Client.ClID
                         join Employee in context.M_Employees
                         on Order.EmID equals Employee.EmID
                         join OrderDetail in context.T_OrderDetails
                         on Order.OrID equals OrderDetail.OrID
                         join Product in context.M_Products
                         on OrderDetail.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID

                         where
                         Product.PrFlag == 0 //非表示フラグ

                         select new DispOrderDTO
                         {
                             ClName = Client.ClName,
                             ClCharge = Order.ClCharge,
                             EmName = Employee.EmName,
                             OrID = Order.OrID.ToString(),
                             OrDetailID = OrderDetail.OrDetailID.ToString(),
                             SoName = SalesOffice.SoName,
                             PrName = Product.PrName,
                             OrQuantity = OrderDetail.OrQuantity.ToString(),
                             OrTotalPrice = (Order.OrStateFlag == 0 ? context.M_Products.FirstOrDefault(x => x.PrID == OrderDetail.PrID).Price * OrderDetail.OrQuantity :
                             OrderDetail.OrTotalPrice).ToString().Replace("0.00", ""),
                             OrDate = Order.OrDate,
                             OrStateFlag = Order.OrStateFlag.ToString(),
                             MaName = Maker.MaName.ToString(),
                             Price = Product.Price.ToString(),
                             OrFlag= Order.OrFlag.ToString(),
                             OrHidden= Order.OrHidden.ToString(),
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
