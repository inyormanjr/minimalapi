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

        public async Task<bool> Delete(int id)
        {
            User user = await dbContext.Users.FindAsync(id);
             dbContext.Users.Remove(user);
             var result = await dbContext.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<User?> GetById(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetList(int skip, int take)
        {
            return await dbContext.Users.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == username);
        }

        public async Task<User> Save(User entity)
        {
            this.dbContext.Add(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User?> Update(int id,User entity)
        {
                dbContext.Users.AsNoTracking();
                dbContext.Users.Update(entity);
                await dbContext.SaveChangesAsync();
                return entity;
        }
    }
}

