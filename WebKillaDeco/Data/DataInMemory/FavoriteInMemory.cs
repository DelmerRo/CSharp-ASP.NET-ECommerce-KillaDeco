using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
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
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-8)
                },
                new Favorite
                {
                    ProductId = 4,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(-7)
                },
                new Favorite
                {
                    ProductId = 5,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-6)
                },
                new Favorite
                {
                    ProductId = 6,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(-5)
                },
                new Favorite
                {
                    ProductId = 7,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(-4)
                },
                new Favorite
                {
                    ProductId = 8,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-3)
                },
                new Favorite
                {
                    ProductId = 9,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-2)
                },
                new Favorite
                {
                    ProductId = 10,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(-1)
                },
                new Favorite
                {
                    ProductId = 11,
                    ClientId = 2,
                    DateFavorite = DateTime.Now
                },
                new Favorite
                {
                    ProductId = 12,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(1)
                },
                new Favorite
                {
                    ProductId = 13,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(2)
                },
                new Favorite
                {
                    ProductId = 14,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(3)
                },
                new Favorite
                {
                    ProductId = 15,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(4)
                },
                new Favorite
                {
                    ProductId = 16,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(5)
                },
                new Favorite
                {
                    ProductId = 17,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(6)
                },
                new Favorite
                {
                    ProductId = 18,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(7)
                },
                new Favorite
                {
                    ProductId = 19,
                    ClientId = 1,
                    DateFavorite = DateTime.Now.AddDays(8)
                },
                new Favorite
                {
                    ProductId = 20,
                    ClientId = 2,
                    DateFavorite = DateTime.Now.AddDays(9)
                }
            };

            return favorites;
        }
    }
}
