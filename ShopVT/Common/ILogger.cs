using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ILogger
    {
        // general
        public void Log(LogType type, string message, StackFrame frame = null, Object logObject = null);

        public List<Log> QueryLog(LogType? type = null, DateTime? logFrom = null, DateTime? logTo = null, string fileName = null, string className = null, string methodName = null, int? lineNumber = null);

        public bool ArchiveLogFile();
    }

    public class Log
    {
        public string FileName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int LineNumber { get; set; }
        public LogType Type { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public object LogObject { get; set; }
    }

    public enum LogType
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}
