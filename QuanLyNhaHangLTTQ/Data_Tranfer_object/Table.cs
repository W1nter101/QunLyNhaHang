using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    internal class Table
    {
        public Table(int id, string name, string Status) {
            this.id = id;
            this.name = name;
            this.Status = Status;
        }
        public Table(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = (string)row["name"];
            this.Status = (string)row["status"];
        }
        private string name;
        private string status;
        private int id;
        public string Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
