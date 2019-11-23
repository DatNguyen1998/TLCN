using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IBranchService: IBaseService<Branch, BranchViewModel>
    {

    }
    public class BranchService : BaseService<Branch, BranchViewModel>, IBranchService
    {
        public BranchService(IUnitOfWork uow): base(uow)
        {

        }
        protected override IRepository<Branch> _repository => _uow.BranchRepository;
    }
}
