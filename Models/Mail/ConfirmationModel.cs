using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Mail
{
    public class ConfirmationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Hash1 { get; set; }
        public string Hash2 { get; set; }
    }
}
