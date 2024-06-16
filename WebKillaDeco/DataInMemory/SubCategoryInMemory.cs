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
                new SubCategory { CategoryId = 1, Name = "Vajilla", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 1, Name = "Café & Te", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 1, Name = "Cubiertos", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 1, Name = "Mantelería", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 1, Name = "Utensilios", IconUrl="~/images/category-icon/decoracion.png"},
                
                //COCINA
                new SubCategory { CategoryId = 2, Name = "Porta Condimentos", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Frascos", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 2, Name = "Latas", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Ollas & Sartenes", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Recipiente para horno", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Organizador de Cocina", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Accesorios de Cocina", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 2, Name = "Utensilios", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 2, Name = "Cuchillos", IconUrl="~/images/category-icon/decoracion.png" },

                //ASADO & VINO
                new SubCategory { CategoryId = 3, Name = "Parrillas", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 3, Name = "Accesorios de vino", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 3, Name = "Accesorios de bar", IconUrl="~/images/category-icon/decoracion.png" },

                //DECO
                new SubCategory { CategoryId = 4, Name = "Manta & almohadones", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 4, Name = "Portavelas & Floreros", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 4, Name = "Accesorio Deco", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 4, Name = "Lamparas", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 4, Name = "Plantas", IconUrl="~/images/category-icon/decoracion.png" },

                //AROMAS
                new SubCategory { CategoryId = 5, Name = "Cremas & Jabones", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 5, Name = "Fragancias",IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 5, Name = "Difusores", IconUrl="~/images/category-icon/decoracion.png"},
                new SubCategory { CategoryId = 5, Name = "vELAS", IconUrl="~/images/category-icon/decoracion.png" },

                //BAÑO & LAVADERO
                new SubCategory { CategoryId = 6, Name = "Accesorio de baño", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 6, Name = "Lavadero", IconUrl="~/images/category-icon/decoracion.png" },
                new SubCategory { CategoryId = 6, Name = "Cestos", IconUrl="~/images/category-icon/decoracion.png" },
            };


            return subCategories;
        }
    }
}
