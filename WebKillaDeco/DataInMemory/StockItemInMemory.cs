using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class StockItemInMemory
    {
        public static List<StockItem> GetStockItems()
        {
            List<StockItem> stockItems = new()
            {
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 1,
                    Quantity = 100
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 2,
                    Quantity = 50
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 3,
                    Quantity = 30
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 4,
                    Quantity = 20
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 5,
                    Quantity = 40
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 6,
                    Quantity = 60
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 7,
                    Quantity = 25
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 8,
                    Quantity = 35
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 9,
                    Quantity = 45
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 10,
                    Quantity = 55
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 11,
                    Quantity = 65
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 12,
                    Quantity = 75
                },
                new StockItem
                {
                    LocationId =1,
                    ProductId = 13,
                    Quantity = 85
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 14,
                    Quantity = 95
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 15,
                    Quantity = 105
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 16,
                    Quantity = 115
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 17,
                    Quantity = 125
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 18,
                    Quantity = 135
                },
                new StockItem
                {
                    LocationId = 1,
                    ProductId = 19,
                    Quantity = 145
                },
                new StockItem
                {
                    LocationId = 2,
                    ProductId = 20,
                    Quantity = 155
                }
            };

            return stockItems;
        }
    }
}
