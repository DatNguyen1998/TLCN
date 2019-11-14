using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "ProductViewModel", RepositoryType = typeof(Product))]
    public class ProductViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid? ProducerId { get; set; }   //Nhà sản xuất => lấy từ MetadataValue
        public string ProducerName { get; set; }
        public string ProducerCode { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public double Price { get; set; }  // giá 
        [StringLength(500)]
        public string Description { get; set; } // mô tả sản phẩm
        public bool IsSell { get; set; } //true : đang kinh doanh , false : Ngừng kinh doanh
        public Guid? Logo { get; set; } // hình ảnh sản phẩm
    }
}
