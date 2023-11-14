using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    internal class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance 
        {
            get { if(instance == null) instance = new BillDAO(); return BillDAO.Instance; }
            private set { BillDAO.instance = value; } 
        }
        private BillDAO() { }
        //tim so luong, xem thu co thanh cong hay khong, chuyen thanh bill roi lay id ra ; Thanh cong = bill.id , that bai -1
        public int getUnCheckBillIDbyTableID(int id)
        {
            //  return (int)DataProvider.Instance.ExcuteScalar("select * from dbo.bill where  id = '" +id+ "' ");
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from from dbo.bill where id table = '"+id+"' and  status = 0");             
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1; 
        }
    }
}
