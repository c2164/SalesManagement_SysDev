using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Common
{
    internal class EmployeeDataAccess
    {
        //社員情報登録(登録情報)
        public bool RegisterEmployeeData(M_Employee RegEmployee)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    context.M_Employees.Add(RegEmployee);
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

        //社員情報アップデート(アップデート情報)
        public bool UpdateEmployeeData(M_Employee UpEmployee)
        {
            using (var context = new SalesManagement_DevContext())
            {
                try
                {
                    var UpdateTarget = context.M_Employees.Single(x => x.EmID == UpEmployee.EmID);
                    UpdateTarget.EmID = UpEmployee.EmID;
                    UpdateTarget.EmName = UpEmployee.EmName;
                    UpdateTarget.SoID = UpEmployee.SoID;
                    UpdateTarget.PoID = UpEmployee.PoID;
                    UpdateTarget.EmHiredate = UpEmployee.EmHiredate;
                    UpdateTarget.EmPhone = UpEmployee.EmPhone;
                    UpdateTarget.EmPassword = UpEmployee.EmPassword;
                    UpdateTarget.EmFlag = UpEmployee.EmFlag;
                    UpdateTarget.EmHidden = UpEmployee.EmHidden;

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

        //社員検索(検索項目)：オーバーロード
        public List<DispEmplyeeDTO> GetEmployeeData(DispEmplyeeDTO dispEmployeeDTO)
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「M_Employee」テーブルから「M_SalesOffice」「M_Position」を参照
                var tb = from Employee in context.M_Employees
                         join SalesOffice in context.M_SalesOffices
                         on Employee.SoID equals SalesOffice.SoID
                         join Position in context.M_Positions
                         on Employee.PoID equals Position.PoID

                         where
                         Employee.EmName.Contains(dispEmployeeDTO.EmName) && //社員名
                         Employee.EmID.ToString().Contains(dispEmployeeDTO.EmID) && //社員ID
                         SalesOffice.SoName.Contains(dispEmployeeDTO.SoName) && //営業所名
                         Position.PoName.Contains(dispEmployeeDTO.PoName) && //役職名
                                                                            //入社年月日
                         Employee.EmPhone.Contains(dispEmployeeDTO.EmPhone) && //電話番号
                         　　　　　　　　　　　　　　　　　　　　　　　　　　　//FAX
                         Employee.EmPassword.Contains(dispEmployeeDTO.EmPassword) &&//パスワード
                         Employee.EmFlag == 0 //非表示フラグ

                         select new DispEmplyeeDTO
                         {
                             EmName = Employee.EmName,
                             EmID = Employee.EmID.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             PoID = Position.PoID.ToString(),
                             PoName = Position.PoName,
                             EmHiredate = Employee.EmHiredate,
                             EmPhone = Employee.EmPhone,
                             EmPassword = Employee.EmPassword,
                             EmFlag = Employee.EmFlag.ToString(),
                             EmHidden = Employee.EmHidden,
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }

        //社員全表示：オーバーロード
        public List<DispEmplyeeDTO> GetEmployeeData()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                //「M_Employee」テーブルから「M_SalesOffice」「M_Position」を参照
                var tb = from Employee in context.M_Employees
                         join SalesOffice in context.M_SalesOffices
                         on Employee.SoID equals SalesOffice.SoID
                         join Position in context.M_Positions
                         on Employee.PoID equals Position.PoID

                         where
                         Employee.EmFlag == 0 //社員管理フラグ
                         select new DispEmplyeeDTO
                         {
                             EmName = Employee.EmName,
                             EmID = Employee.EmID.ToString(),
                             SoID = SalesOffice.SoID.ToString(),
                             SoName = SalesOffice.SoName,
                             PoID = Position.PoID.ToString(),
                             PoName = Position.PoName,
                             EmHiredate = Employee.EmHiredate,
                             EmPhone = Employee.EmPhone,
                             EmPassword = Employee.EmPassword,
                             EmFlag = Employee.EmFlag.ToString(),
                             EmHidden = Employee.EmHidden,
                         };

                return tb.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return null;

        }
    }
}
