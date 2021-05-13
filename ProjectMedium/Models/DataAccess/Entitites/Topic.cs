using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class Topic
    {
        public Topic()
        {
           
            this.UserTopics = new HashSet<UserTopic>();
            this.NoteTopics = new HashSet<NoteTopic>();

        }
        public int TopicID { get; set; }

        public int counterTopic;

        #region DataAnnotations
        [Display(Name = "Topic Name")]
        [MinLength(2)]
        #endregion
        public string TopicName { get; set; }
        public string Photo { get; set; }



        public  ICollection<UserTopic> UserTopics { get; set; }
        public  ICollection<NoteTopic> NoteTopics { get; set; }
    }
}
