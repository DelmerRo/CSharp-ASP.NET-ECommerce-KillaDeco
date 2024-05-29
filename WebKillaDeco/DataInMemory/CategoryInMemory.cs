using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class CategoryInMemory
    {
        public static List<Answer> GetCategories()
        {
            List<Answer> categories = new()
            {
                new Answer {  Name = "MESA", ImageUrl = "url_de_la_imagen_de_mesa" },
                new Answer {  Name = "COCINA", ImageUrl = "url_de_la_imagen_de_cocina" },
                new Answer { Name = "ASADO & VINO", ImageUrl = "url_de_la_imagen_de_asado_y_vino" },
                new Answer { Name = "DECO", ImageUrl = "url_de_la_imagen_de_deco" },
                new Answer { Name = "AROMAS", ImageUrl = "url_de_la_imagen_de_aromas" },
                new Answer { Name = "BAÑO & LAVADERO", ImageUrl = "url_de_la_imagen_de_baño_y_lavadero" }
            };

            return categories;
        }
    }
}
