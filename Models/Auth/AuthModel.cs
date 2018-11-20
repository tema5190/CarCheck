using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Auth
{
    public class AuthModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }
}
