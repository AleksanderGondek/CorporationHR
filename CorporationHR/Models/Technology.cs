using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.Helpers;

namespace CorporationHR.Models
{
    [Table("Technologies")]
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        [Required]
        [MinLength(36)]
        public string TechnologyInternalId { get; set; }
        [Required]
        [MinLength(5)]
        public string ShortDescription { get; set; }
        [Required]
        [MinLength(10)]
        public string FullDescription { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}