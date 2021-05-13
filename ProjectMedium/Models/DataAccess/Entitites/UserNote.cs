using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class UserNote
    {

        public int UserId { get; set; }

        public int NoteID { get; set; }

        public virtual User User { get; set; }

        public virtual Note Note { get; set; }

    }
}
