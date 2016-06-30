using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Schulungsportal.Util
{
    public class Sha1Hasher
    {
        public static string Hash(string value)
        {
            Sha1Hasher hasher = new Sha1Hasher();
            return hasher.ComputeHash(value);
        }

        public string ComputeHash(string value)
        {
            var provider = new SHA1CryptoServiceProvider();
            var pwdBytes = Encoding.UTF8.GetBytes(value);
            var pwdHashBytes = provider.ComputeHash(pwdBytes);
            var hashed = Encoding.ASCII.GetString(pwdHashBytes);
            return hashed;
        }
    }
}