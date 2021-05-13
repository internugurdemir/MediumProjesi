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
    public class TopicMapping : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {

            builder.HasKey(c => c.TopicID);
            builder.Property(c => c.TopicID).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(c => c.TopicName).HasMaxLength(70);
            builder.HasData(
                new Topic()
                {
                    TopicID = 1,
                    TopicName = "Story",
                    Photo = "~/Image/Story.jpg"

                }
                , new Topic()
                {
                    TopicID = 2,
                    TopicName = "Science",
                    Photo = "~/Image/Science.png"

                }

        , new Topic()
        {
            TopicID = 3,
            TopicName = "Art",
            Photo = "~/Image/Art.png"
        }
        ,
        new Topic()
        {
            TopicID = 4,
            TopicName = "Game",
            Photo = "~/Image/Game.png"
        }

            , new Topic()
            {
                TopicID = 5,
                TopicName = "Technology",
                Photo = "~/Image/Technology.png"
            });
        }


    }
}
