using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Common
{
    internal class DataInputFormCheck
    {
        //数値チェック
        public bool CheckNumeric(string chkData)
        {
            Regex regex = new Regex("^-?[0-9]+$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }

        //住所チェック
        public bool CheckMailAddress(string chkData)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }

        //電話番号とFAXのチェック
        public bool CheckPhoneAndFAX(string chkData)
        {
            Regex regex = new Regex(@"^0\d{1,4}-\d{1,4}-\d{4}$|^0\d{9,10}$|^0120-\d{1,4}-\d{3}$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }

        public bool CheckPostal(string chkData)
        {
            Regex regex = new Regex(@"^\d{7}$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }
    }
}
