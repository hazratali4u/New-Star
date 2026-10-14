namespace SAMS.Common.Classes
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class Encryption
    {
        private static byte[] bytIV;
        private static byte[] bytKey;
        private SymmetricAlgorithm mobjCryptoService = new DESCryptoServiceProvider();

        private static byte[] CreateIV(string strPassword)
        {
            int num2;
            char[] chArray = strPassword.ToCharArray();
            byte[] buffer = new byte[chArray.GetUpperBound(0) + 1];
            for (num2 = 0; num2 <= chArray.GetUpperBound(0); num2++)
            {
                buffer[num2] = Convert.ToByte(chArray[num2]);
            }
            byte[] buffer2 = new SHA512Managed().ComputeHash(buffer);
            byte[] buffer3 = new byte[0x10];
            for (num2 = 0x20; num2 <= 0x2f; num2++)
            {
                buffer3[num2 - 0x20] = buffer2[num2];
            }
            return buffer3;
        }

        private static byte[] CreateKey(string strPassword)
        {
            int num2;
            char[] chArray = strPassword.ToCharArray();
            byte[] buffer = new byte[chArray.GetUpperBound(0) + 1];
            for (num2 = 0; num2 <= chArray.GetUpperBound(0); num2++)
            {
                buffer[num2] = (byte) chArray[num2];
            }
            byte[] buffer2 = new SHA512Managed().ComputeHash(buffer);
            byte[] buffer3 = new byte[0x20];
            for (num2 = 0; num2 <= 0x1f; num2++)
            {
                buffer3[num2] = buffer2[num2];
            }
            return buffer3;
        }

        public static string DecryptFiles(string pEncryptedSourceFile, string pKey)
        {
            FileStream stream = null;
            FileStream stream2 = null;
            string str2;
            string path = pEncryptedSourceFile.Substring(0, pEncryptedSourceFile.IndexOf('.')) + ".zip";
            bytKey = CreateKey(pKey);
            bytIV = CreateIV(pKey);
            try
            {
                stream = new FileStream(pEncryptedSourceFile, FileMode.Open, FileAccess.Read);
                stream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                stream2.SetLength(0L);
                byte[] buffer = new byte[0x1001];
                long num = 0L;
                long length = stream.Length;
                CryptoStream stream3 = null;
                RijndaelManaged managed = new RijndaelManaged();
                stream3 = new CryptoStream(stream2, managed.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write);
                while (num < length)
                {
                    int count = stream.Read(buffer, 0, 0x1000);
                    stream3.Write(buffer, 0, count);
                    num += count;
                }
                stream3.Close();
                stream.Close();
                stream2.Close();
                FileInfo info = new FileInfo(pEncryptedSourceFile);
                str2 = path;
            }
            catch (FileNotFoundException exception)
            {
                throw exception;
            }
            catch
            {
                stream.Close();
                stream2.Close();
                new FileInfo(path).Delete();
                str2 = null;
            }
            return str2;
        }

        public string Decrypting(string Source, string Key)
        {
            byte[] buffer = Convert.FromBase64String(Source);
            MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
            byte[] legalKey = this.GetLegalKey(Key);
            this.mobjCryptoService.Key = legalKey;
            this.mobjCryptoService.IV = legalKey;
            ICryptoTransform transform = this.mobjCryptoService.CreateDecryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(stream2);
            return reader.ReadToEnd();
        }

        public static string EncryptFiles(string pSourceFileName, string pKey)
        {
            FileStream stream = null;
            FileStream stream2 = null;
            string str2;
            string path = pSourceFileName.Substring(0, pSourceFileName.IndexOf('.')) + ".dat";
            bytKey = CreateKey(pKey);
            bytIV = CreateIV(pKey);
            try
            {
                stream2 = new FileStream(pSourceFileName, FileMode.Open, FileAccess.Read);
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                stream.SetLength(0L);
                byte[] buffer = new byte[0x1001];
                long num = 0L;
                long length = stream2.Length;
                CryptoStream stream3 = null;
                RijndaelManaged managed = new RijndaelManaged();
                stream3 = new CryptoStream(stream, managed.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
                while (num < length)
                {
                    int count = stream2.Read(buffer, 0, 0x1000);
                    stream3.Write(buffer, 0, count);
                    num += count;
                    int num4 = ((int) (num / length)) * 100;
                }
                stream3.Close();
                stream2.Close();
                stream.Close();
                FileInfo info = new FileInfo(pSourceFileName);
                str2 = path;
            }
            catch (FileNotFoundException exception)
            {
                throw exception;
            }
            catch
            {
                stream2.Close();
                stream.Close();
                new FileInfo(pSourceFileName).Delete();
                str2 = null;
            }
            return str2;
        }

        public string Encrypting(string Source, string Key)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(Source);
            MemoryStream stream = new MemoryStream();
            byte[] legalKey = this.GetLegalKey(Key);
            this.mobjCryptoService.Key = legalKey;
            this.mobjCryptoService.IV = legalKey;
            ICryptoTransform transform = this.mobjCryptoService.CreateEncryptor();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            byte[] buffer = stream.GetBuffer();
            int index = 0;
            index = 0;
            while (index < buffer.Length)
            {
                if (buffer[index] == 0)
                {
                    break;
                }
                index++;
            }
            return Convert.ToBase64String(buffer, 0, index);
        }

        private byte[] GetLegalKey(string Key)
        {
            string str;
            if (this.mobjCryptoService.LegalKeySizes.Length > 0)
            {
                int num = 0;
                int minSize = this.mobjCryptoService.LegalKeySizes[0].MinSize;
                while ((Key.Length * 8) > minSize)
                {
                    num = minSize;
                    minSize += this.mobjCryptoService.LegalKeySizes[0].SkipSize;
                }
                str = Key.PadRight(minSize / 8, ' ');
            }
            else
            {
                str = Key;
            }
            return Encoding.ASCII.GetBytes(str);
        }

        public enum SymmProvEnum
        {
            DES,
            RC2,
            Rijndael
        }
    }
}

