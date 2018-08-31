using System.Security.Cryptography;
using System.Text;

namespace SimpleWarehouse.Util
{
    public class PasswordEncoder
    {
        public static string EncodeMd5(string text)
        {
            MD5 mdHash = MD5.Create();
            string hash = GetMd5Hash(mdHash, text);
            return hash;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new String builder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
