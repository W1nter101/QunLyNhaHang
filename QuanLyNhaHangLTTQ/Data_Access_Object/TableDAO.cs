using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    internal class TableDAO
    {
        private static TableDAO instance;
        public static int height = 100;
        public static int width = 100;
        internal static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
           private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> tblist = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tblist.Add(table);
            }
            return tblist;

        }
    }
}
