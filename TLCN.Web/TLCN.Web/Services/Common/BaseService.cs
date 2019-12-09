using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public class BaseService<TEntity, TViewModel> : Profile, IBaseService<TEntity, TViewModel> 
        where TEntity : class
        where TViewModel : class
    {
        protected readonly IUnitOfWork _uow;
        protected virtual IRepository<TEntity> _repository { get; }
        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateAsync(TViewModel viewModel)
        {
            var entity = ViewModelToEntity(viewModel);
            _repository.Add(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if(entity == null)
            {
                throw new Exception("Not Found Entity Object With Id: " + id);
            }
            _repository.Delete(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<TViewModel> FindByIdAsync(object id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if(entity == null)
            {
                throw new Exception("Not Found Entity Object With Id: " + id);
            }
            return EntityToViewModel(entity);
        }

        public  IEnumerable<TEntity> GetAll(string includes = "")
        {
            return _repository.Get(includes: includes);
        }



        public async Task<TViewModel> UpdateAsync(TViewModel viewModel, object id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if(entity == null)
            {
                return null;
            }
            Mapper.Map<TViewModel, TEntity>(viewModel, entity);
            _repository.Update(entity);
            await _uow.SaveChangesAsync();
            return EntityToViewModel(entity);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            await _uow.SaveChangesAsync();
            return null;
        }

        public async Task<TViewModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return EntityToViewModel(await _repository.GetFirstOrDefaultAsync(filter, includes));
        }


        private IEnumerable<TViewModel> EntityToViewModel(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TViewModel>>(entities);
        }


        protected TEntity ViewModelToEntity(TViewModel viewModel)
        {
            return Mapper.Map<TEntity>(viewModel);
        }

        protected TViewModel EntityToViewModel(TEntity entity)
        {
            return Mapper.Map<TViewModel>(entity);
        }

        public IEnumerable<TEntity> FindToEntity(Expression<Func<TEntity, bool>> filter = null, string includes = "")
        {
            return _repository.Get(filter, includes: includes);
        }

        public IEnumerable<TViewModel> FindToViewModel(Expression<Func<TEntity, bool>> filter = null, string includes = "")
        {
            return EntityToViewModel(_repository.Get(filter,includes: includes));
        }

        
    }
}
