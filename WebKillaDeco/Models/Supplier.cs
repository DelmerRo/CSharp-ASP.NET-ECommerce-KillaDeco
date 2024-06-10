using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Supplier: User
    {
        [Display(Name = Alias.Cuit)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.NumCUITCharacters, ErrorMessage = ErrorMsgs.CuitSize)]
        public string? Cuit { get; set; }
        public List<SupplierOrder>? SupplierOrders { get; set; }
    }
}
