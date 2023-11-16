using QuanLyNhaHangLTTQ.Data_Access_Object;
using QuanLyNhaHangLTTQ.Data_Tranfer_object;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBoxTenDangNhap.Text;
            string password = textBoxMatKhau.Text;
            if (login(userName,password))
            {
                Account loginAccount  = AccountDAO.Instance.GetAccountByUserName(userName);
                
                this.Hide();
                MainForm form = new MainForm(loginAccount);
                form.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu ");
            }
            
        }
        bool login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Đồng ý thoát chương trình ?","Thông báo",MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                button2_Click(sender, e);
            }
        }
    }
}
