using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("Patents")]
    public class Patent
    {
        [Key]
        public int PatentId { get; set; }
        [Required]
        [Display(Name = "Patent Name")]
        public string PatentName { get; set; }
        [Required]
        [Display(Name = "Patent Text")]
        public string PatentText { get; set; }
    }
}