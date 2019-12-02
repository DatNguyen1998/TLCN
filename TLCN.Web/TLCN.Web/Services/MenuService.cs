using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IMenuService: IBaseService<Menu, MenuViewModel>
    {
        IEnumerable<Menu> Find(SearchViewModel model, string includes = "");
    }
    public class MenuService : BaseService<Menu, MenuViewModel>, IMenuService
    {
        public MenuService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<Menu> _repository => _uow.MenuRepository;

        public IEnumerable<Menu> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<Menu> result = null;
            if (model.Name != "")
            {
                result = this.FindToEntity(x => x.Name == model.Name, includes: includes);
            }
            return result;
        }
    }
}
