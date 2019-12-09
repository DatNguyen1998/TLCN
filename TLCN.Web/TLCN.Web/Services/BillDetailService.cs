using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IBillDetailService : IBaseService<DetailBill, BillDetailViewModel> 
    {
        IEnumerable<DetailBill> GetCartForAuthUser(Guid authUserId, string includes = "");
        IEnumerable<DetailBill> Find(SearchViewModel model, string includes = "");
    }
    public class BillDetailService: BaseService<DetailBill, BillDetailViewModel>, IBillDetailService
    {
        public BillDetailService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<DetailBill> _repository => _uow.DetailBillRepository;

        public IEnumerable<DetailBill> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<DetailBill> result = null;
            if(model.BillId != null)
            {
                result = this.FindToEntity(x => x.BillId == model.BillId, includes: includes);
            }
            if(model.AuthUserId != null)
            {
                result = this.FindToEntity(x => x.AuthUserId == model.AuthUserId && x.IsActivated == false, includes: includes);
            }
            return result;
        }

        public IEnumerable<DetailBill> GetCartForAuthUser(Guid authUserId, string includes = "")
        {
            IEnumerable<DetailBill> result = null;
            result = this.FindToEntity(x => x.AuthUserId == authUserId && x.IsActivated == false, includes: includes);
            return result;
        }
    }
}
