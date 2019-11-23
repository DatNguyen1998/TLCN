using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IReviewProductService: IBaseService<ReviewProduct, ReviewProductViewModel>
    {

    }
    public class ReviewProductService: BaseService<ReviewProduct, ReviewProductViewModel>, IReviewProductService
    {
        public ReviewProductService(IUnitOfWork uow) : base(uow)
        {

        }
        protected override IRepository<ReviewProduct> _repository => _uow.ReviewProductRepository;
    }
}
