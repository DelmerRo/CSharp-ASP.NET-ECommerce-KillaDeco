using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }

        [StringLength(Restrictions.MaxSubCategoryName, MinimumLength = Restrictions.MinSubCategoryName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [Display(Name = Alias.SubCategoryName)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Remote(action: "SubCategoryNameAvailable", controller: "SubCategories")]
        public string? Name { get; set; }

        [NotMapped]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public IFormFile? IconUrlFile { get; set; }

        [Display(Name = Alias.IconSubCategoryUrl)]
        public string? IconUrl { get; set; }

        [Display(Name = Alias.CategoryName)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}