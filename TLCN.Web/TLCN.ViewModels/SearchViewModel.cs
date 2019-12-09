using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class SearchViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? TypeId { get; set; }
        public string Field { get; set; }
        public Guid? ProvinceId { get; set; }
        public Guid? MenuId { get; set; }
        public Guid? ProducerId { get; set; }
        public Guid? AuthUserId { get; set; }
        public string PromotionCode { get; set; }
        public double Total { get; set; }
        public Guid? BillId { get; set; }
        public string StatusBill { get; set; }
    }
}
