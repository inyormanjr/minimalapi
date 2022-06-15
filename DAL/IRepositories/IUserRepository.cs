using System;
using Domain.DomainAgg.UserAgg;

namespace DAL.IRepositories
{
	public interface IUserRepository:IRepositoryBase<User>
	{
		public Task<User> GetUserByUsername(string username);
	}
}

