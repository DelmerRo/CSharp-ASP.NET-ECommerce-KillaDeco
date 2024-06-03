using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public class PurchaseInMemory
    {
        public static List<Purchase> GetPurchases()
        {
            List<Purchase> purchases = new()
            {
                new Purchase
                {
                    ClientId = 3,
                    AddressId = 1,
                    PurchaseDate = DateTime.Now.AddDays(-10),
                    Total = 199.99m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    Status = State.Pending
                },
                new Purchase
                {
                    ClientId = 3,
                    AddressId = 2,
                    PurchaseDate = DateTime.Now.AddDays(-8),
                    Total = 89.99m,
                    PaymentMethod = PaymentMethod.Paypal,
                    Status = State.Pending
                },
                new Purchase
                {
                    ClientId = 3,
                    AddressId = 1,
                    PurchaseDate = DateTime.Now.AddDays(-6),
                    Total = 59.99m,
                    PaymentMethod = PaymentMethod.DebitCard,
                    Status = State.Processing
                },
                new Purchase
                {
                    ClientId = 4,
                    AddressId = 1,
                    PurchaseDate = DateTime.Now.AddDays(-4),
                    Total = 129.99m,
                    PaymentMethod = PaymentMethod.Cash,
                    Status = State.Shipped
                },
                new Purchase
                {
                    ClientId = 4,
                    AddressId = 1,
                    PurchaseDate = DateTime.Now.AddDays(-2),
                    Total = 74.97m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    Status = State.Delivered
                },

            };

            return purchases;
        }
    }
}
