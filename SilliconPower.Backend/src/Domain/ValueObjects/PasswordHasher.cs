using SilliconPower.Backend.Domain.Common;
using SilliconPower.Backend.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SilliconPower.Backend.Domain.ValueObjects
{
    public class PasswordHasher : ValueObject
    {
        public string EncryptedPassword { get; private set; }

        private PasswordHasher()
        {
        }

        public static PasswordHasher EncryptPassword(string password)
        {
            var passwordHasher = new PasswordHasher();
            try
            {
                passwordHasher.EncryptedPassword = Encrypt(password);
            }
            catch (Exception ex)
            {
                throw new PasswordHasherInvalidException(password, ex);
            }
            return passwordHasher;
        }

        public string DecryptPassword()
        {
            string decryptPassword = "";
            try
            {
                decryptPassword = Decrypt(EncryptedPassword);
            }
            catch (Exception ex)
            {
                throw new PasswordHasherInvalidException(EncryptedPassword, ex);
            }
            return decryptPassword;
        }

        private static string Encrypt(string password)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public static explicit operator PasswordHasher(string password)
        {
            return EncryptPassword(password);
        }

        public override string ToString()
        {
            return EncryptedPassword;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EncryptedPassword;
        }
    }
}
