using System;
using System.Security.Cryptography;
using System.Text;

namespace Hospital.API.Data
{
    public class HashPassword
    {
        public string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public bool Verify(string password, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string passwordHash = Convert.ToBase64String(hash);
                return hashedPassword.Equals(passwordHash);
            }
        }
    }
}
