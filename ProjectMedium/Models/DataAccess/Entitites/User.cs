using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjectMedium.Models.DataAccess.Entitites;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public class User : BaseEntityV2
    {
        public User()
        {
            /*Not ekleyebileceğimiz alan oluşturmak için
             * 
             */
            this.UserTopics = new HashSet<UserTopic>();
            //this.UserNotes = new HashSet<UserNote>();
 

        }



        #region DataAnnotations
        [Display(Name = "User ID")]
        #endregion
        public int UserID { get; set; }

        #region DataAnnotations
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "FirstName can be minumum 2 and maximum 50 char restricted")]
        #endregion
        public string FirstName { get; set; }


        #region DataAnnotations
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "LastName can be minumum 2 and maximum 50 char restiricted")]
        #endregion
        public string LastName { get; set; }



        #region DataAnnotations
        [Display(Name = "UserName")]
        [StringLength(50, ErrorMessage = "UserName can be maximum 50 char restiricted")]
        #endregion
        public string UserName { get; set; }

        #region DataAnnotations

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(155)]
        #endregion
        public string Email { get; set; }

        #region DataAnnotations
        [Display(Name = "Biography")]
        [StringLength(160, ErrorMessage = "Bio can be maximum 160 char restiricted")]
        #endregion
        public string Bio { get; set; }
        /*Bio max 160 character*/



        #region DataAnnotations
        [Display(Name = "User Connection Informations")]
        #endregion
        public string Connections { get; set; }
        public UserRole UserRole { get; set; }

        public virtual ICollection<UserTopic> UserTopics { get; set; }
        
        
        public string PageName { get { return "https://medium.com/@" + this.UserName; } }
        public string FullName { get { return this.FirstName+" "+this.LastName; } }
    }


    public enum UserRole
    {
        Admin, User
    }
}

