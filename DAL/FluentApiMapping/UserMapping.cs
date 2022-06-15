using System;
using Domain.DomainAgg.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.FluentApiMapping
{
	public class UserMapping:IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

