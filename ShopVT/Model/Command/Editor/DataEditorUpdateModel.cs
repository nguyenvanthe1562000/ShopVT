using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Command.Editor
{
    class DataEditorUpdateModel:BaseCommandModel
    {
        public string ColumnArray { get; set; }
        public string Data { get; set; }
        public string IsRequired { get; set; }
        public string RequiredColumnPrimeryKey { get; set; }
        public override DtoValidationResult Validate()
        {
           
            if (string.IsNullOrEmpty(ColumnArray))
            {
                return new DtoValidationResult(false, "Dữ liệuphải  ColumnArray not null");
            }
            if (string.IsNullOrEmpty(Data))
            {
                return new DtoValidationResult(false, "Dữ liệu phải  Data not null");
            }
            if (string.IsNullOrEmpty(RequiredColumnPrimeryKey))
            {
                return new DtoValidationResult(false, "Dữ liệu phải  RequiredColumnPrimeryKey not null");
            }
            return new DtoValidationResult(true, "");
        }
    }
}
