using QuanLyNhaHangLTTQ.Data_Access_Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangLTTQ
{
    public partial class FormAdminQuanLy : Form
    {
<<<<<<< Updated upstream
=======
        BindingSource foodList = new BindingSource();

        BindingSource accountlist = new BindingSource();
>>>>>>> Stashed changes
        public FormAdminQuanLy()
        {
            InitializeComponent();
            loadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
            loadDateTimePickerBill();
        }
        private void tabPageTable_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream

=======
            string connnectionSTR = "Data Source=ANHHMINH\\SQLEXPRESS09;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connnectionSTR);
            string query = "SELECT * from dbo.Account";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            dgvAccount.DataSource = data;
>>>>>>> Stashed changes
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
<<<<<<< Updated upstream

=======
            dgvAccount.DataSource = accountlist;
            dataGridView2.DataSource = foodList;
            LoadListFood();
            AddFoodBinding();
            AddAccountBinding();
            LoadCategoryIntoCombobox(comboBox1);
        }

        void AddAccountBinding()
        {
            
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
>>>>>>> Stashed changes
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year,today.Month,1);
            dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(1).AddDays(-1);
        }
        void loadListBillByDate(DateTime checkIn,DateTime checkOut)
        {
            dataGridViewBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
