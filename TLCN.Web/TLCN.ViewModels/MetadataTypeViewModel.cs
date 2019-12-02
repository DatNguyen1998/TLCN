using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class MetadataTypeViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }//mã
        [StringLength(255)]
        public string Name { get; set; }//tên
        public bool IsActivated { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }

    }
}
