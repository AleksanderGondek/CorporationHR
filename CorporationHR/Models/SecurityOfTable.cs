using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("SecurityOfTables")]
    public class SecurityOfTable
    {
        [Key]
        [Display(Name = "TableId")]
        public int TableId { get; set; }
        [Display(Name = "TableName")]
        public string TableName { get; set; }
        public virtual ClearenceModel ClearenceModel { get; set; }
    }
}