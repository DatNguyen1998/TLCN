using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class ProductGridViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid? ProducerId { get; set; }   //Nhà sản xuất => lấy từ MetadataValue
        public string ProducerName { get; set; }
        public string ProducerCode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }  // giá 
        public string Description { get; set; } // mô tả sản phẩm
        public bool IsSell { get; set; } //true : đang kinh doanh , false : Ngừng kinh doanh
        public Guid? Logo { get; set; } // hình ảnh sản phẩm
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
    }
}
