using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Models.User;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Helpers
{
    public static class HashHelper
    {
        public static UserAuthInfo GetNewUserAuthInfo(string password)
        {
            (string, byte[]) hashData = GetHashAndSaltTuple(password);

            return new UserAuthInfo()
            {
                PasswordHash = hashData.Item1,
                Salt = hashData.Item2,
            };
        }

        public static string GetUserPasswordHash(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public static (string, byte[]) GetHashAndSaltTuple(string dataForHash)
        {

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: dataForHash,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return (hashed, salt);
        }

        public static (string,string) GetHashesForEmailConfirmation(string email)
        {
            (string, byte[]) hash1 = GetHashAndSaltTuple(email);
            (string, byte[]) hash2 = GetHashAndSaltTuple(email);

            return (hash1.Item1.RemoveSpecialCharacters(), hash2.Item1.RemoveSpecialCharacters());
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
