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
                    PurchaseId = 4,
                    ProductId = 1,
                    UnitPrice = 49.99m,
                    Amount = 2
                },
                new PurchaseDetail
                {
                    PurchaseId = 5,
                    ProductId = 2,
                    UnitPrice = 29.99m,
                    Amount = 3
                },
                new PurchaseDetail
                {
                    PurchaseId = 6,
                    ProductId = 3,
                    UnitPrice = 39.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 7,
                    ProductId = 4,
                    UnitPrice = 89.99m,
                    Amount = 1
                },
                new PurchaseDetail
                {
                    PurchaseId = 8,
                    ProductId = 5,
                    UnitPrice = 14.99m,
                    Amount = 5
                },
                new PurchaseDetail
                {
                    PurchaseId = 4,
                    ProductId = 6,
                    UnitPrice = 19.99m,
                    Amount = 2
                },
                
            };

            return purchaseDetails;
        }
    }
}
