using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class User : IdentityUser<int>
    {
        [Display(Name = Alias.DNI)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.NumDNICharacters, ErrorMessage = ErrorMsgs.DniSize)]
        public string Dni { get; set; }

        [Display(Name = Alias.Cuil)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.NumCUILCharacters, ErrorMessage = ErrorMsgs.CuilSize)]
        public string Cuil { get; set; }

        [Display(Name = Alias.Name)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxUsername, MinimumLength = Restrictions.MinUsername, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string Name { get; set; }

        [Display(Name = Alias.LastName)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxUsername, MinimumLength = Restrictions.MinUsername, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string LastName { get; set; }

        [Display(Name = Alias.Phone)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(15, MinimumLength = 8, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [DataType(DataType.PhoneNumber, ErrorMessage = ErrorMsgs.InvalidFormat)]
        [RegularExpression(@"[0-9]{2}[0-9]{4}[0-9]{4}", ErrorMessage = ErrorMsgs.FormatCelularInvalid)]
        public string Phone { get; set; }

        [Display(Name = Alias.DateBirthDate)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorMsgs.ErrMsgNotValid)]
        public DateTime BirthDate { get; set; }

        [Display(Name = Alias.DateAdded)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorMsgs.ErrMsgNotValid)]
        public DateTime DateAdded { get; set; } 

        [Display(Name = Alias.Address)]
        public Address? Address { get; set; }

        [Display(Name = Alias.FullName)]
         [StringLength(Restrictions.MaxUsername, MinimumLength = Restrictions.MinUsername, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? FullName => $"{LastName?.ToUpper()}, {Name}";
    }
}
