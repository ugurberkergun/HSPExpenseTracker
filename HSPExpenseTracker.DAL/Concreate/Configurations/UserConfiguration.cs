using HSPExpenseTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.DAL.Concreate.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("character varying").HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("character varying").HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasColumnType("character varying").HasMaxLength(100);
        }
    }
}
