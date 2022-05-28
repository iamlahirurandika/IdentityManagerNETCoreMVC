﻿using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } 

        [Required]
        [Display(Name = "Confirm Password"), DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
