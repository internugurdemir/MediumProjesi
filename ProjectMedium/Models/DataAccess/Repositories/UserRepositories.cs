using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMedium.Models.DataAccess.Entitites;
using ProjectMedium.Models;

namespace ProjectMedium.Models.DataAccess.Repositories
{
    class UserRepositories
    {
        MediumDbContext context;
        public UserRepositories(MediumDbContext ctx)
        {
            context = ctx;
            //boostDbContext = new BoostDbContext();
        }

        public User GetUser(string usermail)
        {
            var user = context.Users.Where(a => a.Email == usermail).FirstOrDefault();
            return user;

        }
        public bool AddNUserByYıldıırm(User user)
        {
            user.IsActive = false;
            user.UserRole = UserRole.User;
            user.FirstName = user.Email;
            CheckUser(user);
            context.Users.Add(user);
            return context.SaveChanges() > 0;
        }

        private void CheckUser(User user)
        {
            foreach (var item in context.Users)
            {
                if (user.Email == item.Email)
                {
                    user.UserName = "ExistEMail12";

                }
       
            }
    

        }
        public bool IsActive(string mail)
        {
            User user = context.Users.Where(u=>u.Email==mail).SingleOrDefault();
            user.IsActive = true;
            return context.SaveChanges() > 0;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public User GetUserByID(int id)
        {
            var userlist = context.Users.SingleOrDefault(a => a.UserID == id);
            return userlist;

        }

        public List<User> GetUserListByID(int id)
        {
            var userlist = context.Users.ToList();
            return userlist;
        }
        public void DeleteUser(int userID)
        {
            User user = context.Users.Find(userID);
            context.Users.Remove(user);
            context.SaveChanges();
        }


   
        public void UpdateUser(User user)
        {
         


            //if (user.IsActive==true)
            //    user.IsActive = true;
            //else
            //    user.IsActive = false;


            //user.ModifiedDate = DateTime.Now;
            //user.FirstName = user.FirstName;
            //user.LastName = user.LastName;
            //user.UserName = user.UserName;
            //user.UserRole = UserRole.User;
            //user.Email = user.Email;
            //user.Bio = user.Bio;


            var user1 = context.Entry(user);
            user1.State = EntityState.Modified;



            context.SaveChanges();
        }

    }
}
