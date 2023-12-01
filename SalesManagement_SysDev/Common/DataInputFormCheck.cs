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
        public bool CheckNumeric(string chkData)
        {
            Regex regex = new Regex("^-?[0-9]+$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }

        public bool CheckMailAddress(string chkData)
        {
            Regex regex = new Regex("^-?[0-9]+$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }

        public bool CheckPhone(string chkData)
        {
            Regex regex = new Regex("^0\\d{9,10}$");
            if (!regex.IsMatch(chkData))
                return false;
            else
                return true;
        }
    }
}
