using System.Security.Cryptography;

namespace ZenoBook.DataManipulation;

public class Security
{
    private static readonly IEnumerable<char> charSet =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

    public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        byte[] encryptedBytes = null;

        byte[] saltBytes = {9, 3, 1, 4, 7, 3, 2, 8, 0, 3, 2, 1, 0, 3, 5, 6};

        using (var ms = new MemoryStream())
        {
            using (Aes AES = new AesManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }

                encryptedBytes = ms.ToArray();
            }
        }

        return encryptedBytes;
    }

    public static string GenerateRandomString(int length, IEnumerable<char> charSet)
    {
        var charArray = charSet.Distinct().ToArray();
        var result = new char[length];
        for (var i = 0; i < length; i++)
            result[i] = charArray[RandomNumberGenerator.GetInt32(charArray.Length)];
        return new string(result);
    }

    public static string GenerateEncryptionPw()
    {
        var length = 8;
        var encryptionPw = GenerateRandomString(length, charSet);
        return encryptionPw;
    }

    public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
    {
        byte[] decryptedBytes = null;

        byte[] saltBytes = {8, 3, 2, 1, 0, 2, 1, 2, 1, 2, 5, 6, 7, 9, 4};

        using (var ms = new MemoryStream())
        {
            using (Aes AES = new AesManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();
                }

                decryptedBytes = ms.ToArray();
            }
        }

        return decryptedBytes;
    }
}