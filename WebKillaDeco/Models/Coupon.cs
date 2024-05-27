namespace WebKillaDeco.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; } // Puede ser porcentaje o valor fijo
        public DateTime ExpirationDate { get; set; }
        public bool Used { get; set; } = false;
    }
}
