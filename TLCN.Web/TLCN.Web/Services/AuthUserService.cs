using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLCN.Models;
using TLCN.ViewModels;
using TLCN.Web.DALs;

namespace TLCN.Web.Services
{
    public interface IAuthUserService : IBaseService<AuthUser, AuthUserViewModel>
    {
        Task<AuthUserViewModel> GetUserByUsernameAndPassword(string Username, string Password);
        IEnumerable<AuthUser> Find(SearchViewModel model, string includes = "");
    }
    public class AuthUserService : BaseService<AuthUser, AuthUserViewModel>, IAuthUserService
    {
        public AuthUserService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<AuthUser> _repository => _uow.AuthUserRepository;

        public IEnumerable<AuthUser> Find(SearchViewModel model, string includes = "")
        {
            IEnumerable<AuthUser> result = null;
            if (model.Code != "")
            {
                result = this.FindToEntity(x => x.Code == model.Code, includes: includes);
            }
            if (model.Name != "")
            {
                result = this.FindToEntity(x => x.Fullname == model.Name, includes: includes);
            }
            if (model.Id != null)
            {
                result = this.FindToEntity(x => x.Id == model.Id, includes: includes);
            }
            return result;
        }

        public async Task<AuthUserViewModel> GetUserByUsernameAndPassword(string Username, string Password)
        {
            return await this.FirstOrDefaultAsync(x => x.Username == Username && BCrypt.Net.BCrypt.Verify(Password, x.Password) == true);
        }
    }
}
