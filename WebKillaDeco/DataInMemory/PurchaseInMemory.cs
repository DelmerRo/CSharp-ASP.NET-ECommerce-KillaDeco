using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class PurchaseInMemory
    {
        public static List<Purchase> GetPurchases()
        {
            List<Purchase> purchases = new()
            {
                new Purchase
                {
                    ClientId = 1,
                    AddressId = 1,
                    PurchaseDate = DateTime.Now.AddDays(-10),
                    Total = 199.99m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    Status = State.Pending
                },
                new Purchase
                {
                    ClientId = 2,
                    AddressId = 2,
                    PurchaseDate = DateTime.Now.AddDays(-8),
                    Total = 89.99m,
                    PaymentMethod = PaymentMethod.Paypal,
                    Status = State.Pending
                },
                new Purchase
                {
                    ClientId = 3,
                    AddressId = 3,
                    PurchaseDate = DateTime.Now.AddDays(-6),
                    Total = 59.99m,
                    PaymentMethod = PaymentMethod.DebitCard,
                    Status = State.Processing
                },
                new Purchase
                {
                    ClientId = 4,
                    AddressId = 4,
                    PurchaseDate = DateTime.Now.AddDays(-4),
                    Total = 129.99m,
                    PaymentMethod = PaymentMethod.Cash,
                    Status = State.Shipped
                },
                new Purchase
                {
                    ClientId = 5,
                    AddressId = 5,
                    PurchaseDate = DateTime.Now.AddDays(-2),
                    Total = 74.97m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    Status = State.Delivered
                },
                new Purchase
                {
                    ClientId = 6,
                    AddressId = 6,
                    PurchaseDate = DateTime.Now.AddDays(-1),
                    Total = 44.97m,
                    PaymentMethod = PaymentMethod.Paypal,
                    Status = State.Completed
                },
                new Purchase
                {
                    ClientId = 7,
                    AddressId = 7,
                    PurchaseDate = DateTime.Now.AddDays(-7),
                    Total = 119.97m,
                    PaymentMethod = PaymentMethod.DebitCard,
                    Status = State.Pending
                },
                new Purchase
                {
                    ClientId = 8,
                    AddressId = 8,
                    PurchaseDate = DateTime.Now.AddDays(-5),
                    Total = 199.95m,
                    PaymentMethod = PaymentMethod.Cash,
                    Status = State.Processing
                },
                new Purchase
                {
                    ClientId = 9,
                    AddressId = 9,
                    PurchaseDate = DateTime.Now.AddDays(-3),
                    Total = 49.99m,
                    PaymentMethod = PaymentMethod.CreditCard,
                    Status = State.Shipped
                },
                new Purchase
                {
                    ClientId = 10,
                    AddressId = 10,
                    PurchaseDate = DateTime.Now,
                    Total = 159.96m,
                    PaymentMethod = PaymentMethod.Paypal,
                    Status = State.Delivered
                }
            };

            return purchases;
        }
    }
}
