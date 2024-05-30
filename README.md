# Carrito de compras 📖

## Objetivos 📋
Desarrollar un sistema que permita la administración y visualización general de un Ecommerce, diferenciando las funciones según el rol del usuario. Utilizar preferentemente Visual Studio 2022 y crear una aplicación empleando las versiones más recientes de ASP.NET Core MVC. El desarrollo se realizará en C# y se enfocará en la implementación de un carrito de compras para el Ecommerce


## Enunciado 📢
Proceso de ejecución en alto nivel ☑️
Crear un nuevo proyecto en visual studio.
Adicionar todos los modelos dentro de la carpeta Models cada uno en un archivo separado.
Especificar todas las restricciones y validaciones solicitadas a cada una de las entidades. DataAnnotations.
Crear las relaciones entre las entidades
Crear una carpeta Data que dentro tendrá al menos la clase que representará el contexto de la base de datos DbContext.
Crear el DbContext utilizando base de datos en memoria (con fines de testing inicial). DbContext, Database In-Memory.
Agregar los DbSet para cada una de las entidades en el DbContext.
Crear el Scaffolding para permitir los CRUD de las entidades al menos solicitadas en el enunciado.
Aplicar las adecuaciones y validaciones necesarias en los controladores.
Realizar un sistema de login con al menos los roles equivalentes a y (o con permisos elevados).
Si el proyecto lo requiere, generar el proceso de registración.
Un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
El sólo podrá tomar acción en el sistema, en base al rol que tiene.
Realizar todos los ajustes necesarios en los modelos y/o funcionalidades.
Realizar los ajustes requeridos del lado de los permisos.
Todo lo referido a la presentación de la aplicaión (cuestiones visuales).


## Entidades 📄
- Address
- Answer
- Cart
- CartItem
- Category
- Client
- Coupon
- DetailOrderSupplier
- Employee
- ErrorViewModel
- Favorite
- Location
- PaymentMethod
- Product
- Purchase
- PurchaseDetail
- Qualification
- Question
- Rol
- State
- StockItem
- SubCategory
- Supplier
- SupplierOrder
- User
  
** Importante: Todas las entidades deben tener su identificador unico. Id o ClassNameId


## Descripción de Entidades

### 1. Address
Almacena la dirección completa de un usuario, incluyendo calle, ciudad, provincia, código postal y país. Esta información es crucial para la entrega de productos y la correspondencia entre la empresa y el cliente. Las direcciones están vinculadas a usuarios específicos, facilitando la gestión de múltiples direcciones por usuario.

- **AddressId** (int): Clave primaria.
- **UserId** (int): Clave foránea que referencia a la entidad User.
- **Street** (string?): Calle.
- **City** (string?): Ciudad.
- **Province** (string?): Provincia.
- **PostalCode** (string?): Código postal.
- **Country** (string?): País.
- **User** (User?): Relación con la entidad User.

### 2. Answer
Permite a los empleados responder preguntas de los clientes, facilitando la comunicación y aclaración de dudas. Esto mejora la experiencia del cliente y puede influir en su decisión de compra al proporcionar información oportuna y relevante. Las respuestas están vinculadas a preguntas específicas, asegurando una referencia clara y organizada.

- **Id** (int): Clave primaria.
- **EmployeeId** (int): Clave foránea que referencia a la entidad Employee.
- **QuestionId** (int): Clave foránea que referencia a la entidad Question.
- **Description** (string?): Descripción de la respuesta.
- **PublicationDate** (DateTime?): Fecha de publicación.
- **Question** (Question?): Relación con la entidad Question.
- **Employee** (Employee?): Relación con la entidad Employee.

### 3.Cart
Gestiona los productos seleccionados por el cliente antes de la compra, permitiendo agregar, modificar o eliminar items. Calcula automáticamente el subtotal en función de los productos añadidos, proporcionando una visión clara del costo total. Además, facilita el proceso de pago al mantener una lista actualizada de los productos seleccionados.

