using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public Guid AuthUserId { get; set; }   //khách hàng
        public string AuthUserName { get; set; }
        public string AuthUserCode { get; set; }
    }
}
