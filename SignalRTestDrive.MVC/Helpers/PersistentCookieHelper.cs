using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SignalRTestDrive.MVC.Helpers
{
    public static class PersistentCookieHelper
    {
        /// <summary>
        /// Salt for encryption.
        /// </summary>
        private const string EncryptionSalt = "SaltyBaltyBamBamBam123";

        /// <summary>
        /// Creates encrypted cookie (let's say there were sensitive data).
        /// </summary>
        public static HttpCookie Generate(string cookieName)
        {
            var cookieValue = string.Format(Guid.NewGuid().ToString());
            var bytes = UTF8Encoding.UTF8.GetBytes(cookieValue);
            var encryptedCookieValue = MachineKey.Protect(bytes, EncryptionSalt);
            var base64 = Convert.ToBase64String(encryptedCookieValue);
            var cookie = new HttpCookie(cookieName, base64)
            {
                Expires = DateTime.Now.AddYears(10),
                HttpOnly = true
            };

            return cookie;
        }

        /// <summary>
        /// Decrypts the cookie information and returns it's value.
        /// </summary>
        public static string Decrypt(HttpCookie cookie)
        {
            var bytes = Convert.FromBase64String(cookie.Value);
            var unprotected = MachineKey.Unprotect(bytes, EncryptionSalt);
            string cookieValue = UTF8Encoding.UTF8.GetString(unprotected);

            return cookieValue;
        }

    }
}
