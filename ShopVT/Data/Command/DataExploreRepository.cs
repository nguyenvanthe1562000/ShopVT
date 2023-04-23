using Common;
using Common.Helper;
using Model.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command
{
    public class DataExploreRepository : IDataExploreRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        private ILogger _logger;


        public DataExploreRepository(IDatabaseHelper databaseHelper, ILogger logger)
        {
            _dbHelper = databaseHelper;
            _logger = logger;
        }
        public async Task<DataTable> GetData(DataExploreGetDataRequestModel model)
        {
            try
            {

              var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_GetData]", "@userId", model.UserId, "@table", model.TableName, "@PageSize", model.PageSize, "@PageIndex", model.PageIndex, "@Filter", model.Filter, "@TypeData", model.DataIsActive, "@Orderby", model.OrderBy, "@OrderDesc", model.OrderDesc);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                //if(!(result.Item2 is null))
                //{
                //    throw new Exception("kết quả null");
                //}    
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }
        public async Task<DataTable> GetDataByGroup(DataExploreGetDataByGroupRequestModel model)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_GetDataByGroup]", "@userId", model.UserId, "@table", model.TableName, "@PageSize", model.PageSize, "@PageIndex", model.PageIndex, "@Filter", model.Filter, "@ParentId", model.IdGroup, "@Orderby", model.OrderBy, "@OrderDesc", model.OrderDesc);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }
        public async Task<DataTable> GetDataByIdMultipleTable(DataExploreGetMultipleDataByIdRequestModel model)
        {
            try
            {

                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_GetDataByIdMultipleTalbe]", "@userId", model.UserId, "@table", model.TableName, "@RowId",   model.RowId, "@SubTable", model.SubTable);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }

        public async Task<DataTable> GetDataByIdOneTable(DataExploreGetDataByIdRequestModel model)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_GetDataById]", "@userId", model.UserId, "@table", model.TableName, "@RowId", model.RowId);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }

        public async Task<DataTable> GetDataLookUp(DataExploreLookupRequestModel model)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_LookUp]", "@userId", model.UserId, "@table", model.TableName, "@Top", model.RowsTotal, "@Filter", model.Filter, "@Orderby", model.OrderBy, "@OrderDesc", model.OrderDesc);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }

        public async Task<DataTable> GetDataLookUp2(DataExploreLookup2RequestModel model)
        {
            try
            {
                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_LookUp2]", "@_UserId", model.UserId, "@_LookupKey", model.LookupKey, "@_LookupValue", model.LookupValue, "@_LoadFilterExpr", model.LoadFilterExpr, "@_NumberRow", model.NumberRow, "@_SortExpr", model.SortExpr);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }
       

        public async Task<DataTable> GetGroup(DataExploreGetGroupRequestModel model)
        {
            try
            {

                var result = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("[usp_sys_GetGroup]", "@userId", model.UserId, "@table", model.TableName, "@ColumnCaption", model.ColumnCaption, "@Orderby", model.OrderBy, "@OrderDesc", model.OrderDesc);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = model });
                return null;
            }
        }
        public async Task<DataTable> ServerConstraintFunction(string function)
        {

            try
            {
                var result = await _dbHelper.ExecuteServerConstraintReturnDataTableAsync(function);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = function });
                return null;
            }
        }

        public async Task<DataSet> ServerConstraintStoreProcedureMultipleTable(string store)
        {

            try
            {
                var result = await _dbHelper.ExecuteServerConstraintReturnDataSetAsync(store);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = store });
                return null;
            }
        }

        public async Task<DataTable> ServerConstraintStoreProcedure(string store)
        {
            try
            {
                var result = await _dbHelper.ExecuteServerConstraintReturnDataTableAsync(store);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = store });
                return null;
            }
        }

        public async Task<DataSet> Report(string store)
        {
            try
            {
                var result = await _dbHelper.Report(store);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    throw new Exception(result.message);
                }
                return result.Item2;
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { DataExploreGetDataRequestModel = store });
                return null;
            }
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (_dbHelper != null)
                {
                    _dbHelper = null;

                    //GC.Collect();
                }
                disposed = true;
            }

        }

       

        ~DataExploreRepository()
        {
            Dispose(false);

        }
    }

}
