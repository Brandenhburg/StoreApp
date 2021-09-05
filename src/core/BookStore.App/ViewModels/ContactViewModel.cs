using System.ComponentModel.DataAnnotations;

namespace Bookstore.App.ViewModels
{
    public class ContactViewModel
    {
        [Required, MinLength(4)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(10)]
        public string Subject { get; set; }

        [Required, MaxLength(250, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}
