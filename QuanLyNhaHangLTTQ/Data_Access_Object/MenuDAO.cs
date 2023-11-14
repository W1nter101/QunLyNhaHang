using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        internal static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { MenuDAO.Instance = value; }
        }

        private MenuDAO(){ }
        public List<MenuFood> GetListMenuByTable(int id)
        {
            List <MenuFood> listMenu = new List<MenuFood>();
            string query = "select f.name,bi.count,f.price,f.price * bi.count as totalPrice from dbo.billInfo bi join dbo.bill b on bi.idBill = b.id join dbo.food f on f.id = bi.idFood and b.status = 0 and b.idTable = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuFood menuu = new MenuFood(item);
                listMenu.Add(menuu);
            }
            return listMenu;
        }
    }
}
