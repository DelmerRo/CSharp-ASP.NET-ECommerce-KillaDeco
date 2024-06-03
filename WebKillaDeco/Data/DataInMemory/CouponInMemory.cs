using WebKillaDeco.Models;

namespace WebKillaDeco.Data.DataInMemory
{
    public static class CouponInMemory
    {
        public static List<Coupon> GetCoupons()
        {
            List<Coupon> coupons = new()
            {
                new Coupon {  Code = "CODE1", Description = "Description 1", Discount = 10.0m, ExpirationDate = DateTime.Now.AddDays(30), Used = false },
                new Coupon {  Code = "CODE2", Description = "Description 2", Discount = 20.0m, ExpirationDate = DateTime.Now.AddDays(45), Used = false },
                new Coupon {  Code = "CODE3", Description = "Description 3", Discount = 15.0m, ExpirationDate = DateTime.Now.AddDays(60), Used = false },
                new Coupon {  Code = "CODE4", Description = "Description 4", Discount = 25.0m, ExpirationDate = DateTime.Now.AddDays(90), Used = false },
                new Coupon {  Code = "CODE5", Description = "Description 5", Discount = 30.0m, ExpirationDate = DateTime.Now.AddDays(120), Used = false }
            };

            return coupons;
        }
    }
}
