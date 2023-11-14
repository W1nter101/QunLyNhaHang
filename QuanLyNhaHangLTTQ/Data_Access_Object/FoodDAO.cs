using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    internal class FoodDAO
    {
        private static FoodDAO instance;
        internal static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID (int id)
        {
            List<Food> list = new List<Food> ();
            string query = "select * from Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
    }
}
