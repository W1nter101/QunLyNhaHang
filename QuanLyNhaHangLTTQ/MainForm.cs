using QuanLyNhaHangLTTQ.Data_Access_Object;
using QuanLyNhaHangLTTQ.Data_Tranfer_object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangLTTQ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loadTable();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Infor f = new Account_Infor();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminQuanLy f = new FormAdminQuanLy();
            f.ShowDialog();
        }
        void LoadCategory()
        {
            List<Category> list = CategoryDAO.Instance.GetListCategory();
            categoryCbb.DataSource = list;
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            FoodCbb.DataSource = listFood;
        }
        void loadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table table in tableList ) { 
                Button btn = new Button() {Width = TableDAO.width,Height = TableDAO.width};
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += Btn_Click;
                //lay table id
                btn.Tag = table;
                if (table.Status == "trống") { btn.BackColor = Color.LightCyan; }
                else { btn.BackColor = Color.Red; }
                flowLayoutPanelTable.Controls.Add(btn);
            }
        }
        void showBill(int id)
        {
            listViewDatMon.Items.Clear();
            List<MenuFood> billInfors =  MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach(MenuFood item in billInfors)
            {
                ListViewItem lvsItem = new ListViewItem(item.FoodName.ToString());
                lvsItem.SubItems.Add(item.Count.ToString());
                lvsItem.SubItems.Add(item.Price.ToString());
                lvsItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                listViewDatMon.Items.Add(lvsItem);
            }
            CultureInfo culture = new CultureInfo("vi-vn");
            tongTientxtbox.Text = totalPrice.ToString("c",culture);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).Id;
            showBill(tableId);

        }

        private void categoryCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedItem == null)
            {
                return;
            }
            Category selected = combo.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }
    }
}
