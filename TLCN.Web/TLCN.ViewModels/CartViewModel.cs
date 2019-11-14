using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Attributes;
using TLCN.Models;
namespace TLCN.ViewModels
{
    [Repository(Action = ActionType.All, Name = "CartViewModel", RepositoryType = typeof(Cart))]
    public class CartViewModel
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid AuthUserId { get; set; }   //khách hàng
        public string AuthUserName { get; set; }
        public string AuthUserCode { get; set; }
    }
}
