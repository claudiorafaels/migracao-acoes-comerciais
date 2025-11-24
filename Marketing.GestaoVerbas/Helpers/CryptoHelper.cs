
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;





    public static class CryptoHelper
    {
        // Chaves fixas de exemplo (prod: guarde em appSettings/KeyVault)
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("2e#A9!k@3pLz7mXc4tQv8yBzRjTgWf6d"); // 32 bytes (AES-256)
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("5hG8kL0pR2tV9zX1");                 // 16 bytes

        public static string EncryptObject(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] plain = Encoding.UTF8.GetBytes(json);
            byte[] cipher = Encrypt(plain, Key, IV);
            return Convert.ToBase64String(cipher);
        }

        public static T DecryptObject<T>(string base64)
        {
            byte[] cipher = Convert.FromBase64String(base64);
            byte[] plain = Decrypt(cipher, Key, IV);
            string json = Encoding.UTF8.GetString(plain);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;      // padrão seguro
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }

        private static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream(data))
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var outMs = new MemoryStream())
                {
                    cs.CopyTo(outMs);
                    return outMs.ToArray();
                }
            }
        }
    }


