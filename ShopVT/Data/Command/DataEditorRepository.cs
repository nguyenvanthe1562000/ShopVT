using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Helper;
using Model.Command;

namespace Data.Command
{
    public class DataEditorRepository : IDataEditorRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;

        public DataEditorRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        public async Task<ResponseMessageDto> Add(DataEditorAddRequestModel model)
        {


            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorAdd]", "@userId", model.UserId, "@table", model.TableName, "@columnArray", model.ColumnArray, "@data", model.ColumnValue, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {

                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Thêm dữ liệu thành công");

        }

        public async Task<ResponseMessageDto> Update(DataEditorUpdateRequestModel model)
        {
            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorUpdateOneRow]", "@userId", model.UserId, "@table", model.TableName, "@queryUpdateData", model.QueryUpdateData, "@rowId", model.RowId, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {

                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Update dữ liệu thành công");
        }
        public async Task<ResponseMessageDto> Delete(DataEditorDeleteRequestModel model)
        {
            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorDelete]", "@userId", model.UserId, "@table", model.TableName, "@rowId", model.RowId, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {

                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Xóa dữ liệu thành công");
        }
        public async Task<ResponseMessageDto> Restore(DataEditorRestoreRequestModel model)
        {
            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorRestore]", "@userId", model.UserId, "@table", model.TableName, "@rowId", model.RowId, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {

                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Khôi phục dữ liệu thành công");
        }
        public async Task<ResponseMessageDto> AddRange(DataEditorAddRangeRequestModel model)
        {

            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorAddMultiple]", "@userId", model.UserId, "@table", model.TableName, "@columnArray", model.ColumnArray, "@data", model.ColumnValue, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString, "@InsertChild", model.CommandInsertTableChild);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {

                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Thêm dữ liệu thành công");
        }
        public async Task<ResponseMessageDto> UpdateRange(DataEditorUpdateRangeRequestModel model)
        {

            var result = await _dbHelper.ExecuteScalarSProcedureAsync("[usp_sys_DataEditorUpdateMultiRow]", "@userId", model.UserId, "@table", model.TableName, "@queryUpdateData", model.QueryUpdateData, "@rowId", model.RowId, "@isRequired", model.Condition, "@requiredColumnPrimeryKey", model.ConditionString, "@JsonTableChild", model.JsonTableChild, "@QueryUpdate", model.QueryUpdate, "@QueryDelete", model.QueryDelete, "@QueryInsert", model.QueryInsert, "@TempTable", model.TempTable, "@QueryDropTempTable", model.QueryDropTempTable);
            if (!string.IsNullOrEmpty(result.msgError.ToString()))
            {
                return new ResponseMessageDto(MessageType.Error, result.msgError);
            }
            if (!(result.result is null))
            {
                return new ResponseMessageDto(MessageType.Warning, result.result.ToString());
            }
            return new ResponseMessageDto(MessageType.Success, "Update dữ liệu thành công");
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
