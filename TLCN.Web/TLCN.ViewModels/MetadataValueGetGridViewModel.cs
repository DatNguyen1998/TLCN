using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Models;

namespace TLCN.ViewModels
{
    public class MetadataValueGetGridViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public bool IsActivated { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
