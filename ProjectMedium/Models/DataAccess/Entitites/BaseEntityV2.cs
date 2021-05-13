using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMedium.Models.DataAccess.Entitites
{
    public abstract class BaseEntityV2
    {
        #region DataAnnotations

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)] 
        #endregion
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        #region DataAnnotations

        [Display(Name = "Modified Date")]
        [DataType(DataType.DateTime)] 
        #endregion
        public DateTime? ModifiedDate { get; set; }

    }
}
