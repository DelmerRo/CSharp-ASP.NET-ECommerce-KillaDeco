using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public static class LocationInMemory
    {
        public static List<Location> GetLocations()
        {
            List<Location> locations = new()
            {
                new Location {
                    Name = "Times Square",
                    Phone = "098-765-4321",
                    Email = "contact@timessquare.com" },
                new Location {
                    Name = "Central Park",
                    Phone = "123-456-7890",
                    Email = "info@centralpark.com"},
            };

            return locations;
        }
    }
}
