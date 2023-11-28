using SalesManagement_SysDev.Entity;
using System;
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
                    UpdateTarget = UpStock;

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
                         on Product.PrID equals Product.PrID



                         where
                         Stock.StID.Contains(dispStockDTO.StID) && //在庫ID
                         Maker.MaName.ToString().Contains(dispClientDTO.ClID) && //メーカー名
                         SalesOffice.SoName.Contains(dispClientDTO.SoName) && //商品名
                         Client.ClPostal.Contains(dispClientDTO.ClPostal)//在庫数

                         select new DispClientDTO
                         {
                             StID = Stock.StID,
                             ClID = Client.ClID.ToString(),
                             ClPostal = Client.ClPostal,
                             ClAddress = Client.ClAddress,
                             ClPhone = Client.ClPhone,
                             ClFAX = Client.ClFAX,

                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //顧客全表示：オーバーロード
        public List<DispClientDTO> GetClientData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「M_Client」テーブルから「M_SalesOffice」を参照
                var tb = from Client in context.M_Clients
                         join SalesOffice in context.M_SalesOffices
                         on Client.SoID equals SalesOffice.SoID
                         where Client.ClFlag == 0

                         select new DispClientDTO
                         {
                             ClName = Client.ClName,
                             ClID = Client.ClID.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             ClPostal = Client.ClPostal,
                             ClAddress = Client.ClAddress,
                             ClPhone = Client.ClPhone,
                             ClFAX = Client.ClFAX,

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