- **CartId** (int): Clave primaria.
- **ClientId** (int): Clave foránea que referencia a la entidad Client.
- **Active** (bool): Indica si el carrito está activo.
- **Subtotal** (decimal): Subtotal calculado a partir de los items en el carrito.
- **Client** (Client?): Relación con la entidad Client.
- **CartItems** (List<CartItem>?): Lista de items en el carrito.

### 4. CartItem
Almacena información detallada sobre cada producto en el carrito de compras, incluyendo cantidad y precios. Cada item está vinculado a un carrito y a un producto específico, facilitando la gestión precisa de los productos seleccionados para la compra. Esto asegura un seguimiento exacto del inventario y los precios aplicados.

- **CartItemId** (int): Clave primaria.
- **CartId** (int): Clave foránea que referencia a la entidad Cart.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **UnitPrice** (decimal?): Precio unitario del producto.
- **Amount** (int?): Cantidad del producto.
- **Subtotal** (decimal?): Subtotal calculado como UnitPrice * Amount.
- **Cart** (Cart?): Relación con la entidad Cart.
- **Product** (Product?): Relación con la entidad Product.

### 5. Category
Agrupa productos similares bajo una categoría común, mejorando la organización y facilitando la búsqueda de productos por parte de los clientes. Las categorías pueden contener múltiples subcategorías para una clasificación más específica. Esto ayuda a los clientes a navegar y encontrar productos rápidamente, mejorando la experiencia de usuario.

- **CategoryId** (int): Clave primaria.
- **Name** (string?): Nombre de la categoría.
- **ImageUrl** (string?): URL de la imagen de la categoría.
- **SubCategories** (List<SubCategory>?): Lista de subcategorías pertenecientes a esta categoría.

### 6. Client
Gestiona la información y actividad de compra de los clientes dentro del sistema. Almacena detalles sobre compras, carritos de compra, calificaciones, productos favoritos y preguntas realizadas, proporcionando una visión completa del comportamiento del cliente. Esto permite personalizar la experiencia del usuario y mejorar el servicio al cliente.

- **Purchases** (List<Purchase>?): Lista de compras realizadas por el cliente.
- **Carts** (List<Cart>?): Lista de carritos de compras del cliente.
- **Qualifications** (List<Qualification>?): Lista de calificaciones realizadas por el cliente.
- **Favorites** (List<Favorite>?): Lista de productos favoritos del cliente.
- **Questions** (List<Question>?): Lista de preguntas realizadas por el cliente.

### 7. Coupon
Gestiona descuentos promocionales que los clientes pueden aplicar a sus compras. Los cupones pueden tener un valor de descuento fijo o un porcentaje, y pueden tener una fecha de expiración, controlando así su validez y uso. Esto incentiva las compras y ayuda en la gestión de campañas de marketing.

- **CouponId** (int): Clave primaria.
- **Code** (string?): Código del cupón.
- **Description** (string?): Descripción del cupón.
- **Discount** (decimal): Descuento proporcionado por el cupón (puede ser un porcentaje o un valor fijo).
- **ExpirationDate** (DateTime): Fecha de expiración del cupón.
- **Used** (bool): Indica si el cupón ha sido usado.

### 8. DetailOrderSupplier
Detalla la información específica de los productos incluidos en una orden a un proveedor, como cantidad y precio unitario. Esto permite un seguimiento preciso de las órdenes de suministro y la gestión de inventarios. Asegura que los productos necesarios sean ordenados y recibidos de manera eficiente.

- **DetailOrderSupplierId** (int): Clave primaria.
- **SupplierOrderId** (int): Clave foránea que referencia a la entidad SupplierOrder.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **Amount** (int): Cantidad de productos ordenados.
- **UnitPrice** (decimal): Precio unitario del producto.
- **SupplierOrder** (SupplierOrder?): Relación con la entidad SupplierOrder.
- **Product** (Product?): Relación con la entidad Product.
  
