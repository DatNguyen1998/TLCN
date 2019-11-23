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

    }
    public class BillDetailService: BaseService<DetailBill, BillDetailViewModel>, IBillDetailService
    {
        public BillDetailService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<DetailBill> _repository => _uow.DetailBillRepository;
    }
}
