using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Areas.Identity.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [DataType(DataType.Password)]
        [Display(Name = Alias.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; } = false;
    }
}
