using System;
using DAL.FluentApiMapping;
using Domain.DomainAgg.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class MDbContext:DbContext
	{
		public DbSet<User> Users => Set<User>();

		public MDbContext(DbContextOptions<MDbContext> options): base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UserMapping());
			base.OnModelCreating(modelBuilder);
        }
	}
}

