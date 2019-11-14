using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Models;
using TLCN.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "AuthUserViewModel", RepositoryType =typeof(AuthUser))]
    public class AuthUserViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Fullname { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Guid? GenderId { get; set; }     //Giới tính
        public string GenderName { get; set; }
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
        public string DistrictName { get; set; }
        public Guid? ProvinceId { get; set; }   //Tỉnh 
        public string ProvinceName { get; set; }
    }
}
