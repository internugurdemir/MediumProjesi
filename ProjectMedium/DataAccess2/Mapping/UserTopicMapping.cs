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
    public class UserNoteMapping : IEntityTypeConfiguration<UserNote>
    {
        public void Configure(EntityTypeBuilder<UserNote> builder)
        {

            #region User topic Many to Many
            //builder.HasKey(a => new { a.UserId, a.TopicId });

            //builder.HasOne/*<User>*/(a => a.User)
            //    .WithMany(a => a.UserTopics)
            //    .HasForeignKey(a => a.UserId);

            //builder.HasOne/*<Topic>*/(a => a.Topic)
            //    .WithMany(a => a.UserTopics)
            //    .HasForeignKey(a => a.TopicId);

            #endregion
        }

       
    }
}
