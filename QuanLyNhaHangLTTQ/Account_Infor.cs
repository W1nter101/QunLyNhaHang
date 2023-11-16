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
    public partial class Account_Infor : Form
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
                ChangeAccount(LoginAccount);
            }

        }
        public Account_Infor(Account acc)
        {
            InitializeComponent();
            LoginAccount1 = acc;
        }

        void ChangeAccount(Account acc)
        {
            txtAcoountNameInfor.Text = LoginAccount1.UserName;
            TxtAccountInfor.Text = LoginAccount1.DisplayName;

        }
        private void QuitUpdateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void updateaccountInfo(Account acc) 
        {
            string displayname = TxtAccountInfor.Text;
            string password = txtPassInfor.Text;
            string newpass = TxtNewPassInfor.Text;
            string username = txtAcoountNameInfor.Text;
            string nhaplai = txtNhapLai.Text;
            if(!newpass.Equals(nhaplai)) 
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng!");
            }
            else
            {
                if (AccountDAO.Instance.updateAccount(username, displayname, newpass, password))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }
        private void UpdateInforBtn_Click(object sender, EventArgs e)
        {
            updateaccountInfo(LoginAccount1);
        }

        private void txtAcoountNameInfor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNhapLai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
