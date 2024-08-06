using System.Security;
using System.Security.Cryptography;
using System.Text;


namespace crypto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = { 1, 2, 3, 4, 5 };

            //using (var rsa = new RSACryptoServiceProvider(2048))
            //{
            //    byte[] encrypted = rsa.Encrypt(data, true);
            //    byte[] decrypted = rsa.Decrypt(encrypted, true);
            //}

            using (var rsa = new RSACryptoServiceProvider())
            {
                File.WriteAllText("PublicKeyOnly.xml", rsa.ToXmlString(false));
                File.WriteAllText("PublicPrivate.xml", rsa.ToXmlString(true));
            }



            string publicKeyOnly = File.ReadAllText("PublicKeyOnly.xml");
            string publicPrivate = File.ReadAllText("PublicPrivate.xml");


            byte[] data1 = Encoding.UTF8.GetBytes("Message to encrypt");

            byte[] encrypted, decrypted;

            using (var rsaPublicOnly = new RSACryptoServiceProvider())
            {
                rsaPublicOnly.FromXmlString(publicKeyOnly);
                encrypted = rsaPublicOnly.Encrypt(data1, true);
                // this will throw exception because you need the private key in order to decrypt
                //  decrypted = rsaPublicOnly.Decrypt(encrypted, true);
            }

            using (var rsaPublicPrivate = new RSACryptoServiceProvider())
            {
                // With the private key we can successfully decrypt

                rsaPublicPrivate.FromXmlString(publicPrivate);
                decrypted = rsaPublicPrivate.Decrypt(encrypted, true);
            }



            //byte[] key = new byte[16];
            //byte[] iv = new byte[16];

            //var cryptoRng = RandomNumberGenerator.Create();
            //cryptoRng.GetBytes(key);
            //cryptoRng.GetBytes(iv);

            //byte[] data = Encoding.UTF8.GetBytes("Yeah!");

            //string encrypted = Encrypt(data, key, iv);
            //Console.WriteLine(encrypted);

            //string decrypted = Decrypt(encrypted, key, iv);
            //Console.WriteLine(decrypted);




        }

        //public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        //{
        //    using Aes algorithm = Aes.Create();
        //    algorithm.Key = key;
        //    return algorithm.EncryptCbc(data, iv);
        //}

        //public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        //{
        //    using Aes algorithm = Aes.Create();
        //    algorithm.Key = key;
        //    return algorithm.DecryptCbc(data, iv);
        //}

        //public static string Encrypt(string data, byte[] key, byte[] iv)
        //{
        //    byte[] encryptedBytes = EncryptToBytes(Encoding.UTF8.GetBytes(data), key, iv);
        //    return Convert.ToBase64String(encryptedBytes);
        //}


    }
}
