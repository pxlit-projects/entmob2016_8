using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Utility
{
    public class Hasher
    {
        public static string ConvertStringToHash(string password, string salt)
        {
            byte[] data = Encoding.UTF8.GetBytes(password + "" + salt);
            Org.BouncyCastle.Crypto.Digests.Sha512Digest hash = new Org.BouncyCastle.Crypto.Digests.Sha512Digest();
            hash.BlockUpdate(data, 0, data.Length);
            byte[] result = new byte[hash.GetDigestSize()];
            hash.DoFinal(result, 0);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }
            string res = sb.ToString();

            return res;
        }
    }
}
