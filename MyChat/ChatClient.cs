using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;
using MyClub.MyChat;
using System.Threading;

namespace MyClubB.MyChat
{
    internal class ChatClient
    {
        private TcpClient _client;
        private StreamWriter _writer;
        private StreamReader _reader;
        private Thread _receiveThread;
        private bool _isConnected = false;
        private Guid _lastSentMessageId;

        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public byte[] UserImage { get; private set; }

        public event Action<string> LogReceived;
        public event Action<ChatPayload, bool> MessageReceived;

        public bool Connect(string serverIp, int port, string userId, string userName, byte[] userImage)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(serverIp, port);

                var stream = _client.GetStream();
                _writer = new StreamWriter(stream) { AutoFlush = true };
                _reader = new StreamReader(stream);

                UserId = userId;
                UserName = userName;
                UserImage = userImage;

                _writer.WriteLine($"{UserId},{UserName}");

                _receiveThread = new Thread(ReceiveLoop) { IsBackground = true };
                _receiveThread.Start();

                _isConnected = true;
                LogReceived?.Invoke("서버에 연결되었습니다.");

                return true;
            }
            catch(Exception ex)
            {
                LogReceived?.Invoke("서버 연결 실패: " + ex.Message);
                return false;
            }
        }

        public void SendMessage(string message)
        {
            if(_isConnected && !string.IsNullOrWhiteSpace(message))
            {
                var id = Guid.NewGuid();
                _lastSentMessageId = id;

                var payload = new ChatPayload
                {
                    UserId = this.UserId,
                    UserName = this.UserName,
                    Message = message,
                    TimeStamp = DateTime.Now,
                    MessageId = id,
                    UserImage = UserImage
                };

                string json = JsonConvert.SerializeObject(payload);
                _writer.WriteLine(json);
            }

            
        }
        private void ReceiveLoop()
        {
            try
            {
                string json;
                while((json = _reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(json))
                        continue;

                    ChatPayload payload = null;
                    try
                    {
                        payload = JsonConvert.DeserializeObject<ChatPayload>(json);
                    }
                    catch (Exception ex)
                    {
                        LogReceived?.Invoke($"메세지 파싱 오류: {ex.Message}");
                        continue;
                    }

                    if (payload == null)
                    {
                        LogReceived?.Invoke("수신한 메세지가 null 입니다.");
                        continue;
                    }

                    bool isMine = payload.UserId == this.UserId;
                    Console.WriteLine($"Clinet : {isMine}");

                    MessageReceived?.Invoke(payload, isMine);
                }
            }
            catch (IOException) { LogReceived?.Invoke("서버 연결이 끊어졌습니다."); }
            catch (Exception ex) { LogReceived?.Invoke($"수신 중 오류 발생 : {ex.Message}");}
            finally { Disconnect(); }
            
        }
        public void Disconnect()
        {
            if (!_isConnected) return;

            _isConnected = false;
            _writer?.Close();
            _reader?.Close();
            _client?.Close();
            LogReceived?.Invoke("서버와 연결이 종료되었습니다.");
        }

    }
    
}
