using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IPromotionService: IBaseService<Promotion, PromotionViewModel>
    {

    }
    public class PromotionService: BaseService<Promotion, PromotionViewModel>, IPromotionService
    {
        public PromotionService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Promotion> _repository => _uow.PromotionRepository;
    }
}
