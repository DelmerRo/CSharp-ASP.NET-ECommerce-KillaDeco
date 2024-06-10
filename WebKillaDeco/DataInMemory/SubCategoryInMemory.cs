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
                new SubCategory { CategoryId = 1, Name = "Vajilla", IconUrl = "url_de_la_imagen_de_subcategoria1" },
                new SubCategory { CategoryId = 1, Name = "Café & Te", IconUrl = "url_de_la_imagen_de_subcategoria2" },
                new SubCategory { CategoryId = 1, Name = "Cubiertos", IconUrl = "url_de_la_imagen_de_subcategoria3" },
                new SubCategory { CategoryId = 1, Name = "Mantelería", IconUrl = "url_de_la_imagen_de_subcategoria4" },
                new SubCategory { CategoryId = 1, Name = "Utensilios", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                
                //COCINA
                new SubCategory { CategoryId = 2, Name = "Porta Condimentos", IconUrl = "url_de_la_imagen_de_subcategoria1" },
                new SubCategory { CategoryId = 2, Name = "Frascos", IconUrl = "url_de_la_imagen_de_subcategoria2" },
                new SubCategory { CategoryId = 2, Name = "Latas", IconUrl = "url_de_la_imagen_de_subcategoria3" },
                new SubCategory { CategoryId = 2, Name = "Ollas & Sartenes", IconUrl = "url_de_la_imagen_de_subcategoria4" },
                new SubCategory { CategoryId = 2, Name = "Recipiente para horno", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Organizador de Cocina", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Accesorios de Cocina", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Utensilios", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 2, Name = "Cuchillos", IconUrl = "url_de_la_imagen_de_subcategoria5" },

                //ASADO & VINO
                new SubCategory { CategoryId = 3, Name = "Parrillas", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 3, Name = "Accesorios de vino", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 3, Name = "Accesorios de bar", IconUrl = "url_de_la_imagen_de_subcategoria5" },

                //DECO
                new SubCategory { CategoryId = 4, Name = "Manta & almohadones", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Portavelas & Floreros", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Accesorio Deco", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Lamparas", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 4, Name = "Plantas", IconUrl = "url_de_la_imagen_de_subcategoria5" },

                //AROMAS
                new SubCategory { CategoryId = 5, Name = "Cremas & Jabones", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "Fragancias", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "Difusores", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 5, Name = "vELAS", IconUrl = "url_de_la_imagen_de_subcategoria5" },

                //BAÑO & LAVADERO
                new SubCategory { CategoryId = 6, Name = "Accesorio de baño", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 6, Name = "Lavadero", IconUrl = "url_de_la_imagen_de_subcategoria5" },
                new SubCategory { CategoryId = 6, Name = "Cestos", IconUrl = "url_de_la_imagen_de_subcategoria5" },
            };


            return subCategories;
        }
    }
}
