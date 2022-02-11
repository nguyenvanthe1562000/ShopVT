using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DtoValidationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public DtoValidationResult(bool isSuccess, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}
