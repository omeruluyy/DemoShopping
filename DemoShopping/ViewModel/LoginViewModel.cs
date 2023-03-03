using System.ComponentModel.DataAnnotations;

namespace DemoShopping.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string  email { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
         public string password { get; set; }
    }
}
