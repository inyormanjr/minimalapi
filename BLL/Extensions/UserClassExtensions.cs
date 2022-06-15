using System;
using System.Security.Cryptography;
using System.Text;
using Domain.DomainAgg.UserAgg;

namespace BLL.Extensions
{
	public static class UserClassExtensions
	{
		public static void GeneratePasswordHashAndSalt(this User user, string password)
        {
			using var hmac = new HMACSHA256();
			user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			user.PasswordSalt = hmac.Key;
        }

		public static bool AuthenticatePassword(this User user, string loggedInPassword)
        {
			using var hmac = new HMACSHA256(user.PasswordSalt);
			var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loggedInPassword));
			for (int i = 0; i < computeHash.Length; i++)
			{
				if (computeHash[i] != user.PasswordHash[i]) return false;
			}
			return true;
		}

	}
}

