﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ControlRiego
{
    static public class Util
    {
        public static string Hash(string data)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}