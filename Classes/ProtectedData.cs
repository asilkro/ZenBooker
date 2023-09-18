using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ZenoBook.Classes
{
    /*
     * Using this as a reference:
    https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.protecteddata?view=dotnet-plat-ext-7.0
     */

    public class ProtectedData
    {
        private static byte[] entropyArray = {9, 3, 1, 4, 12, 3, 14, 8, 0, 3};

        public byte[] EncryptPw(string pw)
        {
            byte[] arrayPw = Encoding.Default.GetBytes(pw);
            byte[] encryptedPw = System.Security.Cryptography.ProtectedData.Protect(arrayPw, entropyArray, DataProtectionScope.LocalMachine);
            return encryptedPw;
        }

        public string DecryptPw(byte[] encryptedPw)
        {
            byte[] unencryptedPw = System.Security.Cryptography.ProtectedData.Unprotect(encryptedPw, entropyArray, DataProtectionScope.LocalMachine);
            string pw = Encoding.Default.GetString(unencryptedPw);
            return pw;
        }

    }

    
}
