using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;

namespace TLCN.Models
{
    public class MetadataType:AuditableEntity
    {
        //kiểu/loại danh mục chung:loại Quận/huyện,loại phường xã,loại tỉnh/thành phố, loại xe, tên hãng xe, loại ....
        [StringLength(50)]
        public string Code { get; set; }//mã
        [StringLength(255)]
        public string Name { get; set; }//tên

        public virtual ICollection<MetadataValue> MetadataValues { get; set; }
    }
}
