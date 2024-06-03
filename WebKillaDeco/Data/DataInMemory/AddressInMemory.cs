using System.Collections.Generic;
using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public class AddressInMemory
    {
        public static List<Address> GetAddresses()
        {
            List<Address> addresses = new()
            {
   new Address
    {
        UserId = 1,
        Street = "Avenida de Mayo",
        Number = 123,
        Tower = "B",
        Floor = 2,
        Department = "B",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1084AAB",
        Country = "Argentina"
    },
    new Address
    {
        UserId = 2,
        Street = "Calle Florida",
        Number = 456,
        Tower = "3",
        Floor = 1,
        Department = "C",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1005AAS",
        Country = "Argentina"
    },
    /*new Address
    {
        UserId = 3,
        Street = "Avenida 9 de Julio",
        Number = 789,
        Tower = "1",
        Floor = 3,
        Department = "A",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1043AAB",
        Country = "Argentina"
    },
    new Address
    {
        UserId = 4,
        Street = "Calle Lavalle",
        Number = 101,
        Tower = "A",
        Floor = 4,
        Department = "D",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1047AAG",
        Country = "Argentina"
    },
    new Address
    {
        UserId = 5,
        Street = "Avenida Corrientes",
        Number = 202,
        Tower = "3",
        Floor = 5,
        Department = "E",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1043AAS",
        Country = "Argentina"
    },
    new Address
    {
        UserId = 6,
        Street = "Calle Reconquista",
        Number = 303,
        Tower = "2",
        Floor = 6,
        Department = "F",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1003ABH",
        Country = "Argentina"
    },
    new Address
    {
        UserId = 7,
        Street = "Avenida Belgrano",
        Number = 404,
        Tower = "1",
        Floor = 7,
        Department = "G",
        City = "Buenos Aires",
        Province = "Buenos Aires",
        PostalCode = "C1092AAQ",
        Country = "Argentina"
    }*/
            };

            return addresses;
        }
    }
}
