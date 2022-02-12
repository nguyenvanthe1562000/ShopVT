using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.Command;

namespace Data.Command
{
    public interface  IDataEditorRepository
    {
        public Task<ResponseMessageDto> Add(DataEditorAddRequestModel model);
        public Task<ResponseMessageDto> Update(DataEditorUpdateRequestModel model);
    }
}
