using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        //[StringLength(Restrictions.MaxCategoryName, MinimumLength = Restrictions.MinCategoryName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        //[Display(Name = Alias.Category)]
        //[Required(ErrorMessage = ErrorMsgs.Required)]
        //[Remote(action: "CategoryNameAvailable", controller: "Categories")]
        public string Name { get; set; }

        //[Display(Name = Alias.UrlCategoryImage)]
        //[Required(ErrorMessage = ErrorMsgs.Required)]
        //[StringLength(Restrictions.MaxCategoryImageUrl, MinimumLength = Restrictions.MinCategoryImageUrl, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string ImageUrl { get; set; }

        //[Display(Name = Alias.IconCategoryUrl)]
        //[Required(ErrorMessage = ErrorMsgs.Required)]
        //[StringLength(Restrictions.MaxCategoryIconUrl, MinimumLength = Restrictions.MaxCategoryIconUrl, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string IconUrl { get; set; }

        public List<SubCategory>? SubCategories { get; set; }
    }
}
