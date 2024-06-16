using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [StringLength(Restrictions.MaxCategoryName, MinimumLength = Restrictions.MinCategoryName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [Display(Name = Alias.Category)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Remote(action: "CategoryNameAvailable", controller: "Categories", AdditionalFields = nameof(CategoryId))]
        public string? Name { get; set; }

        [NotMapped]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public IFormFile? ImageUrlFile { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        public string? ImageUrl { get; set; }

        [NotMapped]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        public IFormFile? IconUrlFile { get; set; }

        [Display(Name = Alias.IconCategoryUrl)]
        public string? IconUrl { get; set; }

        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}