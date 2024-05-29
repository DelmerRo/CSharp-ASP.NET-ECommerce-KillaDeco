using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class ClientInMemory
    {
        public static List<Client> GetClients()
        {
            List<Client> clients = new()
            {
                new Client
                 {
                    Dni = "12345678",
                    Cuil = "20-12345678-9",
                    Name = "John",
                    LastName = "Doe",
                    Phone = "123-456-789",
                    Email = "john@example.com"
                 },

                 new Client
                 {
                    Dni = "87654321",
                    Cuil = "20-87654321-9",
                    Name = "Jane",
                    LastName = "Doe",
                    Phone = "987-654-321",
                    Email = "jane@example.com"
                 }
            };
                 return clients;

        }

    }
}

