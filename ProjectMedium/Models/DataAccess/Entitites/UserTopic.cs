using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class UserTopic
    {
        public int UserId { get; set; }

        public int TopicId { get; set; }

        public virtual User User { get; set; }
                
        public virtual Topic Topic { get; set; }

    }
}
