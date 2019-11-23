using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Branch:AuditableEntity
    {
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

        public virtual MetadataValue Province { get; set; }
        public virtual MetadataValue District { get; set; }
        public virtual Branch Parent { get; set; }
    }
}
