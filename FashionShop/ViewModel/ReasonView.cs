using FashionShop.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FashionShop.ViewModel
{
    public class ReasonView
    {
        public string Id { get; set; }
        public string Reason { set; get; }
        public string RefuseReason { set; get; }
    }
}