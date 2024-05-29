using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public static class LocationInMemory
    {
        public static List<Location> GetLocations()
        {
            List<Location> locations = new()
            {
                new Location { AddressId = 1, Name = "Villa Urquiza", Phone = "1122540454", Email = "killaDeco@gmail.com", Address = new Address { AddressId = 1, Street = "Blanco Encalada 5126", City = "Capital Federal", Province = "Buenos Aires", PostalCode = "1431", Country = "Argentina" } },
                new Location { AddressId = 2, Name = "Location 2", Phone = "987654321", Email = "location2@example.com", Address = new Address { AddressId = 2, Street = "Street 2", City = "City 2", Province = "Province 2", PostalCode = "54321", Country = "Country 2" } },
            };

            return locations;
        }
    }
}
