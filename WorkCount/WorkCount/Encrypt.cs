using CryptSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCount
{
    class Encrypt
    {
        public static string Encrypter(string text)
        {
            string salt = "A23S";
            var keyBytes = Encoding.UTF8.GetBytes(text);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var cost = 262144;
            var blockSize = 8;
            var parallel = 1;
            var maxThreads = (int?)null;
            var derivedKeyLength = 256;
            var bytes = SCrypt.ComputeDerivedKey(keyBytes, saltBytes, cost, blockSize, parallel, maxThreads, derivedKeyLength);
            return Convert.ToBase64String(bytes);
        }
    }
}
