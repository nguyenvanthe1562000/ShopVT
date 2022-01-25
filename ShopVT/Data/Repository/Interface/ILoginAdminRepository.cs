using Common;
using Model.ExtensionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
     public interface ILoginAdminRepository
    {
        Task<IdentityModel> Login(LoginRequest loginRequest);
    }
}
