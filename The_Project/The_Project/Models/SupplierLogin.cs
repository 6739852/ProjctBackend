using System.ComponentModel.DataAnnotations;

namespace The_Project.Models
{
    public class SupplierLogin
    {
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; }
    }
}

