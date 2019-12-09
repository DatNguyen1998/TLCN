using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class BillDetailForBillIdViewModel
    {
        public Guid ProductId { get; set; } // sản phẩm 
        public string ProductCode { get; set; } // sản phẩm 
        public Guid ProductName { get; set; } // sản phẩm 
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm
        public Guid AuthUserId { get; set; }
        public Guid AuthUserName { get; set; }
        public Guid AuthUserCode { get; set; }
    }
}
