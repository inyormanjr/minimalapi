using System;
namespace Domain.DomainAgg.UserAgg
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string GivenName { get; set; } = String.Empty;
        public string SurName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Contact { get; set; } = String.Empty;

    }
 
}

