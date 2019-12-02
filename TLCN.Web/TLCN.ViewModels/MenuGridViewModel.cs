using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class MenuGridViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
