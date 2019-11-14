using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "BranchViewModel", RepositoryType = typeof(Branch))]
    public class BranchViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        public Guid? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public bool IsPointOfSale { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentCode { get; set; }
    }
}
