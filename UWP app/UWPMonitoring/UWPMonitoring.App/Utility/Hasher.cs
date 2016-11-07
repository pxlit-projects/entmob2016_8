using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace UWPMonitoring.App.Utility
{
    public class Hasher
    {
        public static string ConvertStringToHash(string password, string salt)
        {
            byte[] data = Encoding.UTF8.GetBytes(password + "" + salt);
            HashAlgorithmProvider alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha512);
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(password + salt, BinaryStringEncoding.Utf8);
            IBuffer hashed = alg.HashData(buffer);
            string res = CryptographicBuffer.EncodeToHexString(hashed);
            return res;
        }
    }
}
