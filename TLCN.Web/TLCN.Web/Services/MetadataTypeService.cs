using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IMetadataTypeService: IBaseService<MetadataType, MetadataTypeViewModel>
    {
        IEnumerable<MetadataTypeViewModel> filterByName(string name);
    }
    public class MetadataTypeService: BaseService<MetadataType, MetadataTypeViewModel>, IMetadataTypeService
    {
        public MetadataTypeService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<MetadataType> _repository => _uow.MetadataTypeRepository;

        public  IEnumerable<MetadataTypeViewModel> filterByName(string name)
        {
            return this.FindToViewModel(x => x.Name == name);
        }
    }
}
