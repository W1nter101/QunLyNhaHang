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
        public BillInfor(int ID, int IdFood, int IDBill,int count) 
        {
            this.ID = ID;
            this.idBill = idBill;
            this.IdFood = idFood;
            this.count = count;
        }
        //lay gia tri theo ten , kieu giu lieu tra ve la object nen can ep kieu ve int
        public BillInfor(DataRow row) 
        {
            this.ID = (int)row["ID"];
            this.idBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.count = (int)row["count"];
        }
        private int ID;
        private int idFood;
        private int idBill;
        private int count;
        public int ID1 { get => ID; set => ID = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Count { get => count; set => count = value; }
    }
}
