using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class FileLogger : ILogger
    {
        private static string _exeDir = AppDomain.CurrentDomain.BaseDirectory;
        private string _logFilePath = Path.Combine(_exeDir, @"log\log.json");

        public void Log(LogType type, string message, StackFrame frame = null, Object logObject = null)
        {
            try
            {
                if (frame == null)
                {
                    var trace = new StackTrace(true);
                    frame = trace.GetFrame(trace.FrameCount - 1);
                }

                var fileName = Path.GetFileName(frame?.GetFileName() ?? "")?.Split('.')?.First();
                var className = frame.GetMethod().ReflectedType.Name;
                var methodName = frame.GetMethod().Name;
                var lineNumber = frame.GetFileLineNumber();

                var log = new Log()
                {
                    FileName = fileName,
                    ClassName = className,
                    MethodName = methodName,
                    LineNumber = lineNumber,
                    Time = DateTime.Now,
                    Type = type,
                    Message = message,
                    LogObject = logObject
                };

                WriteLog(log);
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        public List<Log> QueryLog(LogType? type = null, DateTime? logFrom = null, DateTime? logTo = null, string fileName = null, string className = null, string methodName = null, int? lineNumber = null)
        {
            try
            {
                var lstLogs = new List<Log>();
                var lines = File.ReadAllLines(_logFilePath);
                for (var i = lines.Length - 1; i >= 0; i--)
                {
                    try
                    {
                        var log = JsonConvert.DeserializeObject<Log>(lines[i]);

                        if (log == null)
                        {
                            continue;
                        }

                        if (type != null && log.Type != type)
                        {
                            continue;
                        }

                        if (logFrom != null && log.Time <= logFrom)
                        {
                            continue;
                        }

                        if (logTo != null && log.Time >= logTo)
                        {
                            continue;
                        }

                        if (!string.IsNullOrEmpty(fileName?.Trim()) && log.FileName != fileName)
                        {
                            continue;
                        }

                        if (!string.IsNullOrEmpty(className?.Trim()) && log.ClassName != className)
                        {
                            continue;
                        }

                        if (!string.IsNullOrEmpty(methodName?.Trim()) && log.MethodName != methodName)
                        {
                            continue;
                        }

                        if (lineNumber != null && log.LineNumber != lineNumber)
                        {
                            continue;
                        }

                        lstLogs.Add(log);
                    }
                    catch (Exception)
                    {
                        // do nothing
                    }
                }

                return lstLogs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ArchiveLogFile()
        {
            try
            {
                if (!File.Exists(_logFilePath))
                {
                    return true;
                }

                var archiveLogFilePath = Path.Combine(_exeDir, $@"log\log_{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}.json");
                File.Move(_logFilePath, archiveLogFilePath);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CheckExistAndCreateLogFolder()
        {
            try
            {
                var logFolderExist = Directory.Exists(Path.GetDirectoryName(_logFilePath));
                if (!logFolderExist)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_logFilePath));
                }
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        private void WriteLog(Log log)
        {
            CheckExistAndCreateLogFolder();

            var text = JsonConvert.SerializeObject(log);
            var parts = text.Split(',');
            if (parts.Length >= 7)
            {
                text = "";
                text += string.Format("{0,-35}, ", parts[0]);   // filename
                text += string.Format("{0,-40}, ", parts[1]);   // classname
                text += string.Format("{0,-40}, ", parts[2]);   // method name
                text += string.Format("{0,-17}, ", parts[3]);   // line number
                text += string.Format("{0,-8}, ", parts[4]);    // type
                text += string.Format("{0,-37}", parts[5]);     // time

                for (var i = 6; i < parts.Length; i++)
                {
                    text += $@", {parts[i]}";
                }
            }

            try
            {
                File.AppendAllTextAsync(_logFilePath, $"\n{text}");
            }
            catch (Exception)
            {
            }
        }
    }
}
