using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Command
{
     class BaseCommandModel
    {
        public virtual int? UserId { get; set; }
        public virtual string Table { get; set; }

        public virtual DtoValidationResult Validate()
        {
            if(!(UserId is null))
            {
                return new DtoValidationResult(false, "Dữ liệu UserId đầu vào không hợp lệ");
            }
            if (string.IsNullOrEmpty(Table))
            {
                return new DtoValidationResult(false, "Dữ liệu Table đầu vào không hợp lệ");
            }

            return new DtoValidationResult(true);
        }
    }
}
