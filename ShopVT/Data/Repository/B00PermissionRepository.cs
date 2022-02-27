using Common;
using Common.Helper;
using Data.Repository.Interface;
using Model.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private IDatabaseHelper _dbHelper;
        private ILogger _logger;

        public PermissionRepository(IDatabaseHelper databaseHelper, ILogger logger)
        {
            _dbHelper = databaseHelper;
            _logger = logger;
        }
        
        public async Task<List<PermissionData>> GetPermissionData(int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_GetPermissionData]", "@userId", userId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return null;
                }
                if ((result.Item2 is null))
                {
                    return null;
                }
                var permissions = await result.Item2.ConvertToAsync<PermissionData>();
                return permissions.ToList();
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { user = userId });
                return null;
            }
        }

        public async Task<List<PermissionFunction>> GetPermissionFunctions(int userId)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_GetPermissionFunction]", "@UserId", userId);
                if (!string.IsNullOrEmpty(result.message))
                {
                    return null;
                }
                if ((result.Item2 is null))
                {
                    return null;
                }
                 var permissions= await result.Item2.ConvertToAsync<PermissionFunction>();
                return permissions.ToList();
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { user = userId });
                return null;
            }
           
        }
    }
}
