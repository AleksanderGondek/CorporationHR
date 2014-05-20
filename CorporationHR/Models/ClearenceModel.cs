using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("ClearenceModels")]
    public class ClearenceModel
    {
        [Key]
        [Display(Name = "Clearence Id")]
        public int ClearenceId { get; set; }
        [Required]
        [Display(Name = "Clearence Weight")]
        [RegularExpression(@"^[0-9]\d{0,2}$")]
        public int ClearenceWeight { get; set; }
        [Required]
        [Display(Name = "Clearence")]
        public string ClearenceName { get; set; }
        [Required]
        [Display(Name = "Clearence Color")]
        [RegularExpression(@"^#(?:[0-9a-fA-F]{3}){1,2}$")]
        public string ClearenceRgbColor { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<SecurityOfTable> SecurityOfTables { get; set; } 
    }
}