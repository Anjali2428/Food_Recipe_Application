using System.ComponentModel.DataAnnotations;
namespace CookingAppMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Your UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
    }
}
