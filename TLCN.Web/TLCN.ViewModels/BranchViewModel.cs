using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class BranchViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? ProvinceId { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public bool IsPointOfSale { get; set; }
        public Guid? ParentId { get; set; }
    }
}
