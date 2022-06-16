
using BLL.Services.Account;
using BLL.Services.Users;
using BLL.Utilities;
using DAL;
using DAL.IRepositories;
using DAL.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;

namespace MinimalWebAPI.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<AccountServices>();
			services.AddScoped<UserService>();
			services.AddDbContext<MDbContext>(dbContextOptionsBuilder =>
			{
				dbContextOptionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"), b =>  b.MigrationsAssembly("DAL"));
				
			});
			return services;
		}
	}
}

