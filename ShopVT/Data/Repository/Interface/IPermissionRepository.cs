using Model.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IPermissionRepository
    {
        public Task<List<PermissionFunction>> GetPermissionFunctions(int userId);
        public Task<List<PermissionData>> GetPermissionData(int userId);
    }
}
