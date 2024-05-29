using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class FavoriteInMemory
    {
        public static List<Favorite> GetFavorites()
        {
            List<Favorite> favorites = new()
            {
                new Favorite
                {
                    ProductId = 1,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-10)
                },
                new Favorite
                {
                    ProductId = 2,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(-9)
                },
                new Favorite
                {
                    ProductId = 3,
                    ClientId = 3,
                    DateFavorite = DateTime.Now.AddDays(-8)
                },
                new Favorite
                {
                    ProductId = 4,
                    ClientId = 4,
                    DateFavorite = DateTime.Now.AddDays(-7)
                },
                new Favorite
                {
                    ProductId = 5,
                    ClientId = 5,
                    DateFavorite = DateTime.Now.AddDays(-6)
                },
                new Favorite
                {
                    ProductId = 6,
                    ClientId = 6,
                    DateFavorite = DateTime.Now.AddDays(-5)
                },
                new Favorite
                {
                    ProductId = 7,
                    ClientId = 7,
                    DateFavorite = DateTime.Now.AddDays(-4)
                },
                new Favorite
                {
                    ProductId = 8,
                    ClientId = 8,
                    DateFavorite = DateTime.Now.AddDays(-3)
                },
                new Favorite
                {
                    ProductId = 9,
                    ClientId = 9,
                    DateFavorite = DateTime.Now.AddDays(-2)
                },
                new Favorite
                {
                    ProductId = 10,
                    ClientId = 10,
                    DateFavorite = DateTime.Now.AddDays(-1)
                },
                new Favorite
                {
                    ProductId = 11,
                    ClientId = 11,
                    DateFavorite = DateTime.Now
                },
                new Favorite
                {
                    ProductId = 12,
                    ClientId = 12,
                    DateFavorite = DateTime.Now.AddDays(1)
                },
                new Favorite
                {
                    ProductId = 13,
                    ClientId = 13,
                    DateFavorite = DateTime.Now.AddDays(2)
                },
                new Favorite
                {
                    ProductId = 14,
                    ClientId = 14,
                    DateFavorite = DateTime.Now.AddDays(3)
                },
                new Favorite
                {
                    ProductId = 15,
                    ClientId = 15,
                    DateFavorite = DateTime.Now.AddDays(4)
                },
                new Favorite
                {
                    ProductId = 16,
                    ClientId = 16,
                    DateFavorite = DateTime.Now.AddDays(5)
                },
                new Favorite
                {
                    ProductId = 17,
                    ClientId = 17,
                    DateFavorite = DateTime.Now.AddDays(6)
                },
                new Favorite
                {
                    ProductId = 18,
                    ClientId = 18,
                    DateFavorite = DateTime.Now.AddDays(7)
                },
                new Favorite
                {
                    ProductId = 19,
                    ClientId = 19,
                    DateFavorite = DateTime.Now.AddDays(8)
                },
                new Favorite
                {
                    ProductId = 20,
                    ClientId = 20,
                    DateFavorite = DateTime.Now.AddDays(9)
                }
            };

            return favorites;
        }
    }
}
