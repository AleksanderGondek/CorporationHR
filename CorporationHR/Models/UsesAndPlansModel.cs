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
        public string Abstract { get; set; }
        [Display(Name = "Usages")]
        public string Usages { get; set; }
        [Display(Name = "Future Plans")]
        public string FuturePlans { get; set; }
        [Display(Name = "Competition Plans")]
        public string CompetitionPlans { get; set; }
    }
}