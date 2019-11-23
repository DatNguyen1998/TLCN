using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class AuthUser: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Fullname { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Guid? GenderId { get; set; }     //Giới tính
        [StringLength(255)]
        public string PhoneNumber { get; set; }//số điện thoại
        [StringLength(255)]
        public string Address { get; set; }//địa chỉ
        public Guid? AvatarId { get; set; }//hình đại diện
        [StringLength(50)]
        public string Username { get; set; }//tên đăng nhập
        [StringLength(255)]
        public string Password { get; set; }//pass
        public int Role { get; set; }   //quyền
        public Guid? DistrictId { get; set; }   // huyện
        public Guid? ProvinceId { get; set; }   //Tỉnh 

        public virtual MetadataValue Gender { get; set; }
        public virtual MetadataValue Province { get; set; }
        public virtual MetadataValue District { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }
    }
}
