using Microsoft.EntityFrameworkCore;
using ProjectMedium.DataAccess2.Entitites;
using ProjectMedium.DataAccess2.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.DataAccess2
{
    public class MediumDbContext2 : DbContext

    //Dependency inversion araştır


    //Entityframework nugetını değil  core olanı(micro..) yüklendi. çünkü.net core da çalışıyoruz

    {
        public MediumDbContext2(DbContextOptions<MediumDbContext2> options) : base(options)
            //base için::string contecxt tanımlama ya yok ya boş bırakacaksın yada  dbcpntext options tipi vereceğiz----Bir kaç yolu var
            //...
            //Burada açmak ve startupta tanıtmak gerek
        {

        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region dursun şimdilik
            //modelBuilder.ApplyConfiguration(new UserMapping());
            //modelBuilder.ApplyConfiguration(new NoteMapping());
            //modelBuilder.ApplyConfiguration(new TopicMapping());
            //modelBuilder.ApplyConfiguration(new UserNoteMapping()); 
            #endregion
            modelBuilder.Entity<UserNote>().HasKey(a=>new { a.UserId, a.NoteID});
            base.OnModelCreating(modelBuilder);
        }

    }
}
