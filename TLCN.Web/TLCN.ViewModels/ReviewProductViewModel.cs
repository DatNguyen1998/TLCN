using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class ReviewProductViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public string Description { get; set; } // mô tả
        public int Rating { get; set; } // bình chọn sao cho sản phẩm
    }
}
