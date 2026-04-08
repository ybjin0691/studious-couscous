using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using MyClub.MyChat;

namespace MyClubB.MyChat
{
    internal class ChatServer
    {
        private TcpListener _server;
        private bool _isRunning = false;
        private readonly List<ChatUser> _users = new List<ChatUser>();
        private readonly object _lock = new object();

        public event Action<string> LogReceived;
        public event Action<ChatPayload> MessageReceived;

        public void StartServer(string ipAddress, int port)
        {
            if (_isRunning) { return; }

            _server = new TcpListener(IPAddress.Parse(ipAddress), port);
            _server.Start();
            _isRunning = true;

            LogReceived?.Invoke("서버 시작 : 클라이언트 연결을 기다립니다.");

            Thread acceptThread = new Thread(AcceptClients) { IsBackground = true };
            acceptThread.Start();
        }

        private void AcceptClients()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = _server.AcceptTcpClient();
                    //Thread clientThread = new Thread(() => HandleClient(client)) { IsBackground = true };
                    //clientThread.Start();
                    ThreadPool.QueueUserWorkItem(state => { HandleClient((TcpClient)state); }, client);
                }
                catch (SocketException) { break; }
                catch (Exception ex) { LogReceived?.Invoke("클라이언트 연결 오류 : " + ex.Message); }

            }
        }
        private void HandleClient(TcpClient client)
        {
            ChatUser newUser = null;

            try
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                {
                    string userInfos = reader.ReadLine();
                    string[] userInfo = userInfos?.Split(',');

                    if(userInfo == null || userInfo.Length != 2)
                    {
                        writer.WriteLine("잘못된 입력입니다. 연결을 종료합니다.");
                        return;
                    }

                    string userId = userInfo[0].Trim();
                    string userName = userInfo[1].Trim();

                    newUser = new ChatUser(userId, userName, client);
                    lock (_lock) _users.Add(newUser);

                    LogReceived?.Invoke($"{userName}님이 연결되었습니다.");
                    Broadcast($"{userName}님이 채팅에 참여하였습니다.", client);

                    string json;
                    while ((json = reader.ReadLine()) != null)
                    {
                        try
                        {
                            var payload = JsonConvert.DeserializeObject<ChatPayload>(json);
                            Broadcast (json, client);
                        }
                        catch (Exception ex)
                        {
                            LogReceived?.Invoke($"메세지 처리 오류 : {ex.Message}");
                        }
                    } 
                }
            }
            catch (IOException)
            {
                if (newUser != null)
                    LogReceived?.Invoke($"{newUser.UserName}의 연결이 끊겼습니다.");
            }
            finally
            {
                if (newUser!= null)
                {
                    lock (_lock) _users.Remove(newUser);
                    Broadcast($"{newUser.UserName}님이 채팅을 종료하였습니다.", client);
                    newUser.Client.Close();
                }
            }
        }
        private void Broadcast(string json, TcpClient sender)
        {
            List<ChatUser> usersTmp;
            lock (_users) { usersTmp = _users.ToList(); }

            Parallel.ForEach(usersTmp, user =>
            {
                try
                {
                    lock (user.Writer) { user.Writer.WriteLine(json); }
                }
                catch
                {

                }
            });
        }

        public void StopServer()
        {
            _isRunning = false;

            lock (_lock)
            {
                foreach (var user in _users)
                {
                    try
                    {
                        user.Writer?.WriteLine("서버가 종료되었습니다.");
                        user.Writer?.Flush();
                        user.Writer?.Dispose();

                        user.Client?.Close();
                        user.Client?.Dispose();
                    }
                    catch { }
                }
                _users.Clear();
            }
            try { _server.Stop(); }
            catch (Exception ex) { LogReceived?.Invoke("서버 종료 중 오류"); }

            LogReceived?.Invoke("서버가 종료되었습니다.");
        }
    }
}