### 9. Employee
Gestiona la información de los empleados, incluyendo su ocupación y salario. Los empleados también pueden interactuar con el sistema respondiendo preguntas de clientes, contribuyendo a la resolución de dudas y mejorando la satisfacción del cliente. Además, almacena el historial de interacciones y respuestas proporcionadas.

- **Occupation** (string?): Ocupación del empleado.
- **Salary** (decimal): Salario del empleado.
- **Answers** (List<Answer>?): Lista de respuestas proporcionadas por el empleado.

### 10. Favorite
Permite a los clientes marcar productos como favoritos para fácil acceso futuro. Esta funcionalidad facilita a los clientes volver a productos de su interés rápidamente, mejorando la experiencia de compra. También permite a la empresa identificar productos populares y tendencias de mercado.

- **FavoriteId** (int): Clave primaria.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **ClientId** (int): Clave foránea que referencia a la entidad Client.
- **DateFavorite** (DateTime): Fecha en que el producto fue marcado como favorito.
- **Product** (Product?): Relación con la entidad Product.
- **Client** (Client?): Relación con la entidad Client.

### 11. Location
Almacena información sobre ubicaciones físicas de la empresa, como almacenes o tiendas, incluyendo detalles de contacto. También gestiona los items en stock en cada ubicación, permitiendo un control eficiente del inventario. Esto asegura que los productos estén disponibles donde y cuando se necesiten.

- **LocationId** (int): Clave primaria.
- **AddressId** (int): Clave foránea que referencia a la entidad Address.
- **Name** (string?): Nombre de la ubicación.
- **Phone** (string?): Teléfono de contacto.
- **Email** (string?): Correo electrónico de contacto.
- **Address** (Address?): Relación con la entidad Address.
- **StockItems** (List<StockItem>?): Lista de items en stock en esta ubicación.

### 12. Product
Gestiona información detallada sobre productos disponibles para la venta, incluyendo precios, stock, y especificaciones. Los productos están vinculados a subcategorías y categorías, y pueden recibir calificaciones y comentarios de clientes. Esto proporciona una visión completa del inventario y facilita la promoción de productos.

- **ProductId** (int): Clave primaria.
- **SubCategoryId** (int): Clave foránea que referencia a la entidad SubCategory.
- **Sku** (int): Código de referencia del producto.
- **Name** (string?): Nombre del producto.
- **Description** (string?): Descripción del producto.
- **CurrentPrice** (decimal): Precio actual del producto.
- **Active** (bool): Indica si el producto está activo.
- **ImageUrl** (string?): URL de la imagen del producto.
- **AvailableStock** (int): Stock disponible del producto.
- **Weight** (decimal): Peso del producto.
- **Dimensions** (string?): Dimensiones del producto.
- **Color** (string?): Color del producto.
- **PublicationDate** (DateTime): Fecha de publicación del producto.
- **Discount** (decimal): Descuento aplicado al producto.
- **SubCategory** (SubCategory?): Relación con la entidad SubCategory.
- **StockItems** (List<StockItem>?): Lista de items en stock de este producto.
- **Qualifications** (List<Qualification>?): Lista de calificaciones del producto.
- **Favorites** (List<Favorite>?): Lista de clientes que han marcado este producto como favorito.
- **CartItems** (List<CartItem>?): Lista de items en carritos de compras que incluyen este producto.
- **Questions** (List<Question>?): Lista de preguntas relacionadas con el producto.

### 13. Purchase
Almacena información sobre transacciones de compra realizadas por los clientes, incluyendo detalles de pago y estado de la compra. Facilita el seguimiento de las compras y proporciona datos valiosos para análisis de ventas y comportamiento del cliente. Además, ayuda en la gestión de inventarios y la planificación de reabastecimiento.

