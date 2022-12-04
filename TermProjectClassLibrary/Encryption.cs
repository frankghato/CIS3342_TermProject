using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectLibrary
{
    public class Encryption
    {
        public static string EncryptPassword(string password)
        {
            byte[] encryptedBytes = new byte[password.Length];
            encryptedBytes = System.Text.Encoding.UTF8.GetBytes(password);
            string encryptedPassword = Convert.ToBase64String(encryptedBytes);
            return encryptedPassword;
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            System.Text.UTF8Encoding utfEncoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utfDecoder = utfEncoder.GetDecoder();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);
            int length = utfDecoder.GetCharCount(encryptedBytes, 0, encryptedBytes.Length);
            char[] decryptedCharacters = new char[length];
            utfDecoder.GetChars(encryptedBytes, 0, encryptedBytes.Length, decryptedCharacters, 0);
            string decryptedPassword = new String(decryptedCharacters);
            return decryptedPassword;
        }

    }
}
