using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorporationHR.Models
{
    [Table("SecurityOfTables")]
    public class SecurityOfTable
    {
        [Key]
        [Display(Name = "TableId")]
        public int TableId { get; set; }
        [Required]
        [Display(Name = "TableName")]
        public string TableName { get; set; }
        [NotMapped]
        public int SelectedClearenceId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Clearences { get; set; }
        public virtual ClearenceModel ClearenceModel { get; set; }
    }
}