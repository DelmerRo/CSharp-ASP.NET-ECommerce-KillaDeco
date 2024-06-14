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
                    Cuil = "20123456789",
                    Name = "John",
                    LastName = "Doe",
                    Phone = "123-456-789",
                    Email = "client1@dominio.com.ar"
                 },

                 new Client
                 {
                    Dni = "87654321",
                    Cuil = "20876543219",
                    Name = "Jane",
                    LastName = "Doe",
                    Phone = "987-654-321",
                    Email = "cliente2@dominio.com.ar"
                 }
            };
                 return clients;

        }

    }
}

