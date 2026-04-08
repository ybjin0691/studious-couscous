using MyClubB.MyChat;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyClub.MyChat
{
    

    public partial class ucMyChat : UserControl
    {
        private string UserId { get; set; }
        private string UserName { get; set; }
        private byte[] UserImage { get; set; }
        private string ServerIP { get; set; }
        private readonly int _port = 5000;
        private readonly int _remotePort = 5000;

        private ChatServer chatServer;
        private ChatClient chatClient;
        private FlowLayoutPanel flpSystemMessage;

        public ucMyChat(string userId, string userName, string serverIP, byte[] userImage)
        {
            UserId = userId;
            UserName = userName;
            ServerIP = serverIP;
            UserImage = userImage;

            InitializeComponent();

            rdoServer.Click += RadioButton_Click;
            rdoClient.Click += RadioButton_Click;
            rtbMessage.Enabled = false;            
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            if (rdoServer.Checked)
            {
                lblTitle_ip.Enabled = false;
                tboxValue_address.Enabled = false;
                btnStart.Text = "서버실행";
            }
            else if (rdoClient.Checked)
            {
                lblTitle_ip.Enabled = true;
                tboxValue_address.Enabled = true;
                btnStart.Text = "서버접속";
            }
        }    

		private void rtbMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (e.Shift)
                {
                    return;
                }

                e.Handled = true;

                string message = rtbMessage.Text.TrimEnd();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    chatClient?.SendMessage(message);
                }

				rtbMessage.Clear();
			}
		}		

        private void btnStart_Click(object sender, EventArgs e)
        {
            {
                if (chatServer != null)
                {
                    btnStart.Text = "서버시작";
                    chatServer.StopServer();
                    chatServer = null;
                    lblTitle_ip.Enabled = true;
                    rdoClient.Enabled = true;
                    rdoServer.Enabled = true;
                    tboxValue_address.Enabled = true;
                    rtbMessage.Enabled = false;
                    return;
                }
                else if (chatClient != null)
                {
                    btnStart.Text = "서버접속";
                    chatClient.Disconnect();
                    chatClient = null;
                    lblTitle_ip.Enabled = true;
                    rdoClient.Enabled = true;
                    rdoServer.Enabled = true;
                    tboxValue_address.Enabled = true;
                    rtbMessage.Enabled = false;
                    return;
                }

                if (rdoServer.Checked)
                {
                    flpSystemMessage = null;
                    flpMessage.Controls.Clear();

                    chatServer = new ChatServer();
                    chatServer.LogReceived += LogToChat;
                    chatServer.MessageReceived += MessageToChat;
                    chatServer.StartServer(ServerIP, 5014);

                    ConnectClient(ServerIP, _port, UserId, UserName);
                }
                else if (rdoClient.Checked)
                {
                    string ipAddress = tboxValue_address.Text.Trim();
                    if (string.IsNullOrEmpty(ipAddress))
                    {
                        MessageBox.Show("접속할 서버 IP를 입력해주세요.\r\n" +
                            "앞/뒤/옆 사람과 함께하세요."
                            , "서버접속"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // IPv4 정규 표현식
                    string ipv4Pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

                    if (!Regex.IsMatch(ipAddress, ipv4Pattern))
                    {
                        MessageBox.Show("입력한 서버 주소는 IPv4의 형식이 아닙니다.\r\n" +
                            "서버 IP를 다시 입력하세요."
                            , "서버접속"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ConnectClient(ipAddress, _remotePort,  UserId, UserName);


                }
            }
            
        }
        

        private void ConnectClient(string ipAddress, int port, string userId, string userName)
        {
            chatClient = new ChatClient();
            chatClient.LogReceived += LogToChat;
            chatClient.MessageReceived += (payload, isMine) => { AppendChat(payload, isMine); };

            bool success = chatClient.Connect(ipAddress, port, userId, userName, UserImage);
            if (!success)
            {
                MessageBox.Show($"{ipAddress} 서버에 연결할 수 없습니다."
                    , "서버연결"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            rtbMessage.Enabled = true;
            rdoClient.Enabled = false;
            rdoServer.Enabled = false;
        }

        private void LogToChat(string message)
        {
            Console.WriteLine($"System 1 : {message}");

            if(message.Contains("메세지 파싱 오류")) { return; }
            if (message.Contains("서버에 연결되었")) { return; }
            if(message.Contains("서버 시작"))
            {
                btnStart.Invoke(new Action(() => btnStart.Text = "서버종료"));
                message = message.Split(':')[1].Trim();
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogToChat(message)));
                return;
            }

            if(flpSystemMessage == null)
            {
                flpSystemMessage = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Dock = DockStyle.Top,
                    Padding = new Padding(0),
                    BackColor = Color.Transparent,
                    Margin = new Padding(0, 0, 0, 10)
                };
                flpMessage.Controls.Add(flpSystemMessage);
                flpMessage.Controls.SetChildIndex(flpSystemMessage, 0);

                
            }

            var lbl = new RoundedLabel
            {
                Text = $"[{DateTime.Now:HH:mm}] {message}",
                Font = new Font("맑은 고딕", 9),
                ForeColor = Color.DimGray,
                BorderColor = Color.DimGray,
                FillColor = Color.WhiteSmoke,
                CornerRadius = 10,
                AutoSize = true,
                Padding = new Padding(10, 5, 10, 5),
                Margin = new Padding(0, 2, 0, 2),
            };

            flpSystemMessage.Controls.Add(lbl);
            flpSystemMessage.PerformLayout();
        }

        private void MessageToChat(ChatPayload payload)
        {
            AppendChat(payload, false);
        }
        private void AppendChat(ChatPayload payload, bool isMine)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendChat(payload, isMine)));
                return;
            }

            Console.WriteLine($"AppendChat 호출됨 : {payload.UserName}, isMine = {isMine}" +
                $", Message : {payload.Message}");
        }
    }
}
