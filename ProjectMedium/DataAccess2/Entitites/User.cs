using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectMedium.DataAccess2.Entitites
{
    public class User
    {
        public User()
        {
            this.UserNotes = new HashSet<UserNote>();
            this.Topics = new HashSet<Topic>();
        }

        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string Connections { get; set; }
        public UserRole UserRole { get; set; }

        public int NoteID { get; set; }
        public Note Note { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<UserNote> UserNotes { get; set; }
        public string PageName { get { return "https://medium.com/@" + this.UserName; } }
    }


    public enum UserRole
    {
        Admin, User
    }
}
