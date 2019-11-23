using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface ICartService: IBaseService<Cart, CartViewModel>
    {

    }
    public class CartService: BaseService<Cart, CartViewModel>, ICartService
    {
        public CartService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Cart> _repository => _uow.CartRepository;
    }
}
