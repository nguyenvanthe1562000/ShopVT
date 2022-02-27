using Model.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service.Interface
{
    public interface IPermissionService
    {
        public List<PermissionFunction> GetPermissionFunctions(int userId);
        public List<PermissionData> GetPermissionData(int userId);
    }
}
