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
        Task<IdentityModel> Login(string userName, string passWord, string IpAddress);
    }
}
