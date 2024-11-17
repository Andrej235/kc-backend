using System.Security.Cryptography;

namespace kc_backend.Utilities
{
    public static class HashingService
    {
        public static byte[] ToHash(this string password, byte[] salt) => SHA256.HashData(salt.CombineBytes(System.Text.Encoding.UTF8.GetBytes(password)));

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator.Create().GetBytes(salt);
            return salt;
        }

        private static byte[] CombineBytes(this byte[] first, byte[] second)
        {
            byte[] combined = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, combined, 0, first.Length);
            Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
            return combined;
        }
    }
}
