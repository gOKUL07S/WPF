using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AES_Algorithm
{
    class Program
    {


        //static void Main(string[] args)
        //{
        //    Console.Write("Enter a string to generate an AES key: ");
        //    byte[] aesKey = GenerateAesKey(@"gokulsakthi777@expensetrakcer_0");
        //    Console.WriteLine("Generated AES key:");
        //    Console.WriteLine(BitConverter.ToString(aesKey).Replace("-", "")); // Convert bytes to hexadecimal string
        //    Console.ReadLine();
        //    Console.ReadKey();
        //}
        static void Main(string[] args)
        {
            String text = "Gokul@12";

            Tuple<String, String> encryptedString = Encrypt(text);

            //String decrptedText = Decrypt(encryptedString.Item1, encryptedString.Item2);
            String decrptedText = Decrypt(encryptedString.Item1, encryptedString.Item2);
            //String decrptedText = Decrypt(encryptedString.Item1, "UbDvG8QZPriozKnHgl2fztDETqd7XYCDkdlNB8HhHUU=");

            bool isEqual = (text == decrptedText);
        }

        private static Tuple<String, String> Encrypt(String text)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(text);
            using (Aes aes = Aes.Create())
            {
                //aes.GenerateKey();
                aes.Key = GenerateAesKey(@"santhiyadevi1302@expensetracker_0");
                Console.WriteLine(BitConverter.ToString(aes.Key).Replace("-", ""));
                aes.GenerateIV();
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream msEncrpt = new MemoryStream())
                {
                    msEncrpt.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream cStream = new CryptoStream(msEncrpt, encryptor, CryptoStreamMode.Write))
                    {
                        cStream.Write(plainBytes, 0, plainBytes.Length);
                        cStream.FlushFinalBlock();
                        return new Tuple<String, String>(Convert.ToBase64String(msEncrpt.ToArray()), Convert.ToBase64String(aes.Key));
                    }
                }
            }
        }

        private static string Decrypt(String encryptedText, String key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(encryptedBytes, iv, iv.Length);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv);
                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length))
                {
                    using (CryptoStream cDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(cDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        static byte[] GenerateAesKey(string inputString)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                byte[] aesKey = new byte[32];
                Array.Copy(hashedBytes, aesKey, 32);

                return aesKey;
            }
        }

    }
}
