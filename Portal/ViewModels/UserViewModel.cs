using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public string RoleName { get; set; }
        public int SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
        }
    }
}