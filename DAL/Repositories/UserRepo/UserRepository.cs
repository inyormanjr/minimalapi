using System;
using DAL.IRepositories;
using Domain.DomainAgg.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.UserRepo
{
	public class UserRepository:IUserRepository
	{
        private readonly MDbContext dbContext;

        public UserRepository(MDbContext _dbContext)
		{
            dbContext = _dbContext;
        }

        public async Task Delete(int id)
        {
            User user = await dbContext.Users.FindAsync(id);
             dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetList(int skip, int take)
        {
            return await dbContext.Users.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == username);
        }

        public async Task Save(User entity)
        {
            await dbContext.Users.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, User entity)
        {
            User user = await dbContext.Users.FindAsync(id);
            if(user != null)
            {
                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

