using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "CartDetailViewModel", RepositoryType = typeof(CartDetail))]
    public class CartDetailViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid CartId { get; set; }   //giỏ hàng của khách 
        public string CartCode { get; set; }
        public Guid ProductId { get; set; }    // Sản phẩm
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Amount { get; set; } //số lượng
    }
}
