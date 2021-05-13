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
                    TopicName = "Hikaye"
                }
                , new Topic()
                {
                    TopicID = 2,
                    TopicName = "Bilim"
                }

        , new Topic()
        {
            TopicID = 3,
            TopicName = "Sanat"
        }
        ,
        new Topic()
        {
            TopicID = 4,
            TopicName = "Oyun"
        }

            , new Topic()
            {
                TopicID = 5,
                TopicName = "Teknoloji"
            }


                ) ;
        }


    }
}
