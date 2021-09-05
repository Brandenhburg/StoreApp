using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.App.ViewModels
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
