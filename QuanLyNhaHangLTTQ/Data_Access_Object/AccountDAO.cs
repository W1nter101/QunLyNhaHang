﻿using System;
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

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; } 
        }
        private AccountDAO() { }
        
        public bool Login(string username, string password) {
            //  string query = "Select * from dbo.Account Where userName = '" + username +"' and Password = '"+ password +"' ";
            string query = "USP_login @username , @password ";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] {username,password});
            return result.Rows.Count > 0;
        }
    }
}
