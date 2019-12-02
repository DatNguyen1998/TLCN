using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class AuthUserGetGridViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Guid? GenderId { get; set; }     //Giới tính
        public string GenderName { get; set; }     //Giới tính
        public string PhoneNumber { get; set; }//số điện thoại
        public string Address { get; set; }//địa chỉ
        public Guid? AvatarId { get; set; }//hình đại diện
        public string Username { get; set; }//tên đăng nhập
        public string Password { get; set; }//pass
        public string Role { get; set; }   //quyền
        public Guid? DistrictId { get; set; }   // huyện
        public string DistrictCode { get; set; }   // huyện
        public string DistrictName { get; set; }   // huyện
        public Guid? ProvinceId { get; set; }   //Tỉnh 
        public string ProvinceCode { get; set; }   //Tỉnh 
        public string ProvinceName { get; set; }   //Tỉnh 
        public bool IsActivated { get; set; }

    }
}
