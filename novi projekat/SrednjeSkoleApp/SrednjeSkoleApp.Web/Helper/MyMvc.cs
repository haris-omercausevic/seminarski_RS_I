using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Helper
{
    public class MyMvc
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);

            return Convert.ToBase64String(buf);
    ***REMOVED***

        public static string GenerateHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var passwordBytes = Encoding.Unicode.GetBytes(password);
            var resultingBytes = new byte[saltBytes.Length + passwordBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, resultingBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, resultingBytes, saltBytes.Length, passwordBytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");

            return Convert.ToBase64String(algorithm.ComputeHash(resultingBytes));
    ***REMOVED***
***REMOVED***
***REMOVED***
