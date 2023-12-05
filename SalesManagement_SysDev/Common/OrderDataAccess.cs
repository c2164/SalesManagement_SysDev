﻿using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class OrderDataAccess
    {

        //受注情報登録(登録情報)
        public bool RegisterOrderData(T_Order RegOrder)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Orders.Add(RegOrder);
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
        public bool UpdateOrderData(T_Order UpOrder)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Orders.Single(x => x.OrID == UpOrder.OrID);
                    UpdateTarget = UpOrder;

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
                         ((dispOrderDTO.OrID == "") ? true :
                         Order.OrID == int.Parse(dispOrderDTO.OrID)) &&//受注ID
                         ((dispOrderDTO.OrDetailID == "") ? true :
                         Order.OrID == int.Parse(dispOrderDTO.OrDetailID)) &&//受注詳細ID
                         //Maker.MaName.Contains(dispOrderDTO.MaName) && //メーカー名
                         SalesOffice.SoName.Contains(dispOrderDTO.SoName) && // 営業所
                         Product.PrName.Contains(dispOrderDTO.PrName) && //商品名
                         ((dispOrderDTO.OrQuantity == "") ? true :
                         OrderDetail.OrQuantity == int.Parse(dispOrderDTO.OrQuantity)) &&//価格
                         
                         Product.PrFlag == 0 //非表示フラグ

                         select new DispOrderDTO
                         {
                             ClName = Client.ClName,
                             ClCharge =Order.ClCharge,
                             EmName = Employee.EmName,
                             OrID = Order.OrID.ToString(),
                             OrDetailID = OrderDetail.OrDetailID.ToString(),
                             SoName = SalesOffice.SoName,
                             PrName = Product.PrName,
                             OrQuantity=OrderDetail.OrQuantity.ToString()                          
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
                             OrTotalPrice = OrderDetail.OrTotalPrice.ToString(),
                             OrDate=Order.OrDate,
                             OrStateFlag=Order.OrStateFlag.ToString(),
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