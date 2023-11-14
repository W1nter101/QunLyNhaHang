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
        public List<BillInfor> getListBillInfor(int id)
        {
            List<BillInfor> listBillInfor = new List<BillInfor>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM ddbo.billInfor where billID = " + id);
            foreach(DataRow item in data.Rows) {
                BillInfor infor = new BillInfor(item);
                listBillInfor.Add(infor);
            }
            return listBillInfor;
        }
    }
}
