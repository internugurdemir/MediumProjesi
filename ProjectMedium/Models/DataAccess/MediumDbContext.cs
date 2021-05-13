using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models.DataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess
{
    public class MediumDbContext : DbContext

    //Dependency inversion araştır
                /*Bir sınıfın, metodun ya da özelliğin, onu kullanan diğer sınıflara karşı olan bağımlılığı en aza indirgenmelidir.
                    * Bir alt sınıfta yapılan değişiklikler üst sınıfları etkilememelidir.*/

    //Entityframework nugetını değil  core olanı(micro..) yüklendi. çünkü.net core da çalışıyoruz

    {


        public MediumDbContext(DbContextOptions<MediumDbContext> options) : base(options)
            //base için::string contecxt tanımlama ya yok ya boş bırakacaksın yada  dbcpntext options tipi vereceğiz----Bir kaç yolu var
            //...
            //Burada açmak ve startupta tanıtmak gerek
        {

        }

        //public MediumDbContext()
        //{
        //}

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NoteTopic> NoteTopics { get; set; }
        //public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Mappinglerde yapıldı
            //modelBuilder.Entity<Note>().HasKey(a => a.NoteID);
            //modelBuilder.Entity<AboutUser>().HasKey(a => a.AboutUserID);
            //modelBuilder.Entity<User>().HasKey(a => a.UserID); 
            #endregion


            /*Databasei tettikleyerek ayağa kaldırdık
             * dbcontexten nesne aldık, alınan nesne üzerinden add, delete, ve nesneyi ctx.savechanges(); diyerek yaptık
             * EF bize bir yol sağlıyor Migration=>Startup tya
             * 
             */
            #region dursun
            //modelBuilder.Entity<UserNote>().HasKey(a => new { a.UserId, a.NoteID });
            //modelBuilder.Entity<UserTopic>().HasKey(a => new { a.UserId, a.TopicId });
            //modelBuilder.ApplyConfiguration(new UserNoteMapping());
            #endregion
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new NoteMapping());
            modelBuilder.ApplyConfiguration(new TopicMapping());
            modelBuilder.ApplyConfiguration(new NoteTopicMapping());
            modelBuilder.ApplyConfiguration(new UserTopicMapping());

            base.OnModelCreating(modelBuilder);

        }

        #region başka bir connection string söyleme yöntemi
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=ProjectMedium; uid=sa; pwd=123");
        //    base.OnConfiguring(optionsBuilder);

        //}
        #endregion



        #region Entityframework Code first MVC öncesi böyleydi
        //public DbSet<User> Users { get; set; }
        //public DbSet<AboutUser> AboutUsers { get; set; }
        //public DbSet<Note> Notes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new UserMapping());
        //    modelBuilder.Configurations.Add(new NoteMapping());
        //    modelBuilder.Configurations.Add(new AboutUserMapping());



        //    base.OnModelCreating(modelBuilder);
        //} 
        #endregion
    }
}
