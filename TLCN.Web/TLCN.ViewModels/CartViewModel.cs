using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public Guid AuthUserId { get; set; }   //khách hàng
        public Guid ProductId { get; set; }
        public double PriceTotal { get; set; }
        public int Amount { get; set; }
    }
}
