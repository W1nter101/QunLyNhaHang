using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    public class BillInfor
    {
        public BillInfor(int ID, int IdFood, int IdBill,int count) 
        {
            this.iD = ID;
            this.idBill = IdBill;
            this.IdFood = IdFood;
            this.Count = count;
        }
        //lay gia tri theo ten , kieu giu lieu tra ve la object nen can ep kieu ve int
        public BillInfor(DataRow row) 
        {
            this.iD = (int)row["ID"];
            this.idBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.count = (int)row["count"];
        }
        private int iD;
        private int idFood;
        private int idBill;
        private int count;
        public int ID { get => iD; set => iD = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Count { get => count; set => count = value; }
    }
}
