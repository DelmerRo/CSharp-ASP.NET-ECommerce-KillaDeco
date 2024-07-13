using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Employee: User
    {
        [Display(Name = Alias.Occupation)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxEmployeeOccupation, MinimumLength = Restrictions.MinEmployeeOccupation, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Occupation { get; set; }

        [Display(Name = Alias.Salary)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinEmployeeSalary, Restrictions.MaxEmployeeSalary, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public decimal Salary { get; set; }

        [NotMapped]
        public IFormFile? PhotoUrlFile { get; set; }

        [Display(Name = Alias.Photo)]
        public string? PhotoUrl { get; set; } = "/images/faces-clipart/pic-1.png";

        public List<Answer>? Answers { get; set; }
    }
}
