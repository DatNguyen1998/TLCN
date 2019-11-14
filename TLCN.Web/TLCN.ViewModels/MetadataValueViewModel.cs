using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Models;
using TLCN.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "MetadataValueViewModel", RepositoryType = typeof(MetadataValue))]
    public class MetadataValueViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
    }
}
