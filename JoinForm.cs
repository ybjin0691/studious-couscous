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
    public partial class JoinForm : Form
    {
        private string SelectImgPath { get; set; }

        public JoinForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            string userId = tbUserId.Text.Trim();
            string userPwd = tbPasword.Text.Trim();
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("아이디를 입력하세요."
                    , "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(userPwd))
            {
                MessageBox.Show("비밀번호를 입력하세요."
                    , "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPasword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("이름을 입력하세요."
                    , "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("이메일을 입력하세요."
                    , "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            LDBStream dbStream = new LDBStream();
            if(dbStream.SaveMember(userId, userPwd, name, email, SelectImgPath))
            {
                MessageBox.Show("MyClub 회원가입이 완료되었습니다.\r\n" +
                    "로그인 해주세요."
                    , "회원가입"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("MyClub 회원가입에 실패하였습니다.\r\n" +
                    "오류 정보를 확인해주세요."
                    , "회원가입"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofd.Multiselect = false;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picImage.Image = Image.FromFile(ofd.FileName);
                    picImage.SizeMode = PictureBoxSizeMode.Zoom;
                    SelectImgPath = ofd.FileName;
                }
                catch(Exception fail)
                {
                    Console.WriteLine($"Error : {fail.Message}");
                }
            }
        }
    }
}
