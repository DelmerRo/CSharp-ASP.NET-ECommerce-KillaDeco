using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class SubCategoryInMemory
    {
        public static List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategories = new()
            {
                //MESA
                new SubCategory { CategoryId = 1, Name = "Vajilla", ImageUrl = "url_de_la_imagen_de_subcategoria1" },
                new SubCategory { CategoryId = 1, Name = "Café & Te", ImageUrl = "url_de_la_imagen_de_subcategoria2" },
                new SubCategory { CategoryId = 1, Name = "Cubiertos", ImageUrl = "url_de_la_imagen_de_subcategoria3" },
                new SubCategory { CategoryId = 1, Name = "Mantelería", ImageUrl = "url_de_la_imagen_de_subcategoria4" },
                new SubCategory { CategoryId = 1, Name = "Utensilios", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                
                //COCINA
                new SubCategory { CategoryId = 2, Name = "Porta Condimentos", ImageUrl = "url_de_la_imagen_de_subcategoria1" },
                new SubCategory { CategoryId = 2, Name = "Frascos", ImageUrl = "url_de_la_imagen_de_subcategoria2" },
                new SubCategory { CategoryId = 2, Name = "Latas", ImageUrl = "url_de_la_imagen_de_subcategoria3" },
                new SubCategory { CategoryId = 2, Name = "Ollas & Sartenes", ImageUrl = "url_de_la_imagen_de_subcategoria4" },
                new SubCategory { CategoryId = 2, Name = "Recipiente para horno", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Organizador de Cocina", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Accesorios de Cocina", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Utensilios", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Cuchillos", ImageUrl = "url_de_la_imagen_de_subcategoria5" },

                //ASADO & VINO
                new SubCategory { CategoryId = 3, Name = "Parrillas", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 3, Name = "Accesorios de vino & bar", ImageUrl = "url_de_la_imagen_de_subcategoria5" },

                //DECO
                new SubCategory { CategoryId = 4, Name = "Manta & almohadones", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Portavelas & Floreros", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Accesorio Deco", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Lamparas", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Plantas", ImageUrl = "url_de_la_imagen_de_subcategoria5" },

                //AROMAS
                new SubCategory { CategoryId = 5, Name = "Cremas & Jabones", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "Fragancias", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "Difusores", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "vELAS", ImageUrl = "url_de_la_imagen_de_subcategoria5" },

                //BAÑO & LAVADERO
                new SubCategory { CategoryId = 6, Name = "Accesorio de baño", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 6, Name = "Lavadero", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 6, Name = "Cestos", ImageUrl = "url_de_la_imagen_de_subcategoria5" },
            };


            return subCategories;
        }
    }
}
