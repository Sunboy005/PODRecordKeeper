using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class LoggerManager : ILoggerManager
    {
        private readonly string _logPath;
        public LoggerManager(string path)
        {
            _logPath = path;
        }
        public void LogError(string message)
        {
            if (File.Exists(_logPath))
            {
                File.AppendAllText(_logPath, $"{DateTime.Now.Date}{DateTime.Now.TimeOfDay} " + message + "\n");
            }
            else File.WriteAllText(_logPath, $"{DateTime.Now.Date}{DateTime.Now.TimeOfDay} " + message + "\n");
        }
    }
}
