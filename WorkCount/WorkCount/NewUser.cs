using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCount
{
    class NewUser
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string RepeatPassword { get; set; }
        public static string AdminKey { get; set; } // the key that the user enters
        public static string UserAdminKey = "admin"; // the admin key 
    }
}
