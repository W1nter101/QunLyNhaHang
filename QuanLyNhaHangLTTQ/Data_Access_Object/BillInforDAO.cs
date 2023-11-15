using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    internal class BillInforDAO
    {
        private static BillInforDAO instace;

        internal static BillInforDAO Instace {
            get { if (instace == null) instace = new BillInforDAO(); return BillInforDAO.instace; }
            private set { BillInforDAO.instace = value; }
        }
        private BillInforDAO() { }
        public List<BillInfor> getListBillInfor(int id) //id cua bill => bill info
        {
            List<BillInfor> listBillInfor = new List<BillInfor>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.billInfor where idBill = " + id);
            foreach(DataRow item in data.Rows) {
                BillInfor infor = new BillInfor(item);
                listBillInfor.Add(infor);
            }
            return listBillInfor;
        }
        public void InsertBillInfo(int idBill,int idFood,int count)
        {
            DataProvider.Instance.ExcuteQuery("exec InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });

        }
    }
}
