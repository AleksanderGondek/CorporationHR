using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("TechnologyAuthors")]
    public class TechnologyAuthor
    {
        [Key]
        public int TechnologyAuthorId { get; set; }
        [Required]
        [Display(Name = "Corporate Id")]
        [MinLength(5)]
        public string CorpoId { get; set; }
        [Required]
        [Display(Name = "Social Security Number")]
        [MinLength(5)]
        public string SocialSecurityNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [MinLength(5)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle name")]
        [MinLength(5)]
        public string Middlename { get; set; }
        [Required]
        [Display(Name = "Family name")]
        [MinLength(5)]
        public string Familyname { get; set; }
        [Required]
        [Display(Name = "Corporate Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CorporatePhoneNumber { get; set; }
        [Required]
        [Display(Name = "Corporate Email")]
        [DataType(DataType.EmailAddress)]
        public string CorporateEmail { get; set; }
        [Required]
        [Display(Name = "Full Corespondence Adress")]
        public string FullCorespondenceAdress { get; set; }
        [Required]
        [Display(Name = "Full Current Adress")]
        [MinLength(5)]
        public string FullCurrentAdress { get; set; }
        [Required]
        [Display(Name = "Private Email")]
        [DataType(DataType.EmailAddress)]
        public string PrivateEmail { get; set; }
        [Required]
        [Display(Name = "Private Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PrivatePhoneNumber { get; set; }
    }
}