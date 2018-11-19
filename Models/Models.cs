using System;

namespace Models
{
    public class UserCarData
    {
        public string FullName { get; set; }
        public string CertificateSeries { get; set; }
        public string CertificateNumber { get; set; }
    }

    public class AuthModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
    }

    public class PostModel
    {
        public int GuidControl { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
    }

    public class PenaltyResult : UserCarData
    {
        public DateTime PenaltyDataTime { get; set; }
        public string PenaltyNumber { get; set; }
    }
}
