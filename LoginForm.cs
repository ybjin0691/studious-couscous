using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClubB
{
    public partial class LoginForm : Form
    {
        DialogResult _result = DialogResult.No;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _result;           
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string userId = tBox_userId.Text;
            string userPwd = tBox_userPwd.Text;

            if (string.IsNullOrEmpty(userId.Trim()))
            {
                MessageBox.Show(
                    "사용자 ID를 입력하세요."
                    , "로그인"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(userPwd.Trim()))
            {
                MessageBox.Show(
                    "패스워드를 입력하세요."
                    , "로그인"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            string shaUserId = HashCode.Instance.HasConvert(userId);
            Console.WriteLine($"{userId}, {shaUserId}");
            //donguk, 3c31834e9178e3970d579e6dae7ae5a418223bcdeda6fdc4ead58f7fbca9b0f8
            //q1w2e3, ae5a853873043c7b011c6300c464d8d4014bf833697a3c01817d83aa91a53166
            LDBStream dbStream = new LDBStream();
            if(dbStream.LoginCheck(userId, userPwd))
            {
                _result = DialogResult.Yes;
                HashCode.Instance.SetUserId(userId);
            }

            this.Close();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm();
            joinForm.ShowDialog();
            //joinForm.Show();
        }

    }
}
