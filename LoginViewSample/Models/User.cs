using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginViewSample.Models
{
    public class User
    {
        public string Username { get; set; }
        public bool IsAutheticated { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }
}
