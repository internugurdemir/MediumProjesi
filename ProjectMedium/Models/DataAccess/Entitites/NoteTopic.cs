using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class NoteTopic
    {

        //public int NoteTopicId { get; set; }
        public int TopicId { get; set; }


        public int NoteId { get; set; }

        public Topic Topic { get; set; }
        public  Note Note { get; set; }


    }
}
