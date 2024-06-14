using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class CategoryInMemory
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new()
            {
                new Category {  Name = "Mesa", ImageUrl = "~/images/category-image/mesa.jpg", IconUrl="~/images/category-icon/vajilla.png"},
                new Category {  Name = "Cocina", ImageUrl = "~/images/category-image/cocina.jpg", IconUrl="~/images/category-icon/utensilios-de-cocina.png"},
                new Category { Name = "Asado y Vino", ImageUrl = "~/images/category-image/asadovino.jpg", IconUrl="~/images/category-icon/cena.png" },
                new Category { Name = "Deco", ImageUrl = "~/images/category-image/decoracion.jpg", IconUrl="~/images/category-icon/decoracion.png" },
                new Category { Name = "Aromas", ImageUrl = "~/images/category-image/aromas.jpg", IconUrl="~/images/category-icon/aroma.png" },
                new Category { Name = "Baño y Lavadero", ImageUrl = "~/images/category-image/bañolavabo.jpg", IconUrl="~/images/category-icon/banera.png" }
            };

            return categories;
        }
    }
}
