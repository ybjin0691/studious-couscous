using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClubB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();

            if(result == DialogResult.Yes)
            {
                Console.WriteLine("로그인 성공");
                Console.WriteLine(HashCode.Instance.GetUserId());

                LDBStream dBStream = new LDBStream();
                Member member = dBStream.GetMember(HashCode.Instance.GetUserId());
                if(member != null)
                {
                    lblUserId.Text = member.UserId;
                    lblUserName.Text = member.UserName;
                    lblEmail.Text = member.Email;

                    if(member.Image != null && member.Image.Length > 0)
                    {
                        using(MemoryStream ms = new MemoryStream(member.Image))
                        {
                            picMyImage.Image = Image.FromStream(ms);
                            picMyImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("사용자를 찾을 수 없습니다." +
                        $"아이디 : {HashCode.Instance.GetUserId()}",
                        "로그인 정보",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                }
            }
            else
            {
                Console.WriteLine("로그인 실패");
            }


            //LDBStream dBStream = new LDBStream();


        }
    }
}
