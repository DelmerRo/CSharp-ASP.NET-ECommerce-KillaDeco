using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class DetailOrderSupplierInMemory
    {
        public static List<DetailOrderSupplier> GetDetailOrderSuppliers()
        {
            List<DetailOrderSupplier> detailOrderSuppliers = new()
            {
                new DetailOrderSupplier
                {
                    SupplierOrderId = 1,
                    ProductId = 1,
                    Amount = 5,
                    UnitPrice = 10.99m
                },
                new DetailOrderSupplier
                {
                    SupplierOrderId = 2,
                    ProductId = 2,
                    Amount = 3,
                    UnitPrice = 7.50m
                },
                new DetailOrderSupplier
                {
                    SupplierOrderId = 3,
                    ProductId = 3,
                    Amount = 2,
                    UnitPrice = 15.25m
                },
                new DetailOrderSupplier
                {
                    SupplierOrderId = 4,
                    ProductId = 4,
                    Amount = 1,
                    UnitPrice = 25.99m
                },
                new DetailOrderSupplier
                {
                    SupplierOrderId = 5,
                    ProductId = 5,
                    Amount = 4,
                    UnitPrice = 9.75m
                }
            };

            return detailOrderSuppliers;
        }
    }
}
