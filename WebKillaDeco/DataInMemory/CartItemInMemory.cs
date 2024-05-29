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
                    CartId = 1,
                    ProductId = 1,
                    UnitPrice = 19.99m,
                    Amount = 2
                },
                new CartItem
                {
                    CartId = 1,
                    ProductId = 2,
                    UnitPrice = 29.99m,
                    Amount = 1
                },
                new CartItem
                {
                    CartId = 2,
                    ProductId = 3,
                    UnitPrice = 9.99m,
                    Amount = 3
                },
                new CartItem
                {
                    CartId = 2,
                    ProductId = 4,
                    UnitPrice = 14.99m,
                    Amount = 2
                },
                new CartItem
                {
                    CartId = 3,
                    ProductId = 5,
                    UnitPrice = 24.99m,
                    Amount = 1
                },
                new CartItem
                {
                    CartId = 3,
                    ProductId = 6,
                    UnitPrice = 34.99m,
                    Amount = 4
                },
                new CartItem
                {
                    CartId = 4,
                    ProductId = 7,
                    UnitPrice = 49.99m,
                    Amount = 2
                },
                new CartItem
                {
                    CartId = 4,
                    ProductId = 8,
                    UnitPrice = 19.99m,
                    Amount = 5
                },
                new CartItem
                {
                    CartId = 5,
                    ProductId = 9,
                    UnitPrice = 9.99m,
                    Amount = 6
                },
                new CartItem
                {
                    CartId = 5,
                    ProductId = 10,
                    UnitPrice = 29.99m,
                    Amount = 3
                }
            };

            return cartItems;
        }
    }
}

