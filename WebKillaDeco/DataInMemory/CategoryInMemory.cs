using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class CategoryInMemory
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new()
            {
                new Category {  Name = "Mesa", ImageUrl = "~/images/category-logo/vajilla.png" },
                new Category {  Name = "Cocina", ImageUrl = "~/images/category-logo/utensilios-de-cocina.png" },
                new Category { Name = "Asado y Vino", ImageUrl = "~/images/category-logo/cena.png" },
                new Category { Name = "Deco", ImageUrl = "~/images/category-logo/decoracion.png" },
                new Category { Name = "Aromas", ImageUrl = "~/images/category-logo/aroma.png" },
                new Category { Name = "Baño y Lavadero", ImageUrl = "~/images/category-logo/banera.png" }
            };

            return categories;
        }
    }
}
