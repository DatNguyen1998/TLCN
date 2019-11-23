using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class MetadataValueViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public bool IsActivated { get; set; }
    }
}
