using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class CartInMemory
    {
        public static List<Cart> GetCarts()
        {
            List<Cart> carts = new()
            {
                new Cart
                {
                    ClientId = 1,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 1, CartId = 1, ProductId = 1, UnitPrice = 19.99m, Amount = 2 },
                        new CartItem { CartItemId = 2, CartId = 1, ProductId = 2, UnitPrice = 29.99m, Amount = 1 }
                    }
                },
                new Cart
                {
                    ClientId = 2,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 3, CartId = 2, ProductId = 3, UnitPrice = 9.99m, Amount = 3 },
                        new CartItem { CartItemId = 4, CartId = 2, ProductId = 4, UnitPrice = 14.99m, Amount = 2 }
                    }
                },
                new Cart
                {
                    ClientId = 3,
                    Active = false,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 5, CartId = 3, ProductId = 5, UnitPrice = 24.99m, Amount = 1 }
                    }
                },
                new Cart
                {
                    ClientId = 4,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 6, CartId = 4, ProductId = 6, UnitPrice = 34.99m, Amount = 4 }
                    }
                },
                new Cart
                {
                    ClientId = 5,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 7, CartId = 5, ProductId = 7, UnitPrice = 49.99m, Amount = 2 },
                        new CartItem { CartItemId = 8, CartId = 5, ProductId = 8, UnitPrice = 19.99m, Amount = 5 }
                    }
                },
                new Cart
                {
                    ClientId = 6,
                    Active = false,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 9, CartId = 6, ProductId = 9, UnitPrice = 9.99m, Amount = 6 }
                    }
                },
                new Cart
                {
                    ClientId = 7,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 10, CartId = 7, ProductId = 10, UnitPrice = 29.99m, Amount = 3 }
                    }
                },
                new Cart
                {
                    ClientId = 8,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 11, CartId = 8, ProductId = 11, UnitPrice = 15.99m, Amount = 2 }
                    }
                },
                new Cart
                {
                    ClientId = 9,
                    Active = false,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 12, CartId = 9, ProductId = 12, UnitPrice = 12.99m, Amount = 1 }
                    }
                },
                new Cart
                {
                    ClientId = 10,
                    Active = true,
                    CartItems = new List<CartItem>
                    {
                        new CartItem { CartItemId = 13, CartId = 10, ProductId = 13, UnitPrice = 22.99m, Amount = 3 }
                    }
                }
            };

            return carts;
        }
    }
}
