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
        public Account_Infor()
        {
            InitializeComponent();
        }

        private void QuitUpdateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
<<<<<<< Updated upstream
=======

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
                if (AccountDAO.Instance.updateAccount(username, displayname, password, newpass))
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
>>>>>>> Stashed changes
    }
}
