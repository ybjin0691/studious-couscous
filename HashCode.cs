using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MyClubB
{
    internal class HashCode
    {
        private string UserId { get; set; }

        public string GetUserId()
        {
            return UserId;
        }

        public void SetUserId(string userId)
        {
            UserId = userId;
        }


        private static HashCode _instance;
        public static HashCode Instance
        {
            get
            {
                if (_instance == null) { _instance = new HashCode(); }
                return _instance;
            }
        }

        public string HasConvert(string value)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
