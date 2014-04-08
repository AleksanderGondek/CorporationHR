using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorporationHR.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int MaskedEmployeeId { get; set; }
        public string CorpoId { get; set; }
        public string CountryIdNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string Familyname { get; set; }

        public string CorporatePhoneNumber { get; set; }
        public string CorporateEmail { get; set; }
        public string FullCorespondenceAdress { get; set; }
        public string FullCurrentAdress { get; set; }
        public string CountryOfResidence { get; set; }
        public string PrivateEmail { get; set; }
        public string PrivatePhoneNumber { get; set; }
    }
}