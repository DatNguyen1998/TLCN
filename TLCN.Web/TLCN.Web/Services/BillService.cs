using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IBillService: IBaseService<Bill, BillViewModel>
    {
        IEnumerable<Bill> Find(SearchViewModel model, string includes = "");
    }
    public class BillService: BaseService<Bill, BillViewModel>, IBillService
    {
        public BillService(IUnitOfWork uow) : base(uow)
        {

        }
        protected override IRepository<Bill> _repository => _uow.BillRepository;

        public IEnumerable<Bill> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<Bill> result = null;
            if (model.StatusBill != "")
            {
                result = this.FindToEntity(x => x.Status == model.StatusBill, includes: includes);
            }
            return result;
        }
    }
}
