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
        public string TechnologyInternalId { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCompleted { get; set; }
    }
}