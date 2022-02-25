using System;
using System.Collections.Generic;
using System.IO;
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
        public static void Log(string text)
        {
            using (StreamWriter sw = File.AppendText("console.log"))
            {
                sw.WriteLine(text);
                sw.Close();
                Console.WriteLine(text);
            }
        }
    }
}
