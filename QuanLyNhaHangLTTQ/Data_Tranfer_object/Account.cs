using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    public class Account
    {

        public Account(string displayName, string username, int type, string password = null) 
        { 
            this.DisplayName = displayName;
            this.UserName = username;
            this.Type = type;
            this.PassWord = password;
        }

        public Account(DataRow row)
        {
            this.UserName = row["Username"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Type = (int)row["Type"];
            this.PassWord = row["Password"].ToString();
        }
        public string DisplayName { get; set; }
        public string UserName { get; set; }

        public int Type { get; set; }

        public string PassWord { get; set; }
    }
}
