namespace WebKillaDeco.Helpers
{
    public static class Restrictions
    {
        // User and Client Restrictions (Restricciones para usuarios y clientes)
        public const int NumDNICharacters = 8; // Longitud única de DNI
        public const int NumCUILCharacters = 11; // Longitud única de CUIL
        public const int NumCUITCharacters = 11; // Longitud única de CUIT
        public const int MinUsername = 3; // Longitud mínima para nombres de usuario
        public const int MaxUsername = 30; // Longitud máxima para nombres de usuario
        public const int MinUserLastName = 3; // Longitud mínima para apellidos
        public const int MaxUserLastName = 50; // Longitud máxima para apellidos
        public const int MinEmployeeOccupation = 4; // Longitud mínima para Ocupación
        public const int MaxEmployeeOccupation = 30; // Longitud máxima para Ocupación
        public const int MinEmployeeSalary = 100000; // Salario mínimo
        public const int MaxEmployeeSalary = 2000000; // Salario máximo

        // Email and Phone Restrictions (Restricciones para correos electrónicos, contraseña y números de teléfono)
        public const int MinEmail = 5; // Longitud mínima para direcciones de correo electrónico
        public const int MaxEmail = 254; // Longitud máxima para direcciones de correo electrónico
        public const int MinPhone = 10; // Longitud mínima para números de teléfono
        public const int MaxPhone = 15; // Longitud máxima para números de teléfono
        public const int MinPassword = 8; // Longitud mínima para contraseñas
        public const int MaxPassword = 30; // Longitud máxima para contraseñas

        // Address Restrictions (Restricciones para direcciones)
        public const int MinStreet = 5; // Longitud mínima para nombres de calles
        public const int MaxStreet = 100; // Longitud máxima para nombres de calles
        public const int MinCity = 2; // Longitud mínima para nombres de ciudades
        public const int MaxCity = 50; // Longitud máxima para nombres de ciudades
        public const int MinProvince = 2; // Longitud mínima para nombres de provincias
        public const int MaxProvince = 50; // Longitud máxima para nombres de provincias
        public const int MinPostalCode = 4; // Longitud mínima para códigos postales
        public const int MaxPostalCode = 10; // Longitud máxima para códigos postales
        public const int MinCountry = 2; // Longitud mínima para nombres de países
        public const int MaxCountry = 50; // Longitud máxima para nombres de países

        // Category Restrictions (Restricciones para categorías)
        public const int MinCategoryName = 3; // Longitud mínima para nombres de categorías
        public const int MaxCategoryName = 100; // Longitud máxima para nombres de categorías
        public const int MinCategoryImageUrl = 5; // Longitud mínima para ImagenUrl de categorías
        public const int MaxCategoryImageUrl= 200; // Longitud máxima para ImagenUrl de categorías
        public const int MinCategoryIconUrl = 5; // Longitud mínima para IconUrl de categorías
        public const int MaxCategoryIconUrl= 200; // Longitud máxima para IconUrl de categorías

        // SubCategory Restrictions (Restricciones para subcategorías)
        public const int MinSubCategoryName = 3; // Longitud mínima para nombres de subcategorías
        public const int MaxSubCategoryName = 100; // Longitud máxima para nombres de subcategorías
        public const int MinSubCategoryIcon = 5; // Icono mínima para nombres de subcategorías
        public const int MaxSubCategoryIcon = 200; // Icono máxima para nombres de subcategorías

