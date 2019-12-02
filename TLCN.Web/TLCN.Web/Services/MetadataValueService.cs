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
        IEnumerable<MetadataValue> Find(SearchViewModel model, string includes = "");
    }
    public class MetadataValueService : BaseService<MetadataValue, MetadataValueViewModel>, IMetadataValueService
    {
        public MetadataValueService(IUnitOfWork uow) : base(uow)
        {

        }

        protected override IRepository<MetadataValue> _repository => _uow.MetadataValueRepository;

        public IEnumerable<MetadataValue> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<MetadataValue> result = null;
            if(model.Field != "")   
            {
                result = this.FindToEntity(x => x.Type.Code == model.Field);
            }
            if(model.TypeId != null && model.Name == "")
            {
                result =  this.FindToEntity(x => x.TypeId == model.TypeId, includes: includes);
            }
            if(model.Name != "" && model.TypeId == null)
            {
                result =  this.FindToEntity(x => x.Name == model.Name, includes: includes);
            }
            if(model.TypeId != null && model.Name != "")
            {
                result = this.FindToEntity(x => x.Name == model.Name && x.TypeId == model.TypeId, includes: includes);
            }
            if (model.ProvinceId != null)
            {
                result = this.FindToEntity(x => x.ParentId == model.ProvinceId, includes: includes);
            }
            return result;
        }
    }
}
