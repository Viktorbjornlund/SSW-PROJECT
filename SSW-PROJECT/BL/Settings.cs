﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BL
{
    public static class Settings
    {
        private static string _connectionString= @"Data Source=DESKTOP-7CHA0RF\SQLEXPRESS;Initial Catalog=SSW;Integrated Security=True;Pooling=False";
        public static string ConnectionString
        {
            set { _connectionString = value; }
            get { return _connectionString; }
        }

        public static string SecureString(string clear)
        {
            HashAlgorithm algo = MD5.Create();
            byte[] hash = algo.ComputeHash(Encoding.UTF8.GetBytes(clear));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var bytes = new Byte[32];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
