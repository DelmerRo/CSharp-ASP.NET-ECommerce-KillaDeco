using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }

        public int CategoryId { get; set; }

        [StringLength(Restrictions.MaxSubCategoryName, MinimumLength = Restrictions.MinSubCategoryName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [Display(Name = Alias.SubCategoryId)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Remote(action: "CategoryNameAvailable", controller: "Categories")]
        public string? Name { get; set; }

        [Display(Name = Alias.IconSubCategoryUrl)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxSubCategoryName, MinimumLength = Restrictions.MinSubCategoryName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? IconUrl { get; set; }

        [Display(Name = Alias.CategoryName)]
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}