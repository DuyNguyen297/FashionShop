using FashionShop.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FashionShop.ViewModel
{
    public class OrderItem
    {
        public int Quantity { set; get; }
        public string ProductId { set; get; }
    }
}