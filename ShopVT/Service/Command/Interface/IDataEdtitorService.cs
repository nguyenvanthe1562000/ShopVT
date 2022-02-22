using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Command.Interface
{
    public interface IDataEdtitorService
    {
        public Task<ResponseMessageDto> Add<T>(T obj, string table, string ConditionString, int userId);
        public Task<ResponseMessageDto> Update<T>(T obj, string table, int rowId, string ConditionString, int userId);
        //public Task<ResponseMessageDto> Delete( string table, int rowId, string ConditionString, int userId);
        public Task<ResponseMessageDto> Delete( string table, int rowId,  int userId);
        public Task<ResponseMessageDto> Restore( string table, int rowId,  int userId);
    }
}
