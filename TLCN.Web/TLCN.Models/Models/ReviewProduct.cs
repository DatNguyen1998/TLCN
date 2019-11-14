using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;

namespace TLCN.Models
{
    public class ReviewProduct: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public string Description { get; set; } // mô tả
        public int Rating { get; set; } // bình chọn sao cho sản phẩm

        public virtual Product Product { get; set; }
        public virtual AuthUser AuthUser { get; set; }
    }
}
