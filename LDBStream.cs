using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data.SQLite;
using System.Dynamic;
using System.Windows.Forms;

namespace MyClubB
{
    internal class LDBStream
    {
        private readonly string dbFilePath;

        public LDBStream()
        {
            string currentDirectory = Environment.CurrentDirectory;
            dbFilePath = Path.Combine(currentDirectory, "myClub.db");
            Console.WriteLine(dbFilePath);

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();

                #region 테이블 생성
                string strQuery = "CREATE TABLE IF NOT EXISTS member(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT" +
                    ", userId VARCHAR(10) NOT NULL, userPwd VARCHAR(300) NOT NULL" +
                    ", userName VARCHAR(5) NOT NULL, email VARCHAR(50) NOT NULL" +
                    ", image BLOB" +
                    ", createAt TEXT DEFAULT CURRENT_TIMESTAMP" +
                    ");";

                try
                {
                    using (var command = new SQLiteCommand(strQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                #endregion

                Console.WriteLine("Initialize Database");
            }
        }

        private SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection($"Data Source={dbFilePath};Version=3");
        }


        private bool verifyPassword(string userPwd, string storedPwd)
        {
            Console.WriteLine($"{userPwd}, {storedPwd}");
            return HashCode.Instance.HasConvert(userPwd) == storedPwd;
        }

        public bool LoginCheck(string userId, string userPwd)
        {
            bool result = false;

            using(var connection = CreateConnection())
            {
                connection.Open();
                Console.WriteLine("로그인 체크");
                string strQuery = "SELECT userPwd FROM member" +
                    " WHERE userId = @UserId";
                using(SQLiteCommand command = new SQLiteCommand(
                    strQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    var password = command.ExecuteScalar();

                    if(password == null) { return false; }

                    string storedPwd = password.ToString();

                    if(verifyPassword(userPwd, storedPwd))
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        public bool SaveMember(string userId, string userPwd, string name, string email
            , string imgPath)
        {
            bool result = false;
            byte[] imgData = null;

            if (!string.IsNullOrEmpty(imgPath))
            {
                imgData = File.ReadAllBytes(imgPath);
            }

            using(var connection = CreateConnection())
            {
                connection.Open();
                string strQuery = $"INSERT INTO member(" +
                    "userId, userPwd, userName, email, image" +
                    ") VALUES (" +
                    "@UserId, @UserPwd, @UserName, @Email, @Image" +
                    ")";
                Console.WriteLine(strQuery);

                using(SQLiteCommand command = new SQLiteCommand(strQuery, connection))
                {
                    try
                    {
                        string shaPassword = HashCode.Instance.HasConvert(userPwd);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@UserPwd", shaPassword);
                        command.Parameters.AddWithValue("@UserName", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Image", imgData);
                        command.ExecuteNonQuery();
                        result = true;
                    }
                    catch(Exception fail)
                    {
                        Console.WriteLine(fail.Message);
                    }
                }
            }

            return result;
        }

        public Member GetMember(string userId)
        {
            string strQuery = "SELECT * FROM member WHERE userId=@UserId";
            using (SQLiteConnection connection = CreateConnection())
            {
                connection.Open();

                using(SQLiteCommand command = new SQLiteCommand(strQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Member member = new Member
                            {
                                UserId = reader["userId"].ToString(),
                                UserName = reader["userName"].ToString(),
                                Email = reader["email"].ToString(),
                                Image = reader["image"] as byte[]
                            };

                            return member;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


    }
}
