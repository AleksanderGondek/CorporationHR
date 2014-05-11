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
        public int ClearenceId { get; set; }
        public int ClearenceWeight { get; set; }
        public string ClearenceName { get; set; }

        public string ClearenceRgbColor { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; } 
    }
}