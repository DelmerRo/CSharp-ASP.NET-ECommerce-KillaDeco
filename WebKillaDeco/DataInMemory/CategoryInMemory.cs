using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class CategoryInMemory
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new()
            {
                new Category {  Name = "MESA", ImageUrl = "url_de_la_imagen_de_mesa" },
                new Category {  Name = "COCINA", ImageUrl = "url_de_la_imagen_de_cocina" },
                new Category { Name = "ASADO & VINO", ImageUrl = "url_de_la_imagen_de_asado_y_vino" },
                new Category { Name = "DECO", ImageUrl = "url_de_la_imagen_de_deco" },
                new Category { Name = "AROMAS", ImageUrl = "url_de_la_imagen_de_aromas" },
                new Category { Name = "BAÑO & LAVADERO", ImageUrl = "url_de_la_imagen_de_baño_y_lavadero" }
            };

            return categories;
        }
    }
}
