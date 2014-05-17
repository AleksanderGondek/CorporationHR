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
        public string CorpoId { get; set; }
        [Required]
        [Display(Name = "Social Security Number")]
        public string SocialSecurityNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle name")]
        public string Middlename { get; set; }
        [Required]
        [Display(Name = "Family name")]
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