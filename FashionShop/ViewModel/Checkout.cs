using System.ComponentModel.DataAnnotations;

namespace FashionShop.ViewModel
{
    public class Checkout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string PayOption { get; set; }
        public decimal? Discount { get; set; } = 0;
    }
}
