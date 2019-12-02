using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IProductService : IBaseService<Product, ProductViewModel>
    {
        IEnumerable<Product> Find(SearchViewModel model, string includes = "");
    }
    public class ProductService: BaseService<Product, ProductViewModel>, IProductService
    {
        public ProductService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Product> _repository => _uow.ProductRepository;

        public IEnumerable<Product> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<Product> result = null;
            if (model.Name != "" && model.ProducerId == null)
            {
                result = this.FindToEntity(x => x.Name == model.Name, includes: includes);
            }
            if (model.Name == "" && model.ProducerId != null)
            {
                result = this.FindToEntity(x => x.ProducerId == model.ProducerId, includes: includes);
            }
            if (model.Name != "" && model.ProducerId != null)
            {
                result = this.FindToEntity(x => x.ProducerId == model.ProducerId && x.Name == model.Name, includes: includes);
            }
            if (model.MenuId != null)
            {
                result = this.FindToEntity(x => x.MenuId == model.MenuId, includes: includes);
            }
            return result;
        }
    }
}
