using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class SupplierInMemory
    {
        public static List<Supplier> GetSuppliers()

        {
            List<Supplier> suppliers = new()
            {
               new Supplier
                {
                    Dni = "12345678",
                    Cuil = "20-12345678-5",
                    Name = "Proveedor1",
                    LastName = "Apellido1",
                    Phone = "123456789",
                    Email = "proveedor1@example.com",
                    DateAdded = DateTime.Now,
                    Cuit = "123456789",
                },
                new Supplier
                {
                    Dni = "23456789",
                    Cuil = "20-23456789-4",
                    Name = "Proveedor2",
                    LastName = "Apellido2",
                    Phone = "987654321",
                    Email = "proveedor2@example.com",
                    DateAdded = DateTime.Now,
                    Cuit = "987654321",
                },
                new Supplier
                {
                    Dni = "34567890",
                    Cuil = "20-34567890-3",
                    Name = "Proveedor3",
                    LastName = "Apellido3",
                    Phone = "456789123",
                    Email = "proveedor3@example.com",
                    DateAdded = DateTime.Now,
                    Cuit = "456789123",
                }

            };

            return suppliers;
        }
    }
}
