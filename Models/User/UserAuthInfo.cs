using System;
using System.Collections.Generic;
using System.Text;

namespace Models.User
{
    public class UserAuthInfo
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }
}
