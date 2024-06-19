using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class ProductInMemory
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new()
            {
                // Cubiertos
                new Product
                {
                    SubCategoryId = 1,
                    Sku = 1001,
                    Name = "Cuchara de Acero Inoxidable",
                    Description = "Cuchara de acero inoxidable de alta calidad",
                    CurrentPrice = 5.99m,
                    Active = true,
                    ImageUrl = "url_to_image_cuchara",
                    AvailableStock = 200,
                    Weight = 0.1m,
                      Width  = 200,
                    Height   = 130,
                    Depth   = 5,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },
                new Product
                {
                    SubCategoryId = 1,
                    Sku = 1002,
                    Name = "Tenedor de Acero Inoxidable",
                    Description = "Tenedor de acero inoxidable de alta calidad",
                    CurrentPrice = 5.99m,
                    Active = true,
                    ImageUrl = "url_to_image_tenedor",
                    AvailableStock = 200,
                    Weight = 0.1m,
                    Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },

                // Manteleria
                new Product
                {
                    SubCategoryId = 2,
                    Sku = 2001,
                    Name = "Mantel de Algodón Blanco",
                    Description = "Mantel de algodón blanco de alta calidad",
                    CurrentPrice = 25.99m,
                    Active = true,
                    ImageUrl = "url_to_image_mantel",
                    AvailableStock = 50,
                    Weight = 0.5m,
                      Width  = 50,
                    Height   = 10,
                    Depth   = 7,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 2,
                    Sku = 2002,
                    Name = "Mantel de Lino Gris",
                    Description = "Mantel de lino gris de alta calidad",
                    CurrentPrice = 30.99m,
                    Active = true,
                    ImageUrl = "url_to_image_mantel_lino",
                    AvailableStock = 40,
                    Weight = 0.6m,
                      Width  = 300,
                    Height   = 150,
                    Depth   = 140,
                    Color = "Gris",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Utensilios
                new Product
                {
                    SubCategoryId = 3,
                    Sku = 3001,
                    Name = "Espátula de Silicona",
                    Description = "Espátula de silicona resistente al calor",
                    CurrentPrice = 7.99m,
                    Active = true,
                    ImageUrl = "url_to_image_espatula",
                    AvailableStock = 100,
                    Weight = 0.2m,
                      Width  = 180,
                    Height   = 120,
                    Depth   = 70,
                    Color = "Rojo",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },
                new Product
                {
                    SubCategoryId = 3,
                    Sku = 3002,
                    Name = "Batidor de Mano",
                    Description = "Batidor de mano de acero inoxidable",
                    CurrentPrice = 9.99m,
                    Active = true,
                    ImageUrl = "url_to_image_batidor",
                    AvailableStock = 80,
                    Weight = 0.15m,  
                    Width  = 50,
                    Height   = 50,
                    Depth   = 7,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },

                // Porta Condimentos
                new Product
                {
                    SubCategoryId = 4,
                    Sku = 4001,
                    Name = "Porta Condimentos Giratorio",
                    Description = "Porta condimentos giratorio con 12 frascos",
                    CurrentPrice = 29.99m,
                    Active = true,
                    ImageUrl = "url_to_image_porta_condimentos",
                    AvailableStock = 30,
                    Weight = 1.0m,
                      Width  = 10,
                    Height   = 10,
                    Depth   = 5,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 4,
                    Sku = 4002,
                    Name = "Porta Condimentos de Bambú",
                    Description = "Porta condimentos de bambú con 8 frascos",
                    CurrentPrice = 24.99m,
                    Active = true,
                    ImageUrl = "url_to_image_porta_condimentos_bambu",
                    AvailableStock = 40,
                    Weight = 0.8m,
                    Width = 1000, 
                    Height = 500, 
                    Depth = 400,
                    Color = "Marrón",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Frascos
                new Product
                {
                    SubCategoryId = 5,
                    Sku = 5001,
                    Name = "Frasco de Vidrio Hermético",
                    Description = "Frasco de vidrio hermético de 1 litro",
                    CurrentPrice = 9.99m,
                    Active = true,
                    ImageUrl = "url_to_image_frasco",
                    AvailableStock = 100,
                    Weight = 0.5m,
                    Width = 100, 
                    Height = 50, 
                    Depth = 70,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },
                new Product
                {
                    SubCategoryId = 5,
                    Sku = 5002,
                    Name = "Frasco de Vidrio con Tapa de Bambú",
                    Description = "Frasco de vidrio con tapa de bambú de 1.5 litros",
                    CurrentPrice = 12.99m,
                    Active = true,
                    ImageUrl = "url_to_image_frasco_bambu",
                    AvailableStock = 80,
                    Weight = 0.7m,
                    Width = 1000, 
                    Height = 50, 
                    Depth = 70,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },

                // Latas
                new Product
                {
                    SubCategoryId = 6,
                    Sku = 6001,
                    Name = "Lata para Té",
                    Description = "Lata decorativa para almacenamiento de té",
                    CurrentPrice = 5.99m,
                    Active = true,
                    ImageUrl = "url_to_image_lata_te",
                    AvailableStock = 150,
                    Weight = 0.2m,
                     Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Verde",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },
                new Product
                {
                    SubCategoryId = 6,
                    Sku = 6002,
                    Name = "Lata para Café",
                    Description = "Lata decorativa para almacenamiento de café",
                    CurrentPrice = 6.99m,
                    Active = true,
                    ImageUrl = "url_to_image_lata_cafe",
                    AvailableStock = 140,
                    Weight = 0.25m,
                    Width = 1000, Height = 550, Depth = 75,
                    Color = "Marrón",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },

                // Ollas & Sartenes
                new Product
                {
                    SubCategoryId = 7,
                    Sku = 7001,
                    Name = "Sartén de Hierro Fundido",
                    Description = "Sartén de hierro fundido de 30 cm",
                    CurrentPrice = 39.99m,
                    Active = true,
                    ImageUrl = "url_to_image_sarten",
                    AvailableStock = 50,
                    Weight = 3.0m,
                      Width  = 101,
                    Height   = 55,
                    Depth   = 50,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 7,
                    Sku = 7002,
                    Name = "Olla de Acero Inoxidable",
                    Description = "Olla de acero inoxidable de 5 litros",
                    CurrentPrice = 49.99m,
                    Active = true,
                    ImageUrl = "url_to_image_olla",
                    AvailableStock = 40,
                    Weight = 2.5m,
                     Width  = 1100,
                    Height   = 150,
                    Depth   = 170,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Recipiente para horno
                new Product
                {
                    SubCategoryId = 8,
                    Sku = 8001,
                    Name = "Recipiente de Vidrio para Horno",
                    Description = "Recipiente de vidrio resistente al calor",
                    CurrentPrice = 14.99m,
                    Active = true,
                    ImageUrl = "url_to_image_recipiente_vidrio",
                    AvailableStock = 60,
                    Weight = 1.0m,
                     Width  = 170,
                    Height   = 70,
                    Depth   = 70,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 8,
                    Sku = 8002,
                    Name = "Molde para Horno de Silicona",
                    Description = "Molde para horno de silicona flexible",
                    CurrentPrice = 12.99m,
                    Active = true,
                    ImageUrl = "url_to_image_molde_silicona",
                    AvailableStock = 70,
                    Weight = 0.5m,
                     Width  = 20,
                    Height   = 50,
                    Depth   = 7,
                    Color = "Rojo",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Organizador de Cocina
                new Product
                {
                    SubCategoryId = 9,
                    Sku = 9001,
                    Name = "Organizador de Especias",
                    Description = "Organizador de especias para cocina",
                    CurrentPrice = 19.99m,
                    Active = true,
                    ImageUrl = "url_to_image_organizador_especias",
                    AvailableStock = 40,
                    Weight = 0.8m,
                    Width = 100, 
                    Height = 50, 
                    Depth = 70,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 9,
                    Sku = 9002,
                    Name = "Organizador de Cajones",
                    Description = "Organizador de cajones para utensilios",
                    CurrentPrice = 14.99m,
                    Active = true,
                    ImageUrl = "url_to_image_organizador_cajones",
                    AvailableStock = 50,
                    Weight = 0.7m,
                    Width = 100, 
                    Height = 80, 
                    Depth = 170,
                    Color = "Gris",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Accesorios de Cocina
                new Product
                {
                    SubCategoryId = 10,
                    Sku = 10001,
                    Name = "Juego de Medidores",
                    Description = "Juego de medidores de acero inoxidable",
                    CurrentPrice = 9.99m,
                    Active = true,
                    ImageUrl = "url_to_image_medidores",
                    AvailableStock = 100,
                    Weight = 0.3m,
                    Width  = 110,
                    Height   = 70,
                    Depth   = 70,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },
                new Product
                {
                    SubCategoryId = 10,
                    Sku = 10002,
                    Name = "Juego de Espátulas",
                    Description = "Juego de espátulas de silicona resistente al calor",
                    CurrentPrice = 15.99m,
                    Active = true,
                    ImageUrl = "url_to_image_espatulas",
                    AvailableStock = 80,
                    Weight = 0.4m,
                    Width = 90, 
                    Height = 52, 
                    Depth = 22,
                    Color = "Azul",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Tablas para picar
                new Product
                {
                    SubCategoryId = 11,
                    Sku = 11001,
                    Name = "Tabla de Picar de Bambú",
                    Description = "Tabla de picar de bambú de alta calidad",
                    CurrentPrice = 19.99m,
                    Active = true,
                    ImageUrl = "url_to_image_tabla_bambu",
                    AvailableStock = 70,
                    Weight = 1.0m,
                    Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Marrón",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 11,
                    Sku = 11002,
                    Name = "Tabla de Picar de Plástico",
                    Description = "Tabla de picar de plástico resistente",
                    CurrentPrice = 9.99m,
                    Active = true,
                    ImageUrl = "url_to_image_tabla_plastico",
                    AvailableStock = 100,
                    Weight = 0.5m,
                     Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.05m
                },

                // Utensilios
                new Product
                {
                    SubCategoryId = 12,
                    Sku = 12001,
                    Name = "Juego de Utensilios de Cocina",
                    Description = "Juego de utensilios de cocina de silicona",
                    CurrentPrice = 29.99m,
                    Active = true,
                    ImageUrl = "url_to_image_utensilios",
                    AvailableStock = 60,
                    Weight = 1.2m,
                    Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 12,
                    Sku = 12002,
                    Name = "Juego de Utensilios de Madera",
                    Description = "Juego de utensilios de cocina de madera",
                    CurrentPrice = 24.99m,
                    Active = true,
                    ImageUrl = "url_to_image_utensilios_madera",
                    AvailableStock = 70,
                    Weight = 1.0m,
                    Width = 1010, 
                    Height = 80, 
                    Depth = 70,
                    Color = "Marrón",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Cuchillos
                new Product
                {
                    SubCategoryId = 13,
                    Sku = 13001,
                    Name = "Cuchillo Chef",
                    Description = "Cuchillo de chef de acero inoxidable",
                    CurrentPrice = 39.99m,
                    Active = true,
                    ImageUrl = "url_to_image_cuchillo_chef",
                    AvailableStock = 40,
                    Weight = 0.5m,
                    Width = 110, 
                    Height = 80, 
                    Depth = 10,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 13,
                    Sku = 13002,
                    Name = "Juego de Cuchillos de Cocina",
                    Description = "Juego de cuchillos de cocina de acero inoxidable",
                    CurrentPrice = 59.99m,
                    Active = true,
                    ImageUrl = "url_to_image_juego_cuchillos",
                    AvailableStock = 50,
                    Weight = 2.0m,
                    Width = 150, 
                    Height = 90, 
                    Depth = 15,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Parrillas
                new Product
                {
                    SubCategoryId = 14,
                    Sku = 14001,
                    Name = "Parrilla Portátil",
                    Description = "Parrilla portátil de acero inoxidable",
                    CurrentPrice = 99.99m,
                    Active = true,
                    ImageUrl = "url_to_image_parrilla",
                    AvailableStock = 30,
                    Weight = 10.0m,
                    Width  = 200,
                    Height   = 50,
                    Depth   = 7,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 14,
                    Sku = 14002,
                    Name = "Parrilla a Carbón",
                    Description = "Parrilla a carbón con tapa",
                    CurrentPrice = 129.99m,
                    Active = true,
                    ImageUrl = "url_to_image_parrilla_carbon",
                    AvailableStock = 20,
                    Weight = 12.0m,
                     Width  = 110,
                    Height   = 50,
                    Depth   = 10,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Accesorios de vino & bar
                new Product
                {
                    SubCategoryId = 15,
                    Sku = 15001,
                    Name = "Abridor de Vino",
                    Description = "Abridor de vino de acero inoxidable",
                    CurrentPrice = 19.99m,
                    Active = true,
                    ImageUrl = "url_to_image_abridor_vino",
                    AvailableStock = 60,
                    Weight = 0.3m,
                    Width  = 80,
                    Height   = 50,
                    Depth   = 20,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 15,
                    Sku = 15002,
                    Name = "Set de Bar",
                    Description = "Set de bar con coctelera y medidores",
                    CurrentPrice = 39.99m,
                    Active = true,
                    ImageUrl = "url_to_image_set_bar",
                    AvailableStock = 50,
                    Weight = 1.0m,
                    Width  = 80,
                    Height   = 30,
                    Depth   = 20,
                    Color = "Plata",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Manta & almohadones
                new Product
                {
                    SubCategoryId = 16,
                    Sku = 16001,
                    Name = "Manta de Lana",
                    Description = "Manta de lana suave y cálida",
                    CurrentPrice = 49.99m,
                    Active = true,
                    ImageUrl = "url_to_image_manta",
                    AvailableStock = 40,
                    Weight = 1.5m,
                    Width  = 70,
                    Height   = 70,
                    Depth   = 70,
                    Color = "Gris",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 16,
                    Sku = 16002,
                    Name = "Almohadón Decorativo",
                    Description = "Almohadón decorativo de algodón",
                    CurrentPrice = 19.99m,
                    Active = true,
                    ImageUrl = "url_to_image_almohadon",
                    AvailableStock = 60,
                    Weight = 0.7m,
                    Width  = 110,
                    Height   = 100,
                    Depth   = 80,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Portavelas & Floreros
                new Product
                {
                    SubCategoryId = 17,
                    Sku = 17001,
                    Name = "Portavelas de Vidrio",
                    Description = "Portavelas de vidrio decorativo",
                    CurrentPrice = 12.99m,
                    Active = true,
                    ImageUrl = "url_to_image_portavelas",
                    AvailableStock = 80,
                    Weight = 0.5m,
                    Width  = 100,
                    Height   = 50,
                    Depth   = 70,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 17,
                    Sku = 17002,
                    Name = "Florero de Cerámica",
                    Description = "Florero de cerámica decorativo",
                    CurrentPrice = 24.99m,
                    Active = true,
                    ImageUrl = "url_to_image_florero",
                    AvailableStock = 50,
                    Weight = 1.0m,
                   Width  = 110,
                    Height   = 100,
                    Depth   = 80,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Accesorio Deco
                new Product
                {
                    SubCategoryId = 18,
                    Sku = 18001,
                    Name = "Espejo Decorativo",
                    Description = "Espejo decorativo de pared",
                    CurrentPrice = 39.99m,
                    Active = true,
                    ImageUrl = "url_to_image_espejo",
                    AvailableStock = 30,
                    Weight = 2.0m,
                    Width  = 110,
                    Height   = 100,
                    Depth   = 80,
                    Color = "Doradado",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 18,
                    Sku = 18002,
                    Name = "Reloj de Pared",
                    Description = "Reloj de pared decorativo",
                    CurrentPrice = 29.99m,
                    Active = true,
                    ImageUrl = "url_to_image_reloj",
                    AvailableStock = 40,
                    Weight = 1.5m,
                    Width  = 110,
                    Height   = 100,
                    Depth   = 80,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Lamparas
                new Product
                {
                    SubCategoryId = 19,
                    Sku = 19001,
                    Name = "Lámpara de Mesa",
                    Description = "Lámpara de mesa con base de cerámica",
                    CurrentPrice = 49.99m,
                    Active = true,
                    ImageUrl = "url_to_image_lampara_mesa",
                    AvailableStock = 30,
                    Weight = 2.0m,
                   Width  = 110,
                    Height   = 100,
                    Depth   = 80,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 19,
                    Sku = 19002,
                    Name = "Lámpara de Pie",
                    Description = "Lámpara de pie con diseño moderno",
                    CurrentPrice = 99.99m,
                    Active = true,
                    ImageUrl = "url_to_image_lampara_pie",
                    AvailableStock = 20,
                    Weight = 5.0m,
                    Width  = 87,
                    Height   = 25,
                    Depth   = 10,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Plantas
                new Product
                {
                    SubCategoryId = 20,
                    Sku = 20001,
                    Name = "Planta Artificial",
                    Description = "Planta artificial decorativa",
                    CurrentPrice = 29.99m,
                    Active = true,
                    ImageUrl = "url_to_image_planta",
                    AvailableStock = 50,
                    Weight = 1.0m,
                     Width  = 87,
                    Height   = 25,
                    Depth   = 10,
                    Color = "Verde",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 20,
                    Sku = 20002,
                    Name = "Planta Natural en Maceta",
                    Description = "Planta natural en maceta de cerámica",
                    CurrentPrice = 39.99m,
                    Active = true,
                    ImageUrl = "url_to_image_planta_maceta",
                    AvailableStock = 40,
                    Weight = 2.0m,
                     Width  = 87,
                    Height   = 25,
                    Depth   = 10,
                    Color = "Verde",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Cremas & Jabones
                new Product
                {
                    SubCategoryId = 21,
                    Sku = 21001,
                    Name = "Crema Hidratante",
                    Description = "Crema hidratante para el cuerpo",
                    CurrentPrice = 14.99m,
                    Active = true,
                    ImageUrl = "url_to_image_crema",
                    AvailableStock = 80,
                    Weight = 0.5m,
                     Width  = 87,
                    Height   = 25,
                    Depth   = 10,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 21,
                    Sku = 21002,
                    Name = "Jabón Artesanal",
                    Description = "Jabón artesanal con fragancia natural",
                    CurrentPrice = 7.99m,
                    Active = true,
                    ImageUrl = "url_to_image_jabon",
                    AvailableStock = 100,
                    Weight = 0.2m,
                     Width  = 10,
                    Height   = 10,
                    Depth   = 5,
                    Color = "Beige",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Fragancias
                new Product
                {
                    SubCategoryId = 22,
                    Sku = 22001,
                    Name = "Ambientador en Spray",
                    Description = "Ambientador en spray con fragancia floral",
                    CurrentPrice = 9.99m,
                    Active = true,
                    ImageUrl = "url_to_image_ambientador",
                    AvailableStock = 90,
                    Weight = 0.3m,
                    Width  = 10,
                    Height   = 10,
                    Depth   = 5,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 22,
                    Sku = 22002,
                    Name = "Difusor de Aromas",
                    Description = "Difusor de aromas con varillas de bambú",
                    CurrentPrice = 19.99m,
                    Active = true,
                    ImageUrl = "url_to_image_difusor",
                    AvailableStock = 70,
                    Weight = 0.5m,
                    Width  = 10,
                    Height   = 10,
                    Depth   = 5,
                    Color = "Transparente",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },

                // Difusores
                new Product
                {
                    SubCategoryId = 23,
                    Sku = 23001,
                    Name = "Difusor Eléctrico",
                    Description = "Difusor eléctrico de aromas",
                    CurrentPrice = 29.99m,
                    Active = true,
                    ImageUrl = "url_to_image_difusor_electrico",
                    AvailableStock = 50,
                    Weight = 0.8m,
                    Width  = 10,
                    Height   = 10,
                    Depth   = 5,
                    Color = "Blanco",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                },
                new Product
                {
                    SubCategoryId = 23,
                    Sku = 23002,
                    Name = "Humidificador de Aromas",
                    Description = "Humidificador de aromas con luz LED",
                    CurrentPrice = 34.99m,
                    Active = true,
                    ImageUrl = "url_to_image_humidificador",
                    AvailableStock = 40,
                    Weight = 1.0m,
                    Width  = 10,
                    Height   = 80,
                    Depth   = 5,
                    Color = "Negro",
                    PublicationDate = DateTime.Now,
                    Discount = 0.1m
                }
      };

            return products;
        }
    }
}
