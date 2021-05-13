using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMedium.DataAccess.Entitites;

namespace ProjectMedium.DataAccess.Mapping
{
    public class UserNoteMapping : IEntityTypeConfiguration<UserNote>
    {
        public void Configure(EntityTypeBuilder<UserNote> builder)
        {

            #region User topic Many to Many
            builder.HasKey(a => new { a.UserId, a.NoteID });

            builder.HasOne/*<User>*/(a => a.User)
                .WithMany(a => a.UserNotes)
                .HasForeignKey(a => a.UserId);

            builder.HasOne/*<Topic>*/(a => a.Note)
                .WithMany(a => a.UserNotes)
                .HasForeignKey(a => a.NoteID);

            #endregion
        }

       
    }
}
