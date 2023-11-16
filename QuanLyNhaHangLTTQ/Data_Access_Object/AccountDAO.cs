using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    
    internal class AccountDAO
    {
        private static AccountDAO instance;
        private Account LoginAccount;
        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; } 
        }

        public Account LoginAccount1 { get => LoginAccount; set => LoginAccount = value; }

        private AccountDAO() { }
        
        public bool Login(string username, string password) {
            //  string query = "Select * from dbo.Account Where userName = '" + username +"' and Password = '"+ password +"' ";
            string query = "USP_login @username , @password ";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {username,password});
            return result.Rows.Count > 0;
        }


        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("Select Username, DisplayName, Type from Account");
        }


        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from Account where Username =  '"+username+"'");
            foreach(DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }

        public bool updateAccount(string username, string displayname, string pass, string newpass)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAccount @username , @displayname , @password , @newpassword ", new object[] {username, displayname, pass, newpass});
            return result > 0;
        }

    }
}
