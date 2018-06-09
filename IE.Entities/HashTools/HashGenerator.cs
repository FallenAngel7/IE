using System;

namespace IE.Entities.HashTools
{
    public class HashGenerator
    {
        public string password;
        public HashGenerator(string password)
        {
            this.password = password;
        }

        public string Hash()
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
