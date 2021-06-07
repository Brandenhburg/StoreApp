using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class AccountViewModel
    {
        [Required, PersonalData]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, PersonalData]
        public string Password { get; set; }

        [Required, PersonalData]
        public string RepeatPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
