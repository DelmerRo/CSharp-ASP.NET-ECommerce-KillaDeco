using WebKillaDeco.Models;
using System;

namespace WebKillaDeco.DataInMemory
{
    public class UserInMemory
    {
        public static List<User> GetUsers()

        {
            List<User> users = new()
            {
                 new User
                 {
                    Dni = "12345678",
                    Cuil = "20-12345678-9",
                    Name = "Cliente1",
                    LastName = "Doe",
                    Phone = "123-456-789",
                    Email = "john@example.com"
                 },

                 new User
                 {
                    Dni = "87654321",
                    Cuil = "20-87654321-9",
                    Name = "Cliente 2",
                    LastName = "Doe",
                    Phone = "987-654-321",
                    Email = "jane@example.com"
                 },

                 new User
                 {
                    Dni = "94807936",
                    Cuil = "20-94807936-9",
                    Name = "Cliente 3",
                    LastName = "Rodríguez",
                    Phone = "1122540454",
                    Email = "cliente3@client.com"
                 }
            };

            return users;
        }
    }
}
