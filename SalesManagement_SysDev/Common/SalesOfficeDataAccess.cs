using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.CommonMethod
{
    internal class SalesOfficeDataAccess
    {
        public List<M_SalesOffice> GetSalesOfficeData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                List<M_SalesOffice> tb = new List<M_SalesOffice>();
                tb = context.M_SalesOffices.ToList();

                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;
        }
    }
}
