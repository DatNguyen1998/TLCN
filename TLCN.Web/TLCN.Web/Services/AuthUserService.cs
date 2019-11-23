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
    }
    public class AuthUserService : BaseService<AuthUser, AuthUserViewModel>, IAuthUserService
    {
        public AuthUserService(IUnitOfWork uow): base(uow)
        {

        }

        protected override IRepository<AuthUser> _repository => _uow.AuthUserRepository;

        public async Task<AuthUserViewModel> GetUserByUsernameAndPassword(string Username, string Password)
        {
            return await this.FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
        }
    }
}
