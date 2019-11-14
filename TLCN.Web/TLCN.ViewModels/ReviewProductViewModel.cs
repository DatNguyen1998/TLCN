using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "ReviewProductViewModel", RepositoryType = typeof(ReviewProduct))]
    public class ReviewProductViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public string AuthUserName { get; set; }
        public string AuthUserCode { get; set; }
        public string Description { get; set; } // mô tả
        public int Rating { get; set; } // bình chọn sao cho sản phẩm
    }
}
