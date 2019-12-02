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
        IEnumerable<Promotion> Find(SearchViewModel model, string includes = "");
    }
    public class PromotionService: BaseService<Promotion, PromotionViewModel>, IPromotionService
    {
        public PromotionService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Promotion> _repository => _uow.PromotionRepository;

        public IEnumerable<Promotion> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<Promotion> result = null;
            if (model.Name != "")
            {
                result = this.FindToEntity(x => x.Name == model.Name, includes: includes);
            }
            return result;
        }
    }
}
