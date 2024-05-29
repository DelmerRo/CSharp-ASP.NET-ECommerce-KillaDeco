using System.Collections.Generic;
using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class AddressInMemory
    {
        public static List<Address> GetAddress()
        {
            List<Address> addresses = new()
            {
                new Address
                {
                    UserId = 1,
                    Street = "Avenida Corrientes 123",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1010",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 1,
                    Street = "Avenida de Mayo 456",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1006",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 2,
                    Street = "Avenida 9 de Julio 789",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1043",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 2,
                    Street = "Calle Florida 321",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1005",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 3,
                    Street = "Calle Lavalle 987",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1049",
                    Country = "Argentina"
                },
                  new Address
                {
                    UserId = 3,
                    Street = "Calle Sarmiento 234",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1037",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 4,
                    Street = "Avenida Santa Fe 567",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1003",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 4,
                    Street = "Avenida Libertador 890",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1014",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 5,
                    Street = "Calle Uruguay 432",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1016",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 5,
                    Street = "Avenida Callao 876",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1002",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 1,
                    Street = "Calle Reconquista 789",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1029",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 5,
                    Street = "Calle Paraguay 345",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1001",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 6,
                    Street = "Avenida Rivadavia 901",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1008",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 6,
                    Street = "Calle Esmeralda 567",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1018",
                    Country = "Argentina"
                },
                new Address
                {
                    UserId = 1,
                    Street = "Avenida Belgrano 432",
                    City = "Buenos Aires",
                    Province = "Buenos Aires",
                    PostalCode = "1012",
                    Country = "Argentina"
                }


            };

            return addresses;
        }
    }
}
