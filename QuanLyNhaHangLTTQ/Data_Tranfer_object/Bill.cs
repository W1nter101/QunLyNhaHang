using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    public class Bill
    {
        public Bill(int id,DateTime ?dayCheckin, DateTime ?daycheckout,int status) 
        {
            this.id = id;
            this.status = status;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
        }
        public Bill(DataRow row) 
        {
            this.id = (int)row["ID"];
            this.dateCheckIn = (DateTime)row["dateCheckin"];
            var checkOutDateTemp = row["dateCheckOut"];
            if(checkOutDateTemp.ToString() != "")       
                this.dateCheckOut = (DateTime)row["dateCheckOut"];
            this.status = (int)row["status"];
        }
        private int status;
        private DateTime? dateCheckIn; 
        private DateTime? dateCheckOut;
        private int id;

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
