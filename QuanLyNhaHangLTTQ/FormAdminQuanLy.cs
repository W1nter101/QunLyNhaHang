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
        public FormAdminQuanLy()
        {
            InitializeComponent();
            loadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
            loadDateTimePickerBill();
        }
        private void tabPageTable_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
