﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AmazonOrderExtentions.CoreExtentions
{
    public static class EncryptionHelper
    {
        //private NLog.Logger _Encry = NLog.LogManager.GetLogger("AmazonOrderLOG");

        public static string Encrypt(this string clearText)
        {
            Rfc2898DeriveBytes pdb;
            try
            {
                if (string.IsNullOrEmpty(clearText))
                {
                    return clearText;
                }

                string EncryptionKey = "46899A8489D457B93E3C5348B981BSoftpal";
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                pdb = null;
            }

        }

        public static string Decrypt(this string cipherText)
        {
            Rfc2898DeriveBytes pdb;
            try
            {
                if (string.IsNullOrEmpty(cipherText))
                {
                    return cipherText;
                }

                string EncryptionKey = "46899A8489D457B93E3C5348B981BSoftpal";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                pdb = null;
            }
        }
    }
}