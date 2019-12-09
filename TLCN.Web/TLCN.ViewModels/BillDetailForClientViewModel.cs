using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class BillDetailForClientViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Amount { get; set; }
        public double PriceTotal { get; set; }
    }
}
