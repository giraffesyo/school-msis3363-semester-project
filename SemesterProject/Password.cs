using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SemesterProject
{
    public class Password
    {
        //Hash with SHA-1
        public static string HashPassword(String password)
        {
            //Use default hashing algorithm
            //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.create?view=netframework-4.7.2#System_Security_Cryptography_HashAlgorithm_Create
            HashAlgorithm algorithm = HashAlgorithm.Create();
            // Create hashed bytearray of our password
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            // Return hashed password string
            return Convert.ToBase64String(hash);
        }
    }
}