- **PurchaseId** (int): Clave primaria.
- **ClientId** (int): Clave foránea que referencia a la entidad Client.
- **AddressId** (int?): Clave foránea que referencia a la entidad Address (nullable para permitir compras sin dirección).
- **PurchaseDate** (DateTime): Fecha de la compra.
- **Total** (decimal): Total de la compra.
- **Client** (Client?): Relación con la entidad Client.
- **Address** (Address?): Relación con la entidad Address.
- **PaymentMethod** (PaymentMethod): Método de pago utilizado.
- **Status** (State): Estado de la compra.
- **PurchaseDetails** (List<PurchaseDetail>?): Lista de detalles de la compra.

### 14. PurchaseDetail
Proporciona información detallada sobre los productos incluidos en una compra específica, como cantidad, precio unitario y subtotal. Esto permite un seguimiento preciso de cada ítem comprado y su contribución al total de la compra. Facilita la contabilidad y la gestión de inventarios post-compra.

- **PurchaseDetailId** (int): Clave primaria.
- **PurchaseId** (int): Clave foránea que referencia a la entidad Purchase.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **Purchase** (Purchase?): Relación con la entidad Purchase.
- **Product** (Product?): Relación con la entidad Product.
- **UnitPrice** (decimal): Precio unitario del producto.
- **Amount** (int): Cantidad de productos comprados.
- **Subtotal** (decimal): Subtotal calculado como UnitPrice * Amount.

### 15. Qualification
Permite a los clientes calificar productos y proporcionar retroalimentación sobre su experiencia. Las calificaciones ayudan a otros clientes a tomar decisiones de compra informadas y proporcionan información valiosa a la empresa sobre la satisfacción del producto. Esto contribuye a la mejora continua de productos y servicios.

- **QualificationId** (int): Clave primaria.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **ClientId** (int): Clave foránea que referencia a la entidad Client.
- **Rating** (int): Calificación del producto (del 1 al 5).
- **Comment** (string?): Comentario del cliente.
- **Client** (Client?): Relación con la entidad Client.
- **Product** (Product?): Relación con la entidad Product.
- **DateQualification** (DateTime): Fecha de la calificación.

### 16. Question
Permite a los clientes realizar preguntas sobre productos específicos, fomentando la interacción y la resolución de dudas antes de realizar una compra. Las preguntas están vinculadas tanto a productos como a clientes, y pueden recibir respuestas de empleados. Esto mejora la satisfacción del cliente y puede influir positivamente en la decisión de compra.

- **Id** (int): Clave primaria.
- **ClientId** (int): Clave foránea que referencia a la entidad Client.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **Description** (string?): Descripción de la pregunta.
- **PublicationDate** (DateTime): Fecha de publicación.
- **Product** (Product?): Relación con la entidad Product.
- **Client** (Client?): Relación con la entidad Client.
- **Answers** (List<Answer>?): Lista de respuestas a la pregunta.

### 17. Rol
Define los roles dentro del sistema, gestionando permisos y accesos de los usuarios. Permite asignar roles específicos a los usuarios, como administradores, empleados o clientes, asegurando que cada uno tenga los privilegios necesarios para sus funciones. Esto facilita la administración y la seguridad del sistema.

- **Name** (string?): Nombre del rol.

### 18. StockItem
Gestiona el inventario de productos en ubicaciones específicas, incluyendo cantidad disponible y detalles de ubicación. Permite un seguimiento preciso de los niveles de stock en diferentes ubicaciones, asegurando que la empresa pueda responder rápidamente a la demanda. Esto ayuda a evitar la falta de stock y optimiza la gestión del inventario.

- **StockItemId** (int): Clave primaria.
- **LocationId** (int): Clave foránea que referencia a la entidad Location.
- **ProductId** (int): Clave foránea que referencia a la entidad Product.
- **Location** (Location?): Relación con la entidad Location.
- **Product** (Product?): Relación con la entidad Product.
- **Quantity** (int): Cantidad de productos en stock.

