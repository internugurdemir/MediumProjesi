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
    public class NoteMapping:IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Yazılar");
            builder.Property(c => c.NoteID).ValueGeneratedOnAdd().UseIdentityColumn(1,1);
            builder.Property(c => c.Title).HasMaxLength(100);
            builder.HasKey(a => a.NoteID);
            //C
           
        }
    }
}
