using System.Security.Cryptography;
using System.Text;

namespace ZenoBook.DataManipulation;
/*
 * Using this as a reference:
https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.protecteddata?view=dotnet-plat-ext-7.0
 */

public class ProtectedData
{
    private static readonly byte[] entropyArray = {9, 3, 1, 4, 7, 3, 2, 8, 0, 3, 2, 1, 0, 3, 5, 6};

    public byte[] EncryptPw(string pw)
    {
        var arrayPw = Encoding.Default.GetBytes(pw);
        var encryptedPw =
            System.Security.Cryptography.ProtectedData.Protect(arrayPw, entropyArray, DataProtectionScope.LocalMachine);
        return encryptedPw;
    }

    public string DecryptPw(byte[] encryptedPw)
    {
        var unencryptedPw =
            System.Security.Cryptography.ProtectedData.Unprotect(encryptedPw, entropyArray,
                DataProtectionScope.LocalMachine);
        var pw = Encoding.Default.GetString(unencryptedPw);
        return pw;
    }
}