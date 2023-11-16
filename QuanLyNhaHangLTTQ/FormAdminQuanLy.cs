using QuanLyNhaHangLTTQ.Data_Access_Object;
using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangLTTQ
{
    public partial class FormAdminQuanLy : Form
    {
        BindingSource foodList = new BindingSource();
        public FormAdminQuanLy()
        {
            InitializeComponent();
            Load();
        }
        void LoadAccountList()
        {
            string connnectionSTR = "Data Source=ANHHMINH\\SQLEXPRESS09;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connnectionSTR);
            string query = "SELECT * from dbo.Account";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            dataGridView5.DataSource = data;
        }
        void Load()
        {
            dataGridView2.DataSource = foodList;
            LoadListFood();
            AddFoodBinding();
            LoadCategoryIntoCombobox(comboBox1);
        }
        void AddFoodBinding()
        {
            textBox2.DataBindings.Add(new Binding("Text", dataGridView2.DataSource, "name"));
            txtAcoountNameInfor.DataBindings.Add(new Binding("Text",dataGridView2.DataSource,"id"));
            numericUpDown1.DataBindings.Add(new Binding("Value",dataGridView2.DataSource,"Price"));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void txtAcoountNameInfor_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int id = (int)dataGridView2.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                comboBox1.SelectedItem = category;
                int index = -1;
                int i = 0;
                foreach (Category item in comboBox1.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBox1.SelectedIndex = index;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int categoryID = (comboBox1.SelectedItem as Category).ID;
            float price = (float)numericUpDown1.Value;
            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn!");
            }

        }
    }
}
