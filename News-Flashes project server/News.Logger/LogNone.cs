using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Utilities
{
    public class LogNone : ILogger
    {
        public void Init() { }

        public void LogCheckHoseKeeping() { }

        public void LogError(string msg) { }

        public void LogEvent(string msg) { }

        public void LogException(string msg, Exception exce){}
    }
}
