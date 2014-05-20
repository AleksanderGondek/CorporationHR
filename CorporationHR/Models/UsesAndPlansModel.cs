using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("UsesAndPlans")]
    public class UseAndPlan
    {
        [Key]
        public int UseAndPlanId { get; set; }
        [Display(Name = "Abstract")]
        [MinLength(5)]
        public string Abstract { get; set; }
        [Display(Name = "Usages")]
        [MinLength(5)]
        public string Usages { get; set; }
        [Display(Name = "Future Plans")]
        [MinLength(5)]
        public string FuturePlans { get; set; }
        [Display(Name = "Competition Plans")]
        [MinLength(5)]
        public string CompetitionPlans { get; set; }
    }
}