using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebKillaDeco.Helpers;

namespace WebKillaDeco.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = ErrorMsgs.ErrMsgRequired)]
        public int SubCategoryId { get; set; }

        [Display(Name = Alias.Code)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductSku, Restrictions.MaxProductSku, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public int Sku { get; set; }

        [Display(Name = Alias.Name)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductName, MinimumLength = Restrictions.MinProductName, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Name { get; set; }

        [Display(Name = Alias.Description)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductDescription, MinimumLength = Restrictions.MinProductDescription, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = Alias.Brands)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductBrand, MinimumLength = Restrictions.MinProductBrand, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Brand { get; set; }

        [Display(Name = Alias.CurrentPrice)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductCurrentPrice, Restrictions.MaxProductCurrentPrice, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2} USD", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal CurrentPrice { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Display(Name = Alias.Active)]
        public bool Active { get; set; }

        [NotMapped]
        public IFormFile? ImageUrlFile { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        public string? ImageUrl { get; set; } = "/images/product-image/defaultproductimage.jpg";

        [NotMapped]
        public IFormFile? ImageUrlFile1 { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        public string? ImageUrl1 { get; set; } = "/images/product-image/defaultproductimage.jpg";

        [NotMapped]
        public IFormFile? ImageUrlFile2 { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        public string? ImageUrl2 { get; set; } = "/images/product-image/defaultproductimage.jpg";

        [NotMapped]
        public IFormFile? ImageUrlFile3 { get; set; }

        [Display(Name = Alias.UrlCategoryImage)]
        public string? ImageUrl3 { get; set; } = "/images/product-image/defaultproductimage.jpg";

        [Display(Name = Alias.AvailableStock)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductAvailableStock, Restrictions.MaxProductAvailableStock, ErrorMessage = ErrorMsgs.RangeMinMax)]
        public int AvailableStock { get; set; }

        [Display(Name = Alias.Weight)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductWeight, Restrictions.MaxProductWeight, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Weight { get; set; }

        [Display(Name = Alias.Width)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductWidth, Restrictions.MaxProductWidth, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Width { get; set; }

        [Display(Name = Alias.Height)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductHeight, Restrictions.MaxProductHeight, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Height { get; set; }

        [Display(Name = Alias.Depth)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductDepth, Restrictions.MaxProductDepth, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Depth { get; set; }

        [Display(Name = Alias.Color)]
        [Required(ErrorMessage = ErrorMsgs.Required)]
        [StringLength(Restrictions.MaxProductColors, MinimumLength = Restrictions.MinProductColors, ErrorMessage = ErrorMsgs.StrMaxMin)]
        public string? Color { get; set; }

        [Display(Name = Alias.PublicationDate)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorMsgs.InvalidDate)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Display(Name = Alias.Discount)]
        //[Required(ErrorMessage = ErrorMsgs.Required)]
        [Range(Restrictions.MinProductDiscount, Restrictions.MaxProductDiscount, ErrorMessage = ErrorMsgs.RangeMinMax)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Discount { get; set; } = 0m;
        
        public decimal DiscountAmount  => CurrentPrice * Discount / 100;

        public decimal DiscountedPrice => CurrentPrice - DiscountAmount;

        [Display(Name = Alias.SubCategoryName)]
        public SubCategory? SubCategories { get; set; }

        public List<StockItem>? StockItems { get; set; }
        public List<Qualification>? Qualifications { get; set; }
        public List<Favorite>? Favorites { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Question>? Questions { get; set; }


        public void GenerateSku(int categoryId, int subCategoryId, int productId)
        {
            string categoryIdPart = categoryId.ToString("D2"); // 2 dígitos para el ID de categoría
            string subCategoryIdPart = subCategoryId.ToString("D3"); // 3 dígitos para el ID de subcategoría
            string productIdPart = productId.ToString("D5"); // 5 dígitos para el ID del producto
            Sku = int.Parse($"{categoryIdPart}{subCategoryIdPart}{productIdPart}");
        }

    }
}