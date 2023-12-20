using SalesManagement_SysDev.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class StockDataAccess
    {
        //在庫情報登録(登録情報)
        public bool RegisterStockData(T_Stock RegStock)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.T_Stocks.Add(RegStock);
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

        //在庫情報アップデート(アップデート情報)
        public bool UpdateStockData(T_Stock UpStock)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.T_Stocks.Single(x => x.StID == UpStock.StID);
                    UpdateTarget.StID = UpStock.StID;
                    UpdateTarget.StQuantity = UpStock.StQuantity;
                    UpdateTarget.StFlag = UpStock.StFlag;
                    UpdateTarget.PrID = UpStock.PrID;


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

        //在庫検索(検索項目)：オーバーロード
        public List<DispStockDTO> GetStockData(DispStockDTO dispStockDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Stock」テーブルから「M_Product」を参照
                var tb = from Stock in context.T_Stocks
                         join Product in context.M_Products
                         on Stock.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID

                         where
                         (dispStockDTO.StID.Equals("") ? true :
                         Stock.StID.ToString().Equals(dispStockDTO.StID)) && //在庫ID
                         Maker.MaName.Contains(dispStockDTO.MaName) && //メーカー名
                         ((dispStockDTO.StQuantity == "") ? true :
                         Stock.StQuantity == int.Parse(dispStockDTO.PrID)) &&//在庫数
                         Product.PrName.Contains(dispStockDTO.PrName) &&//商品名
                         Stock.StFlag == 0 //在庫管理フラグ
                         select new DispStockDTO
                         {
                             StID = Stock.StID.ToString(),
                             PrID = Product.PrID.ToString(),
                             MaName = Maker.MaName,
                             PrName = Product.PrName,
                             StQuantity = Stock.StQuantity.ToString(),
                             StFlag = Stock.StFlag.ToString(),
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //在庫全表示：オーバーロード
        public List<DispStockDTO> GetStockData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「T_Stock」テーブルから「M_Product」を参照
                var tb = from Stock in context.T_Stocks
                         join Product in context.M_Products
                         on Stock.PrID equals Product.PrID
                         join Maker in context.M_Makers
                         on Product.MaID equals Maker.MaID

                         where
                         Stock.StFlag == 0 //在庫管理フラグ

                         select new DispStockDTO
                         {
                             StID = Stock.StID.ToString(),
                             PrID = Product.PrID.ToString(),
                             MaName = Maker.MaName,
                             PrName = Product.PrName,
                             StQuantity = Stock.StQuantity.ToString(),
                             StFlag = Stock.StFlag.ToString(),
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
