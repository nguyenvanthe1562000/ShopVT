using Common;
using Model.ExtensionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin.Service.Interface
{
    public interface ILoginAdminService
    {
        Task<IdentityModel> Login(LoginRequest request);
        Task<IdentityClientModel> LoginClient(LoginRequest request);
    }
}
