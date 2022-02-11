using API.Interfaces;
using Common.Helper;
using Model.Editor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Editor
{
    public class DataEditorRepository : IDisposable
    {
        private IDatabaseHelper _dbHelper;
        private ILogger _logger;

        public DataEditorRepository(IDatabaseHelper databaseHelper, ILogger logger)
        {
            _dbHelper = databaseHelper;
            _logger = logger;
        }

        public async Task<DataTable> AddAsync(DataEditorAddModel model)
        {
            try
            {
                var validateResult = model.Validate();
                if (!validateResult.IsSuccess)
                {
                    return null;
                }
                var data = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_DataEditor", "@userId",model.UserId, "@table", model.Table,
                    "@columnArray",model.ColumnArray, "@data",model.Data, "@isRequired",model.IsRequired, "@requiredColumnPrimeryKey", model.RequiredColumnPrimeryKey);
                if (!string.IsNullOrEmpty(data.message))
                {
                    throw new Exception(data.message);
                }
                return data.Item2;
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last(), new { DataExploreRequestModel = model });
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
        ~DataEditorRepository()
        {
            Dispose(false);

        }
    }
}
