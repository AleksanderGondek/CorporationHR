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
        public int ClearenceWeight { get; set; }
        [Required]
        [Display(Name = "Clearence")]
        public string ClearenceName { get; set; }
        [Required]
        [Display(Name = "Clearence Color")]
        public string ClearenceRgbColor { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<SecurityOfTable> SecurityOfTables { get; set; } 
    }
}