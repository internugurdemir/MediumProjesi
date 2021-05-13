using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.DataAccess2.Entitites
{
    public class UserNote
    {

        public int UserId { get; set; }

        public int NoteID { get; set; } 
        
        public User User { get; set; }

        public Note Note { get; set; }
        
    }
}
