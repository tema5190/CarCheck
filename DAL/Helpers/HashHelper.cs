using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Models.User;
using System;
using System.Security.Cryptography;

namespace DAL.Helpers
{
    public static class HashHelper
    {
        public static UserAuthInfo GetNewUserAuthInfo(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return new UserAuthInfo()
            {
                PasswordHash = hashed,
                Salt = salt,
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
    }
}