### 19. SubCategory
Especifica categorías más detalladas dentro de una categoría principal, permitiendo una organización más granular de productos. Esto facilita a los clientes encontrar productos específicos dentro de un amplio rango de categorías. Además, ayuda a la empresa a gestionar y promocionar productos de manera más eficiente.

- **SubCategoryId** (int): Clave primaria.
- **CategoryId** (int): Clave foránea que referencia a la entidad Category.
- **Name** (string?): Nombre de la subcategoría.
- **ImageUrl** (string?): URL de la imagen de la subcategoría.
- **Category** (Category?): Relación con la entidad Category.
- **Products** (List<Product>?): Lista de productos pertenecientes a esta subcategoría.

### 20. Supplier
Gestiona la información de los proveedores y sus productos suministrados. Incluye detalles de contacto y permite realizar órdenes de suministro, facilitando la gestión de relaciones con proveedores y el inventario de productos. Esto asegura un flujo constante de productos necesarios para las operaciones.

- **Cuit** (string?): CUIT del proveedor.
- **SupplierOrders** (List<SupplierOrder>?): Lista de órdenes del proveedor.

### 21. SupplierOrder
Almacena información sobre órdenes realizadas a proveedores para el suministro de productos, incluyendo detalles de la orden y estado. Facilita la gestión de inventarios y asegura que los productos necesarios estén disponibles en el momento adecuado. Permite un seguimiento preciso de las órdenes y su cumplimiento.

- **SupplierOrderId** (int): Clave primaria.
- **SupplierId** (int): Clave foránea que referencia a la entidad Supplier.
- **OrderDate** (DateTime): Fecha de la orden.
- **ReceptionDate** (DateTime): Fecha de recepción.
- **State** (State): Estado de la orden.
- **Supplier** (Supplier?): Relación con la entidad Supplier.
- **DetailsOrderSupplier** (List<DetailOrderSupplier>?): Lista de detalles de la orden del proveedor.

### 22. User
Almacena la información básica de los usuarios del sistema, permitiendo su identificación y gestión de roles (cliente o empleado). Los usuarios pueden tener múltiples direcciones y participar en diversas actividades dentro del sistema, como compras y calificaciones. Esto facilita una experiencia personalizada y segura para cada usuario.

- **Dni** (string?): DNI del usuario.
- **Cuil** (string?): CUIL del usuario.
- **Name** (string?): Nombre del usuario.
- **LastName** (string?): Apellido del usuario.
- **Phone** (string?): Teléfono del usuario.
- **Email** (string?): Correo electrónico del usuario.
- **DateAdded** (DateTime): Fecha en que el usuario fue agregado al sistema.
- **Addresses** (List<Address>?): Lista de direcciones del usuario.
- **FullName** (string?): Nombre completo del usuario en formato Apellido, Nombre.


## Tipos Enumerados

### 1. PaymentMethod
Enum para los métodos de pago.

- **Cash:** Pago en efectivo.
- **CreditCard:** Pago con tarjeta de crédito.
- **DebitCard:** Pago con tarjeta de débito.
- **BankTransfer:** Transferencia bancaria.
- **Paypal:** Pago con PayPal.
- **Modo:** Pago con Modo.
- **MercadoPago:** Pago con MercadoPago.

### 3. State
Enum para los estados de una compra o una orden de proveedor.

- **Pending:** Pendiente.
- **Processing:** En proceso.
- **Shipped:** Enviado.
- **Delivered:** Entregado.
- **Canceled:** Cancelado.
- **Paid:** Pagado.
- **Received:** Recibido.

## Relaciones entre Entidades
Proporciona una visión general de las relaciones entre las entidades en el proyecto WebKillaDeco.

