using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class Note: BaseEntityV2
    {

        public Note()
        {
            //this.UserTopics = new HashSet<UserTopic>();
            this.NoteTopics = new HashSet<NoteTopic>();

            //this.UserNotes = new HashSet<UserNote>();

        }
        #region DataAnnotations
        [Display(Name = "Note ID")]
        [Required(ErrorMessage = "Note ID is required")]
        #endregion
        public int NoteID { get; set; }

        #region DataAnnotations
        [Display(Name = "Note Title")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Note title can be minimum 3 character and maximum 50 character")]
        [Required(ErrorMessage = "Title is required")]
        #endregion
        public string Title { get; set; }

        #region DataAnnotations
        [Display(Name = "Note Content")]
        [MinLength(2, ErrorMessage = "Note Content can be minimum 2 character and maximum 50 character")]
        [DataType(DataType.MultilineText)]
        #endregion
        public string Content { get; set; }
        public uint ReadingCount { get; set; }
        public ushort ReadingTime { get; set; }




        public int UserID { get; set; }
        public User User { get; set; }     

        public  ICollection<NoteTopic> NoteTopics { get; set; }

    }
}
