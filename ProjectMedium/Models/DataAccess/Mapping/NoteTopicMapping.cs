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
    public class NoteTopicMapping : IEntityTypeConfiguration<NoteTopic>
    {
        public void Configure(EntityTypeBuilder<NoteTopic> builder)
        {

            builder.HasKey(a => new { a.NoteId, a.TopicId });

            builder.HasOne/*<Note>*/(a => a.Note)
                .WithMany(a => a.NoteTopics)
                .HasForeignKey(a => a.NoteId);

            builder.HasOne/*<Topic>*/(a => a.Topic)
                .WithMany(a => a.NoteTopics)
                .HasForeignKey(a => a.TopicId);


        }


    }
}
