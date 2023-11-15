using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Tranfer_object
{
    internal class Food
    {
        private int iD;
        private string name;
        private int categoryID;
        private float price;
        public Food(int iD, string name, int categoryID, float price)
        {
            this.iD = iD;
            this.name = name;
            this.categoryID = categoryID;
            this.price = price;
        }
        public Food(DataRow row)
        {
            this.iD = (int)row["iD"];
            this.name = row["name"].ToString();
            this.categoryID = (int)row["idCategory"];
            this.price = (float)Convert.ToDouble(row["price"].ToString());
        }
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
    }
}
