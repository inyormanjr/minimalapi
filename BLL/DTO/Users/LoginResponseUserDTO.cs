using System;
namespace BLL.DTO.Users
{
	public class LoginResponseUserDTO
	{
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}

