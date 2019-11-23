using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface ICartDetailService: IBaseService<CartDetail, CartDetailViewModel>
    {

    }
    public class CartDetailService: BaseService<CartDetail, CartDetailViewModel>, ICartDetailService
    {
        public CartDetailService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<CartDetail> _repository => _uow.CartDetailRepository;
    }
}
