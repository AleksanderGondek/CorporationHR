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

    [Table("EmployeeClassification")]
    public class EmployeeClassification
    {
        public int RowClassification { get; set; }
        public int EmployeeIdclassification { get; set; }
        public int CorpoIdClassification { get; set; }
        public int CountryIdNumberClassification { get; set; }
        public int SocialSecurityNumberClassification { get; set; }
        public int FirstNameClassification { get; set; }
        public int MiddlenameClassification { get; set; }
        public int FamilynameClassification { get; set; }

        public int CorporatePhoneNumberClassification { get; set; }
        public int CorporateEmailClassification { get; set; }
        public int FullCorespondenceAdressClassification { get; set; }
        public int FullCurrentAdressClassification { get; set; }
        public int CountryOfResidenceClassification { get; set; }
        public int PrivateEmailClassification { get; set; }
        public int PrivatePhoneNumberClassification { get; set; }
    }
}