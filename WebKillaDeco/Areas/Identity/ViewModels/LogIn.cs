using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Areas.Identity.ViewModels
{
    public class LogIn
    {
        /*[Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = Alias.Email)]*/
        public string Email { get; set; }

       // [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password)]
        //[Display(Name = Alias.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; } = false;
    }
}
