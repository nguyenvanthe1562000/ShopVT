using Common;
using System;

namespace API.Dto.Admin.ServiceDtos
{
    public class FilterLogDto
    {
        public string FileName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int? LineNumber { get; set; }
        public LogType? Type { get; set; }
        public DateTime? LogTimeFrom { get; set; }
        public DateTime? LogTimeTo { get; set; }
        public string Message { get; set; }
    }
}
