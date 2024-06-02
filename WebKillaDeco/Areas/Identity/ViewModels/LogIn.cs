using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Areas.Identity.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Required)]
        [DataType(DataType.Password)]
        [Display(Name = Alias.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; } = false;
    }
}




