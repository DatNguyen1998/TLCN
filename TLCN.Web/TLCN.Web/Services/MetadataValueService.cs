using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IMetadataValueService : IBaseService<MetadataValue, MetadataValueViewModel>
    {

    }
    public class MetadataValueService : BaseService<MetadataValue, MetadataValueViewModel>, IMetadataValueService
    {
        public MetadataValueService(IUnitOfWork uow) : base(uow)
        {

        }

        protected override IRepository<MetadataValue> _repository => _uow.MetadataValueRepository;
    }
}
