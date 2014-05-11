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

        public virtual ClearenceModel ClearenceModel { get; set; }
    }

    public class TechnologyCreationModel
    {
        public TechnologyCreationModel()
        {
            SelectedClearanceId = 5;
            Clearances = GeneralHelper.GetClearencesSelectList();
        }

        public TechnologyCreationModel(Technology vanillaTechnology)
        {
            TechnologyId = vanillaTechnology.TechnologyId;
            TechnologyInternalId = vanillaTechnology.TechnologyInternalId;
            ShortDescription = vanillaTechnology.ShortDescription;
            FullDescription = vanillaTechnology.FullDescription;
            CreatedOn = vanillaTechnology.CreatedOn;
            IsCompleted = vanillaTechnology.IsCompleted;
            SelectedClearanceId = vanillaTechnology.ClearenceModel.ClearenceId;
            Clearances = GeneralHelper.GetClearencesSelectList();
        }

        [Key]
        public int TechnologyId { get; set; }
        public string TechnologyInternalId { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCompleted { get; set; }

        [Required]
        [Display(Name = "Clearance")]
        public int SelectedClearanceId { get; set; }
        public IEnumerable<SelectListItem> Clearances { get; set; }
    }
}