        // Product Restrictions (Restricciones para productos)
        public const int MinProductName = 2; // Longitud mínima para nombres de productos
        public const int MaxProductName = 100; // Longitud máxima para nombres de productos
        public const int MinProductBrand= 2; // Longitud mínima para marcas de productos
        public const int MaxProductBrand = 100; // Longitud máxima para marcas de productos
        public const int MinProductDescription = 10; // Longitud mínima para descripciones de productos
        public const int MaxProductDescription = 5000; // Longitud máxima para descripciones de productos
        public const int MinProductSku = 1000000; // Longitud mínima para Sku de productos
        public const int MaxProductSku = 9999999; // Longitud máxima para Sku de productos
        public const double MinProductCurrentPrice = 0.01; // Precio mínimo para productos
        public const double MaxProductCurrentPrice = 10000.00; // Precio máximo para productos
        public const double MinProductAvailableStock = 0; // Stock mínimo para productos
        public const double MaxProductAvailableStock = 9999; // Stock máximo para productos
        public const double MinProductWeight = 1; // Peso mínimo para productos
        public const double MaxProductWeight = 1000; // Peso máximo para productos
        public const int MinProductWidth = 1; // Dimensión mínima para ancho producto
        public const int MaxProductWidth = 30000; // Dimensión máxima para ancho producto
        public const int MinProductHeight = 1; // Dimensión mínima para alto producto
        public const int MaxProductHeight = 30000; // Dimensión máxima alto ancho producto
        public const int MinProductDepth = 1; // Dimensión mínima para profundidad producto
        public const int MaxProductDepth = 30000; // Dimensión máxima para profundidad producto
        public const int MinProductColors = 3; // Dimensión mínima para productos
        public const int MaxProductColors = 100; // Dimensión máxima para productos
        public const double MinProductDiscount = 1; // Discount mínima para productos
        public const double MaxProductDiscount = 100; // Discount máxima para productos

        // Cart and Cart Item Restrictions (Restricciones para carritos y artículos de carrito)
        public const int MinCartItems = 1; // Número mínimo de artículos en un carrito
        public const int MaxCartItems = 100; // Número máximo de artículos en un carrito
        public const int MinCartItemQuantity = 1; // Cantidad mínima de un artículo de carrito
        public const int MaxCartItemQuantity = 100; // Cantidad máxima de un artículo de carrito

        // Entry Restrictions (for blog or product descriptions) (Restricciones para entradas)
        public const int MinEntryTitle = 4; // Longitud mínima para títulos de entrada
        public const int MaxEntryTitle = 100; // Longitud máxima para títulos de entrada
        public const int MinEntryDescription = 10; // Longitud mínima para descripciones de entrada
        public const int MaxEntryDescription = 2000; // Longitud máxima para descripciones de entrada

        // Question Restrictions (Restricciones para preguntas)
        public const int MinQuestionDescription = 4; // Longitud mínima para descripciones de preguntas
        public const int MaxQuestionDescription = 500; // Longitud máxima para descripciones de preguntas

        // Answer Restrictions (Restricciones para respuestas)
        public const int MinAnswerDescription = 4; // Longitud mínima para descripciones de respuestas
        public const int MaxAnswerDescription = 500; // Longitud máxima para descripciones de respuestas

        // Coupon Restrictions (Restricciones para cupones)
        public const int MinCouponCode = 5; // Longitud mínima para códigos de cupones
        public const int MaxCouponCode = 20; // Longitud máxima para códigos de cupones
        public const decimal MinCouponDiscount = 0.01m; // Valor de descuento mínimo para cupones
        public const decimal MaxCouponDiscount = 100.00m; // Valor de descuento máximo para cupones

        // Order Restrictions (Restricciones para órdenes)
        public const int MinOrderAmount = 1; // Cantidad mínima de un artículo de orden
        public const int MaxOrderAmount = 100; // Cantidad máxima de un artículo de orden
        public const decimal MinOrderTotal = 0.01m; // Valor total mínimo para órdenes
        public const decimal MaxOrderTotal = 100000.00m; // Valor total máximo para órdenes

        // Rating Restrictions (Restricciones para calificaciones)
        public const int MinRating = 1; // Valor de calificación mínimo
        public const int MaxRating = 5; // Valor de calificación máximo
        public const int MinRatingComment = 10; // Longitud mínima para comentarios de calificación
        public const int MaxRatingComment = 1000; // Longitud máxima para comentarios de calificación
    }

}
