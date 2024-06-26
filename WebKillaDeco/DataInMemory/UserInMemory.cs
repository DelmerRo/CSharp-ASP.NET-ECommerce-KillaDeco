﻿using WebKillaDeco.Models;
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
                    Cuil = "20123456789",
                    Name = "Juan",
                    LastName = "Perez",
                    Email = "admin1@killa.com.ar",
                    Phone = "123-456-789",
                    BirthDate = new DateTime(1990, 5, 15),
                    DateAdded = DateTime.Now,
                 },

                 new User
                 {
                    Dni = "87654321",
                    Cuil = "20876543219",
                    Name = "María",
                    LastName = "López",
                    Email = "admin@killa.com.ar",
                    Phone = "987-654-321",
                    BirthDate = new DateTime(1985, 9, 20),
                    DateAdded = DateTime.Now,
                 },
            };

            return users;
        }
    }
}
