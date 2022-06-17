using Common;
using Data.Repository.Interface;
using Model.ExtensionModel;
using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.Service
{
    public class LoginAdminService : ILoginAdminService
    {
        private ILoginAdminRepository _rep;

        public LoginAdminService(ILoginAdminRepository rep)
        {
            _rep = rep;
        }
        public async Task<IdentityModel> Login(LoginRequest request)
        {
            return await _rep.Login(request);
        }

        public async Task<IdentityClientModel> LoginClient(LoginRequest request)
        {
            return await _rep.LoginClient(request);
        }
    }
}
