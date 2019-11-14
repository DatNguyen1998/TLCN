using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "PromotionViewModel", RepositoryType = typeof(Promotion))]
    public class PromotionViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int DisCount { get; set; }   // số giảm giá
        public string Description { get; set; } // mô tả
        public Guid? BillId { get; set; }
        public string BillCode { get; set; }

    }
}
