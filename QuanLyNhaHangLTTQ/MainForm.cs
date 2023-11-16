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
        private Account LoginAccount;

        public Account LoginAccount1 
        {
            get
            {
                return LoginAccount;
            }
            set
            {
                LoginAccount = value;
                ChangeAccount(LoginAccount.Type);
            }
        
        }

        public MainForm(Account acc)
        {

            InitializeComponent();
            this.LoginAccount1 = acc;
            loadTable();
            LoadCategory();
            
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text  += "("+LoginAccount1.DisplayName+")";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account_Infor f = new Account_Infor(LoginAccount);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminQuanLy f = new FormAdminQuanLy();
            f.ShowDialog();
        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            categoryCbb.DataSource = listCategory;
            categoryCbb.DisplayMember = "Name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            FoodCbb.DataSource = listFood;
            FoodCbb.DisplayMember="Name";
        }
        void loadTable()
        {
            flowLayoutPanelTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table table in tableList ) { 
                Button btn = new Button() {Width = TableDAO.width,Height = TableDAO.width};
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += Btn_Click;
                //lay table id
                btn.Tag = table;
                switch(table.Status)
                {
                    case "Có người":
                        btn.BackColor = Color.LightCyan;
                        break;
                    default:
                        btn.BackColor = Color.LightCoral;
                        break;
                }          
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
            listViewDatMon.Tag = (sender as Button).Tag;
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

        private void FoodOrderBtn_Click(object sender, EventArgs e)
        {
            //bil chua ton tai, tao bill moi, lay input tu 2 cbb 
            Table table = listViewDatMon.Tag as Table;
            int idBill = BillDAO.Instance.getUnCheckBillIDbyTableID(table.Id);
            int foodID = (FoodCbb.SelectedItem as Food).ID;
            int count = (int)numericUpDown1.Value;
            
            if(idBill == -1) 
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInforDAO.Instace.InsertBillInfo(BillDAO.Instance.getMaxIdBill(), foodID, count);
            } //bill da ton tai
            else
            {
                BillInforDAO.Instace.InsertBillInfo(idBill, foodID, count);
            }
            showBill(table.Id);
            loadTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table table = listViewDatMon.Tag as Table;
            int idBill = BillDAO.Instance.getUnCheckBillIDbyTableID(table.Id);
            if(idBill != -1) 
            {
                if (MessageBox.Show("Bạn muốn thanh toán hóa đơn bàn " + table.Name,"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.checkOut(idBill);
                    showBill(table.Id);
                    loadTable();
                }
            }
        }

        private void flowLayoutPanelTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
