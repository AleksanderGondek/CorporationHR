using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.Helpers;

namespace CorporationHR.Models
{
    public class AdminUserProfileModel
    {
        public AdminUserProfileModel() { }

        public AdminUserProfileModel(UserProfile profile)
        {
            UserId = profile.UserId;
            UserName = profile.UserName;
            FirstName = profile.FirstName;
            LastName = profile.LastName;
            Email = profile.Email;
            SelectedClearanceId = profile.ClearenceModel != null ? profile.ClearenceModel.ClearenceId : -1;
            Clearances = GeneralHelper.GetClearencesSelectList();
        }

        [Display(Name = "User id")]
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Clearance")]
        public int SelectedClearanceId { get; set; }
        public IEnumerable<SelectListItem> Clearances { get; set; }
    }
}