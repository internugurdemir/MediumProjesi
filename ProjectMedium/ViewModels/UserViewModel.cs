using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.ViewModels
{
    public class UserViewModel
    {

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

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        #endregion
        public DateTime CreatedDate { get; set; }


        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile Photo { get; set; }

        public bool IsActive { get; set; }
        #region DataAnnotations

        [Display(Name = "Modified Date")]
        [DataType(DataType.DateTime)]
        #endregion
        public DateTime? ModifiedDate { get; set; }

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

    }
}
