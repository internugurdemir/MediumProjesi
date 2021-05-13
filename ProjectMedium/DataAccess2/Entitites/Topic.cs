using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.DataAccess2.Entitites
{
    public class Topic
    {
     
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public  ICollection<Note> Notes{ get; set; }
        public  ICollection<User> Users{ get; set; }
    }
}
