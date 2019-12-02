using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class PromotionViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int DisCount { get; set; }   // số giảm giá
        public string Description { get; set; } // mô tả
        public Guid? BillId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }

    }
}
