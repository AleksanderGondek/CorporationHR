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
        [Display(Name = "Corporate Id")]
        public string CorpoId { get; set; }
        [Display(Name = "Social Security Number")]
        public string SocialSecurityNumber { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string Middlename { get; set; }
        [Display(Name = "Family name")]
        public string Familyname { get; set; }
        [Display(Name = "Corporate Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CorporatePhoneNumber { get; set; }
        [Display(Name = "Corporate Email")]
        [DataType(DataType.EmailAddress)]
        public string CorporateEmail { get; set; }
        [Display(Name = "Full Corespondence Adress")]
        public string FullCorespondenceAdress { get; set; }
        [Display(Name = "Full Current Adress")]
        public string FullCurrentAdress { get; set; }
        [Display(Name = "Private Email")]
        [DataType(DataType.EmailAddress)]
        public string PrivateEmail { get; set; }
        [Display(Name = "Private Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PrivatePhoneNumber { get; set; }
    }
}