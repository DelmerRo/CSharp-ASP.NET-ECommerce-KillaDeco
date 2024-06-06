using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class CategoryInMemory
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new()
            {
                new Category {  Name = "Mesa", ImageUrl = "url_de_la_imagen_de_mesa" },
                new Category {  Name = "Cocina", ImageUrl = "url_de_la_imagen_de_cocina" },
                new Category { Name = "Asado y Vino", ImageUrl = "url_de_la_imagen_de_asado_y_vino" },
                new Category { Name = "Deco", ImageUrl = "url_de_la_imagen_de_deco" },
                new Category { Name = "Aromas", ImageUrl = "url_de_la_imagen_de_aromas" },
                new Category { Name = "Baño y Lavadero", ImageUrl = "url_de_la_imagen_de_baño_y_lavadero" }
            };

            return categories;
        }
    }
}
