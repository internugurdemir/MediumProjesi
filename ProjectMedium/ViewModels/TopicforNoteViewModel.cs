using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.ViewModels
{
    public class TopicforNoteViewModel
    {
        [Key]
        [Display(Name = "Topic ID")]
        public int TopicID { get; set; }


        [Display(Name = "Name")]
        public string TopicName { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
