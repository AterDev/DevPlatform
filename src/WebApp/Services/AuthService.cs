using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class AuthService
    {
        public bool IsLogin { get; set; } = false;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public AuthService()
        {
        }


        public void SignOut()
        {
            
        }

    }
}
