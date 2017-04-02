using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LoginViewSample
{
    public class ConnectionManager
    {
        /// <summary>
        /// Authenticate provided user information with database.
        /// </summary>
        /// <param name="username">Username of autheticating user.</param>
        /// <param name="secret">Password of autheticating user.</param>
        /// <returns>Whether or not login was successful.</returns>
        public bool Authenticate(string username, SecureString secret)
        {
            //Some login connection junk here
            return true;
        }
    }
}
