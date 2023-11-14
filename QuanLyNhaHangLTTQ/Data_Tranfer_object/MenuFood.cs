using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    public class MenuFood
    {
        public MenuFood(string foodName,int count, float price,float totalPrice) 
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.totalPrice = TotalPrice;
        }
        public MenuFood(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
            this.totalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
        private string foodName;
        private int count;
        private float price;
        private float totalPrice;
        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
