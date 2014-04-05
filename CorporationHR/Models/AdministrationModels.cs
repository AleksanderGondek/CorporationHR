using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}