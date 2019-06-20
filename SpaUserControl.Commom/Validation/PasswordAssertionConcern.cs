using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using SpaUserControl.Commom.Validation.Resources;

namespace SpaUserControl.Commom.Validation
{
    public class PasswordAssertionConcern
    {
        public static void AssertIsValid(string password)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidPassword);
        }

        public static string Encrypt(string password)
        {
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
