using MyClubB.DataPortal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using MyClub.MyChat;

namespace MyClubB
{
    public partial class MyClub : Form
    {
        private Member MemberInfo { get; set; }
        private string IPAddress { get; set;}
    public MyClub()
        {
            InitializeComponent();

            lblServiceName.Text = string.Empty;
            lblUserId.Text = string.Empty;
            lblUserName.Text = string.Empty;
        }

        private void btnBusInfo_Click(object sender, EventArgs e)
        {
            lblServiceName.Text = "버스 도착 정보";
            pnContent.Controls.Clear();



            ucBusArrivalInfo ucBusArrivalInfo = new ucBusArrivalInfo();
            ucBusArrivalInfo.Dock = DockStyle.Fill;
            pnContent.Controls.Add(ucBusArrivalInfo);
        }

       


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HIPCAPTION = 0x2;
        private void pnMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HIPCAPTION, 0);
            }
        }

        // HitTest 상수
        private const int HITLEFT = 10;
        private const int HITRIGHT = 11;
        private const int HITTOP = 12;
        private const int HITTOPLEFT = 13;
        private const int HITTOPRIGHT = 14;
        private const int HITBOTTOM = 15;
        private const int HITBOTTOMLEFT = 16;
        private const int HITBOTTOMRIGHT = 17;

        // 구조체 정의
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxposition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITEST = 0x84;
            const int WM_GETMINMAXINFO = 0x24;

            if(m.Msg == WM_NCHITEST)
            {
                base.WndProc(ref m);

                Point cursor = PointToClient(Cursor.Position);
                int grip = 10;

                if (cursor.X <= grip && cursor.Y <= grip)
                    m.Result = (IntPtr)HITTOPLEFT;
                else if (cursor.X >= Width - grip && cursor.Y <= grip)
                    m.Result = (IntPtr)HITTOPRIGHT;
                else if (cursor.X <= grip && cursor.Y >= Height - grip)
                    m.Result = (IntPtr)HITBOTTOMLEFT;
                else if (cursor.X >= Width - grip && cursor.Y >= Height - grip)
                    m.Result = (IntPtr)HITBOTTOMRIGHT;
                else if (cursor.Y <= grip)
                    m.Result = (IntPtr)HITTOP;
                else if (cursor.Y >= Height - grip)
                    m.Result = (IntPtr)HITBOTTOM;
                else if (cursor.X <= grip)
                    m.Result = (IntPtr)HITLEFT;
                else if (cursor.X >= Width - grip)
                    m.Result = (IntPtr)HITRIGHT;

                return;

            }
            else if (m.Msg == WM_GETMINMAXINFO)
            {
                MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));

                mmi.ptMinTrackSize.x = 430;
                mmi.ptMinTrackSize.y = 300;
                mmi.ptMaxTrackSize.x = 768;
                mmi.ptMaxTrackSize.y = 1024;

                Marshal.StructureToPtr(mmi, m.LParam, true);
                return;
            }

            base.WndProc(ref m);
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            lblServiceName.Text = "내정보";
        }
            
        private void btnChatting_Click(object sender, EventArgs e)
        {
            lblServiceName.Text = "채팅";
            pnContent.Controls.Clear();

            if(MemberInfo == null)
            {
                LoginForm loginForm = new LoginForm();
                DialogResult result = loginForm.ShowDialog();

                if(result == DialogResult.None)
                {
                    MessageBox.Show("로그인에 실패하였습니다.", "Myclub 로그인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string userId = HashCode.Instance.GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    MessageBox.Show("로그인 ID 정보가 없습니다.", "Myclub 로그인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LDBStream dBStream = new LDBStream();
                MemberInfo = dBStream.GetMember(userId);

                lblUserId.Text = $"아이디 : {MemberInfo.UserId}";
                lblUserName.Text = $"이름 : {MemberInfo.UserName}";

                HostAddress();
                if (string.IsNullOrEmpty(IPAddress))
                {
                    MessageBox.Show("인터넷에 연결되지 않아 채팅을 시작할 수 없습니다."
                        , "인터넷 연결 없음"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ucMyChat ucMyChat = new ucMyChat(MemberInfo.UserId,MemberInfo.UserName,IPAddress, MemberInfo.Image);
                ucMyChat.Dock = DockStyle.Fill;
                pnContent.Controls.Add(ucMyChat);

            }
            else
            {
                lblServiceName.Text += $"\r\n{IPAddress}";


                    //ucMyChat ucMyChat = new ucMyChat(MemberInfo.UserId, MemberInfo.UserName, IPAddress, MemberInfo.Image);
                    //ucMyChat.Dock = DockStyle.Fill;
                    //pnContent.Controls.Add(ucMyChat);
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HostAddress()
        {
            try
            {
                string localIpAddress = Dns.GetHostEntry(Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                    ?.ToString();
                IPAddress = string.IsNullOrWhiteSpace(localIpAddress) ? " 확인안됨" : localIpAddress;
                lblServiceName.Text += $"\r\n{IPAddress}";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "인터넷 없음", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IPAddress = null;
                lblServiceName.Text += "\r\n인터넷 없음";
            }
        }
    }
}
