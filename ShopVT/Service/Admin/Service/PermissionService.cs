using Common;
using Data.Repository.Interface;
using Model.Auth;
using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Admin.Service
{
    public class PermissionService : IPermissionService
    {
        private IPermissionRepository _rep;
        private ILogger _logger;

        public PermissionService(IPermissionRepository permissionRepository, ILogger logger)
        {
            _rep = permissionRepository;
            _logger = logger;
        }
        public  List<PermissionData> GetPermissionData(int userId)
        {
            try
            {
                return  _rep.GetPermissionData(userId).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { user = userId });
                return null;
            }
        }

        public  List<PermissionFunction> GetPermissionFunctions(int userId)
        {
            try
            {
                return  _rep.GetPermissionFunctions(userId).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { user = userId });
                return null;
            }
        }
    }
}
