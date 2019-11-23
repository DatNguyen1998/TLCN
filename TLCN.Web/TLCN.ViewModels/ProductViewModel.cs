using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
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
