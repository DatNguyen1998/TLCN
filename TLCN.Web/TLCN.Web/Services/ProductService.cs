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

    }
    public class ProductService: BaseService<Product, ProductViewModel>, IProductService
    {
        public ProductService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Product> _repository => _uow.ProductRepository;
    }
}
