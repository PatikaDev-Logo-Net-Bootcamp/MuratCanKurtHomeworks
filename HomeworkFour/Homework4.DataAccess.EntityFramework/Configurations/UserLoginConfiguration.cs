using Homework4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.DataAccess.EntityFramework.Configurations
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogins");
            builder.HasKey(t => t.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.UserName).IsRequired();
            builder.Property(e => e.Password).IsRequired();
        }
    }
}