- Un **User** puede tener múltiples **Addresses**.
- Un **Client** puede realizar múltiples **Purchases**.
- Cada **Purchase** está asociada a un **Address**.
- Cada **Purchase** tiene múltiples **PurchaseDetails**.
- Un **PurchaseDetail** está asociado a un **Product**.
- Un **Product** puede tener múltiples **Qualifications**.
- Un **Client** puede calificar múltiples **Products**.
- Un **Client** puede tener múltiples **Cart**.
- Un **Cart** puede contener múltiples **CartItem**s.
- Cada **CartItem** está asociado a un **Product**.
- Un **Client** puede tener múltiples **Favorites**.
- Un **Favorite** está asociado a un **Product**.
- Un **Client** puede hacer múltiples Questions sobre **productos**.
- Una **Question** puede tener múltiples **Answers**.
- Un **Employee** puede responder múltiples **Questions**.
- Un **Product** pertenece a una **SubCategory**.
- Una **SubCategory** pertenece a una **Category**.
- Una **Category** puede tener múltiples **SubCategories**.
- Un **Supplier** puede tener múltiples **SupplierOrders**.
- Un **SupplierOrder** tiene múltiples **DetailOrderSuppliers**.
- Un **DetailOrderSupplier** está asociado a un **Product**.
- Un **Location** tiene una **Address**.
- Un **Location** puede tener múltiples **StockItems**.
- Un **StockItem** está asociado a un **Product**.
- Un **Product** puede estar en múltiples **StockItems**.
- Un **Product** puede tener múltiples **Questions**.

Estas relaciones aseguran una estructura de datos coherente y permiten una gestión eficiente de la información en la plataforma WebKillaDeco.

## Convenciones de Nombres
Se explican las convenciones de nombres utilizadas en las entidades y sus propiedades en el proyecto WebKillaDeco.

- Las claves primarias tienen el sufijo **Id** (por ejemplo, **AddressId**, **PurchaseId**).
- Las claves foráneas tienen el sufijo **Id** y corresponden a la clave primaria de la entidad referenciada (por ejemplo, **UserId** en **Address**).
- Las propiedades que representan relaciones tienen el mismo nombre que la entidad relacionada, seguida de un signo de interrogación en caso de ser nullable (por ejemplo, **User** en **Address**).
- Los nombres de las propiedades utilizan notación camelCase para mantener consistencia y legibilidad en el código (por ejemplo, **publicationDate** en **Question**).
- Se utiliza la notación PascalCase para los nombres de las clases y las enumeraciones (por ejemplo, **Address**, **PurchaseMethod**).
- Se prefieren nombres descriptivos y significativos para las propiedades y las clases, lo que mejora la comprensión del código y la mantenibilidad del proyecto.

