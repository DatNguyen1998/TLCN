using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Product: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid? ProducerId { get; set; }   //Nhà sản xuất => lấy từ MetadataValue
        [StringLength(255)]
        public string ProductTypeId { get; set; } // loại sản phẩm => lấy từ MetadataValue
        [StringLength(255)]
        public string Name { get; set; }
        public double Price { get; set; }  // giá 
        [StringLength(500)]
        public string Description { get; set; } // mô tả sản phẩm
        public bool IsSell { get; set; } //true : đang kinh doanh , false : Ngừng kinh doanh
        public Guid? LogoId { get; set; } // hình ảnh sản phẩm
        
        
        public virtual MetadataValue Producer { get; set; }
        public virtual MetadataValue ProductType { get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
