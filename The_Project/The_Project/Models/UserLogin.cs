//namespace The_Project.Models
//{
//    public class UserLogin
//    {
//        public string Password { get; set; }
//        public string Email { get; set; }

//    }
//}
using System.ComponentModel.DataAnnotations;

namespace The_Project.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The Password field is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        public string Email { get; set; }
    }
}