## Ejemplo de Código
Proporciona ejemplos de cómo se utilizan las entidades en el código.
public class Address
````
   public class Product
{
    public int ProductId { get; set; }
    public int SubCategoryId { get; set; }
    public int Sku { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal CurrentPrice { get; set; }
    public bool Active { get; set; }
    public string? ImageUrl { get; set; }
    public int AvailableStock { get; set; }
    public decimal Weight { get; set; }
    public string? Dimensions { get; set; }
    public string? Color { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Discount { get; set; }
    public SubCategory? SubCategories { get; set; }
    public List<StockItem>? StockItems { get; set; }
    public List<Qualification>? Qualifications { get; set; }
    public List<Favorite>? Favorites { get; set; }
    public List<CartItem>? CartItems { get; set; }
    public List<Question>? Questions { get; set; }
}
````
````
public class StockItem
{
    public int StockItemId { get; set; }
    public int LocationId { get; set; }
    public int ProductId { get; set; }
    public Location? Location { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}
````
## Notas Adicionales
- Se utiliza la notación de C# para definir las propiedades de las entidades.
- Las relaciones entre entidades se establecen mediante propiedades de navegación, las cuales reflejan la estructura del modelo de datos y facilitan la navegación entre las entidades relacionadas.
- Las convenciones de nombres buscan mantener un código claro y coherente, facilitando la comprensión y el mantenimiento del proyecto a largo plazo.
- Asegúrate de que todas las claves foráneas estén correctamente configuradas en el DbContext.
- Las migraciones deben actualizarse cada vez que se modifiquen las entidades.

<hr/>

## Caracteristicas y Funcionalidades ⌨️
Todas las entidades, deben tener implementado su correspondiente ABM, a menos que sea implicito el no tener que soportar alguna de estas acciones.

### Usuario
Los Clientes pueden auto registrarse.
La autoregistración desde el sitio, es exclusiva para los clientes. Por lo cual, se le asignará dicho rol.
Los empleados, deben ser agregados por otro empleado o administrador.
Al momento, del alta del empleado, se le definirá un username y password.
También se le asignará a estas cuentas el rol de Empleado.

### Cliente
Un cliente puede navegar los productos y sus descripciones sin iniciar sesión, de forma anonima.
Para agregar productos en cantidad al carrito, debe iniciar sesión primero.
El cliente, puede agregar diferentes productos en el carrito, y por cada producto modificar la cantidad que quiere. -- Esta acción, no implica validación en stock. -- El ciente, verá el subtotal, por cada producto/cantidad. -- También, verá el subtotal, del carrito.
El cliente, una vez que está satisfecho con su carrito, puede finalizar la compra y elejirá un lugar para retirar.
El cliente puede vaciar el carrito.
Puede actualizar datos de contacto, como el telefono, dirección, Obra Social. Pero no puede modificar su DNI, Nombre, Apellido, etc.

### Empleado
El empleado, puede listar las compras realizadas en el mes, en modo listado, ordenado de forma descendente por valor de compra.
Puede dar de alta otros empleados.
Puede crear productos, categorias, Sucursales, agregar productos al stock de cada sucursal.
Puede habilitar y/o deshabilitar productos.

### Producto y Categoria
No pueden eliminarse del sistema.
Solo los producto pueden dehabilitarse.

### Sucursal
Cada sucursal, tendrá su propio stock.
Y sus datos de locación y contacto.
Por el mercado tan volatil, las sucursales, pueden crearse y eliminarse en todo momento. -- Para poder eliminar una sucursal, la misma no tiene que tener productos en su stock.

### StockItem
Pueden crearse, pero nunca pueden eliminarse desde el sistema. Son dependeintes de la surcursal.
Puede modificarse la cantidad en todo momento que se dispone de dicho producto, en el stock.
Se eliminaran, junto con la sucrusal, si esta fuese eliminada.

### Carrito
El carrito se crea automaticamente con la creación de un cliente, en estado activo.
Solo puede haber un carrito activo por usuario en el sistema.
Un carrito que no está activo, no puede modificarse en ningún aspecto.
No se puede eliminar carritos.
El carrito, se desactiva al momento de realizarse una compra de manera automatica.
Al vaciar el carrito, se eliminan todos los CarritoItems y datos que sean necesarios.
El subtotal, es un dato calculado.

### CarritoItem
El valor unitario del carritoItem, debe actualizarse, al realizar cualquier modificación, según el precio que tenga vigente el producto.
El subtotal, debe ser una propiedad calculada, en base a la cantidad x el valor unitario.

### Compra
Al generarse la compra, el carrito que tiene asociado, pasa a estar en estado Inactivo.
Al finalizar la compra, se validará si hay disponibles en el stock de la locación que seleccionó el cliente. -- Si hay stock, disminuye el mismo, y crea la compra. -- Si no hay stock, verifica en otras locaciones, si hay stock. --- Si hay en alguna, propone las locaciones o indica que no hay en stock. --- Si seleccionó una nueva locación, finaliza la compra.
Al Finalizar la compra, se le muestra le da las gracias al cliente, se le dá el Id de compra y los datos de la Sucursal que eligió.
No se pueden eliminar las compras.

<hr />

## Aplicación General del Proyecto
El proyecto WebKillaDeco es una plataforma de comercio electrónico diseñada para facilitar la compra y venta de productos de decoración para el hogar. Su objetivo es ofrecer una experiencia de usuario optimizada tanto para clientes como para empleados y administradores. A continuación, se detallan los aspectos generales y objetivos del proyecto:

### 1. Gestión de Usuarios
- **Clientes:** Los usuarios pueden registrarse como clientes, permitiéndoles navegar por el catálogo de productos, agregar items a sus carritos, realizar compras, calificar productos y gestionar sus direcciones.
- **Empleados:** Los empleados tienen acceso a funcionalidades adicionales para gestionar inventarios, responder preguntas de los clientes y procesar órdenes.
- **Administradores:** Los administradores tienen permisos elevados para gestionar usuarios, productos, categorías y mantener la plataforma operativa y actualizada.

### 2. Catálogo de Productos
- **Organización:** Los productos están organizados en categorías y subcategorías, facilitando la navegación y búsqueda por parte de los clientes.
- **Detalle de Productos:** Cada producto contiene información detallada, incluyendo precio, descripción, imágenes, disponibilidad y calificaciones de otros usuarios, ayudando a los clientes a tomar decisiones informadas.

### 3. Carrito de Compras y Proceso de Pago
- **Carrito de Compras:** Los clientes pueden agregar productos a su carrito, revisar su selección y proceder al pago cuando estén listos.
- **Métodos de Pago:** Se soportan múltiples métodos de pago, incluyendo efectivo, tarjetas de crédito/débito, transferencias bancarias y servicios de pago en línea como Paypal y MercadoPago.
- **Descuentos y Cupones:** Los clientes pueden aplicar cupones de descuento a sus compras, incentivando las ventas y la lealtad del cliente.

### 4. Gestión de Pedidos
- **Seguimiento de Pedidos:** Los clientes pueden ver el estado de sus pedidos desde la realización hasta la entrega, manteniéndolos informados en todo momento.
- **Estados de Pedidos:** Los pedidos pueden estar en diferentes estados (pendiente, procesando, enviado, entregado, cancelado, pagado, recibido), facilitando la gestión y seguimiento tanto para clientes como para empleados.

### 5. Interacción Cliente-Empleado
- **Preguntas y Respuestas:** Los clientes pueden hacer preguntas sobre los productos y recibir respuestas de los empleados, mejorando la comunicación y la satisfacción del cliente.
- **Calificaciones y Comentarios:** Los clientes pueden calificar y comentar sobre productos comprados, proporcionando feedback valioso para otros compradores y para la empresa.

### 6. Gestión de Inventarios
- **Control de Stock:** Los empleados pueden gestionar el stock de productos en diferentes ubicaciones, asegurando que siempre haya disponibilidad de productos.
- **Órdenes a Proveedores:** La plataforma facilita la creación y gestión de órdenes a proveedores, asegurando un flujo constante de productos necesarios.

### 7. Experiencia de Usuario Personalizada
- **Favoritos y Listas de Deseos:** Los clientes pueden marcar productos como favoritos para acceder rápidamente a ellos en el futuro.
- **Historial de Compras:** Los clientes pueden revisar su historial de compras, facilitando la repetición de pedidos y la gestión de devoluciones.

### 8. Análisis y Reportes
- **Datos de Ventas:** Los administradores pueden acceder a reportes detallados de ventas, ayudando en la toma de decisiones estratégicas.
- **Comportamiento del Cliente:** El análisis del comportamiento del cliente permite personalizar ofertas y mejorar la experiencia de usuario.
WebKillaDeco está diseñado para ser una solución integral de comercio electrónico que combina facilidad de uso, funcionalidad robusta y una experiencia de usuario personalizada, facilitando tanto la compra de productos de decoración para el hogar como la gestión operativa de la plataforma.

## About
No description, website, or topics provided.
Resources
 Readme
 Activity
