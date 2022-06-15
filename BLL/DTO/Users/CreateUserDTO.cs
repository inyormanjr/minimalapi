using System;
namespace BLL.DTO.Users
{
	public class CreateUserDTO
	{
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string GivenName { get; set; } = String.Empty;
        public string SurName { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Contact { get; set; } = String.Empty;
    }
}

