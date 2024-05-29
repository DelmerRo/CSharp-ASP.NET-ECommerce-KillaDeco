using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class PurchaseDetailInMemory
    {
        public static List<PurchaseDetail> GetPurchaseDetails()
        {
            List<PurchaseDetail> purchaseDetails = new()
            {
                new PurchaseDetail
                {
                    PurchaseId = 1,
                    ProductId = 1,
                    UnitPrice = 49.99m,
                    Amount = 2
                },
                new PurchaseDetail
                {
                    PurchaseId = 2,
                    ProductId = 2,
                    UnitPrice = 29.99m,
                    Amount = 3
                },
                new PurchaseDetail
                {
                    PurchaseId = 3,
                    ProductId = 3,
                    UnitPrice = 39.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 4,
                    ProductId = 4,
                    UnitPrice = 89.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 5,
                    ProductId = 5,
                    UnitPrice = 14.99m,
                    Amount = 5
                },
                new PurchaseDetail
                {
                    PurchaseId = 6,
                    ProductId = 6,
                    UnitPrice = 19.99m,
                    Amount = 2
                },
                new PurchaseDetail
                {
                    PurchaseId = 7,
                    ProductId = 7,
                    UnitPrice = 34.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 8,
                    ProductId = 8,
                    UnitPrice = 59.99m,
                    Amount = 3
                },
                new PurchaseDetail
                {
                    PurchaseId = 9,
                    ProductId = 9,
                    UnitPrice = 79.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 10,
                    ProductId = 10,
                    UnitPrice = 24.99m,
                    Amount = 4
                }
            };

            return purchaseDetails;
        }
    }
}
