using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class ClientDataAccess
    {
        //顧客情報登録(登録情報)
        public bool RegisterClientData(M_Client RegClient)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.M_Clients.Add(RegClient);
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

        //顧客情報アップデート(アップデート情報)
        public bool UpdateClientData(M_Client UpClient)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.M_Clients.Single(x => x.ClID == UpClient.ClID);
                    UpdateTarget.ClID = UpClient.ClID;
                    UpdateTarget.SoID = UpClient.SoID;
                    UpdateTarget.ClName = UpClient.ClName;
                    UpdateTarget.ClAddress = UpClient.ClAddress;
                    UpdateTarget.ClPhone = UpClient.ClPhone;
                    UpdateTarget.ClPostal = UpClient.ClPostal;
                    UpdateTarget.ClFAX = UpClient.ClFAX;
                    UpdateTarget.ClFlag = UpClient.ClFlag;
                    UpdateTarget.ClHidden = UpClient.ClHidden;

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

        //顧客検索(検索項目)：オーバーロード
        public List<DispClientDTO> GetClientData(DispClientDTO dispClientDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「M_Client」テーブルから「M_SalesOffice」を参照
                var tb = from Client in context.M_Clients
                         join SalesOffice in context.M_SalesOffices
                         on Client.SoID equals SalesOffice.SoID

                         where
                         Client.ClName.Contains(dispClientDTO.ClName) &&//顧客名
                         Client.ClID.ToString().Contains(dispClientDTO.ClID) &&  //顧客ID
                         SalesOffice.SoName.Contains(dispClientDTO.SoName) && //営業所名
                         Client.ClPostal.Contains(dispClientDTO.ClPostal) && //郵便番号
                         Client.ClAddress.Contains(dispClientDTO.ClAddress) && //住所
                         Client.ClPhone.Contains(dispClientDTO.ClPhone) && //電話番号
                         Client.ClFAX.Contains(Client.ClFAX) &&//FAX
                         Client.ClFlag == 0 //非表示フラグ

                         select new DispClientDTO
                         {
                             ClName = Client.ClName,
                             ClID = Client.ClID.ToString(),
                             ClPostal = Client.ClPostal,
                             ClAddress = Client.ClAddress,
                             ClPhone = Client.ClPhone,
                             ClFAX = Client.ClFAX,
                             ClFlag = Client.ClFlag.ToString(),
                             ClHidden = Client.ClHidden,
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
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
                             ClFlag = Client.ClFlag.ToString(),
                             ClHidden = Client.ClHidden,
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
