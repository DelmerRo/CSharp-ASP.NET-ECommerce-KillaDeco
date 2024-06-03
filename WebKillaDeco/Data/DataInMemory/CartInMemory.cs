using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public class CartInMemory
    {
        public static List<Cart> GetCarts()
        {
            List<Cart> carts = new()
            {
                new Cart
                {
                    ClientId = 3,
                    Active = true,
                },
                new Cart
                {
                    ClientId = 3,
                    Active = true,
                },
                new Cart
                {
                    ClientId = 4,
                    Active = false,
                }
            };

            return carts;
        }
    }
}
