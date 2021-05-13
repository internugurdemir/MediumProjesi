using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.DataAccess2.Entitites
{
    public class Note
    {

        public Note()
        {
            this.UserNotes = new HashSet<UserNote>();

        }

        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public double Uzunluk { get; set; }
        public int  Okunma { get; set; }

        public int TopicID { get; set; }
        public Topic Topic { get; set; }
        public virtual ICollection<UserNote> UserNotes { get; set; }


    }
}
