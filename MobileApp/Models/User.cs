using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using RestSharp;
using System.Threading.Tasks;

namespace MobileApp.Models
{
   public class User
    {
        public static TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        /*  Testing
        public bool CheckInformation()
        {
            if ( !this.Username.Equals("") && !this.Password.Equals("") )
                return true;
            else
                return false;
        }
        */

        public async Task<bool> CheckInformation()
        {
            
            var client = new RestClient(Constant.apiAuth);
            var request = new RestRequest(Method.POST);
            prepareToEncrypt();
            request.AddJsonBody(new { login = this.Username, password = EncryptData(this.Password) });
            var response = await client.ExecutePostTaskAsync<Object>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            
            else
                return false;

        }

        static void prepareToEncrypt()
        {
            TripleDes.Key = TruncateHash(Constant.Key, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);

        }
        static byte[] TruncateHash(string key, int length)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] keyBytes = System.Text.Encoding.Unicode.GetBytes(key);
            byte[] hash = sha1.ComputeHash(keyBytes);
            var oldHash = hash;
            hash = new byte[length];

            if (oldHash != null)
                Array.Copy(oldHash, hash, Math.Min(length, oldHash.Length));

            return hash;
        }
        static string EncryptData(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return "";

            // Convert the plaintext string to a byte array. 
            byte[] plaintextBytes = System.Text.Encoding.Unicode.GetBytes(plaintext);
            // Create the stream. 
            MemoryStream ms = new MemoryStream();
            // Create the encoder to write to the stream. 
            CryptoStream encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write);
            // Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length);
            encStream.FlushFinalBlock();
            // Convert the encrypted stream to a printable string. 

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
