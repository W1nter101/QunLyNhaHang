using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangLTTQ.Data_Access_Object
{
    internal class DataProvider
    {
        private static DataProvider instance;
        internal static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return  DataProvider.instance; }
            set { DataProvider.instance = value; } 
        }

        private DataProvider() {}
        string connectionSQL = "Data Source=ANHHMINH\\SQLEXPRESS09;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        public DataTable ExcuteQuery(string query, object[] parameter =null) //truong hop can chay them procedure
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //kiem tra parameter
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if(item.Contains('@')) //add dc n+ parameter
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]); 
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        //tinh so dong thanh cong 
        public int ExcuteNonQuery(string query, object[] parameter = null) //truong hop can chay them procedure
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //kiem tra parameter
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@')) //add dc n+ parameter
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        //tra ve o dau tien trong bang ket qua , phu hop select count * 
        public object ExcuteScalar(string query, object[] parameter = null) //truong hop can chay them procedure
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //kiem tra parameter
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@')) //add dc n+ parameter
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
