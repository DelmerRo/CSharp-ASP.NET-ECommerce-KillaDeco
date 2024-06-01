using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class CartItemInMemory
    {
        public static List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new()
            {
                new CartItem
                {
                    CartId = 11,
                    ProductId = 1,
                    UnitPrice = 19.99m,
                    Amount = 2
                },
                new CartItem
                {
                    CartId = 11,
                    ProductId = 2,
                    UnitPrice = 29.99m,
                    Amount = 1
                },
                new CartItem
                {
                    CartId = 12,
                    ProductId = 3,
                    UnitPrice = 9.99m,
                    Amount = 3
                },
                new CartItem
                {
                    CartId = 12,
                    ProductId = 4,
                    UnitPrice = 14.99m,
                    Amount = 2
                },
                new CartItem
                {
                    CartId = 13,
                    ProductId = 5,
                    UnitPrice = 24.99m,
                    Amount = 1
                },
                new CartItem
                {
                    CartId = 13,
                    ProductId = 6,
                    UnitPrice = 34.99m,
                    Amount = 4
                },
               
            };

            return cartItems;
        }
    }
}

