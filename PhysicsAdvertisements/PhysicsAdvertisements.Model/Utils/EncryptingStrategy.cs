using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Model.Utils
{
    public abstract class EncryptingStrategy
    {
        public abstract string EncryptPhrase(string phrase);
    }

    public class SHA256Hasher : EncryptingStrategy
    {
        public override string EncryptPhrase(string phrase)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(phrase);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String result = System.Text.Encoding.ASCII.GetString(data);
            return result;
        }
    }

    public class MD5Hasher : EncryptingStrategy
    {
        public override string EncryptPhrase(string phrase)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] bytes;
            bytes = ASCIIEncoding.Default.GetBytes(phrase);
            Byte[] encodedBytes;
            encodedBytes = md5.ComputeHash(bytes);

            string result = BitConverter.ToString(encodedBytes);
            return result;
        }
    }



    public class HashingContext
    {
        private EncryptingStrategy _encryptingStrategy;

        public HashingContext()
        {
            this._encryptingStrategy = new SHA256Hasher();
        }

        public string EncryptPhrase(string text)
        {
            text = _encryptingStrategy.EncryptPhrase(text);
            return text;
        }
    }
}
