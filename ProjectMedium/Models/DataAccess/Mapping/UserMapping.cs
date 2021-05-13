using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMedium.Models.DataAccess.Entitites;

namespace ProjectMedium.Models.DataAccess.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(c => c.UserID);
            builder.Property(c => c.UserID).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(c => c.UserName).HasMaxLength(50);
            builder.Property(c => c.Bio).HasMaxLength(160);
            builder.HasData(new User()
            {

                UserID = 454,
                FirstName = "Ugur",
                LastName = "Demir",
                UserName = "dd",
                IsActive = true,
                UserRole = UserRole.Admin,
                Email = "ddemirugur@gmail.com"

            });
        }
    }
}
