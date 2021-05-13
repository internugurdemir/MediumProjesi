using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMedium.DataAccess2.Entitites;

namespace ProjectMedium.DataAccess2.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Kullanıcı");
            builder.HasKey(c => c.UserID);
            builder.Property(c => c.UserID).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(c => c.FullName).HasMaxLength(100);
            builder.Property(c => c.UserName).HasMaxLength(50);
            builder.Property(c => c.Bio).HasMaxLength(160);

            // builder.HasKey(bc => new { bc.UserID });asd3211
        }
    }
}
