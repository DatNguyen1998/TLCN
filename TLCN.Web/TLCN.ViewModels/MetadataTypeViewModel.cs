using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "MetadataTypeViewModel", RepositoryType = typeof(MetadataType))]
    public class MetadataTypeViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }//mã
        [StringLength(255)]
        public string Name { get; set; }//tên
    }
}
