using System.Collections.Generic;
using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class AddressInMemory
    {
        public static List<Address> GetAddresses()
        {
            List<Address> addresses = new()
            {
    new Address
    {
        AddressId = 1,
        UserId = 1,
        Street = "Avenida Corrientes",
        Number = 1234,
        Tower = "A",
        Floor = 5,
        Department = "B",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1043AAS",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 2,
        UserId = 1,
        Street = "Calle Florida",
        Number = 567,
        Tower = "A",
        Floor = 3,
        Department = "A",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1005AAN",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 3,
        UserId = 2,
        Street = "Avenida 9 de Julio",
        Number = 789,
        Tower = "B",
        Floor = 10,
        Department = "C",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1043AAO",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 4,
        UserId = 2,
        Street = "Calle San Martín",
        Number = 321,
        Tower = "1",
        Floor = 1,
        Department = "B",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1004AAF",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 5,
        UserId = 3,
        Street = "Avenida de Mayo",
        Number = 654,
        Tower = "C",
        Floor = 8,
        Department = "D",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1084AAC",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 6,
        UserId = 3,
        Street = "Calle Defensa",
        Number = 987,
        Tower = "C",
        Floor = 2,
        Department = "A",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1065AAK",
        Country = "Argentina"
    },
    new Address
    {
        AddressId = 7,
        UserId = 4,
        Street = "Avenida Santa Fe",
        Number = 159,
        Tower = "D",
        Floor = 7,
        Department = "F",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1059AAD",
        Country = "Argentina"
    }
            };

            return addresses;
        }
    }
}
