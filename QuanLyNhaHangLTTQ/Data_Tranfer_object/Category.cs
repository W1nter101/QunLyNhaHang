using QuanLyNhaHangLTTQ.Data_Access_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    internal class Category
    {
        public Category(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }
        public Category(DataRow dr)
        {
            this.ID = (int)dr["id"];
            this.name = dr["name"].ToString();
        }
        
        private int iD;
        private string name;
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
    }
}

