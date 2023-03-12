using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Utilities
{
    public class Logger
    {
        public ILogger myLog;
        public Logger(string provider)
        {
            switch (provider)
            {
                case "File":
                    myLog = new LogFile();
                    break;
                case "DB":
                    myLog = new LogDB();
                    break;
                case "Console":
                    myLog = new ConsoleLog();
                    break;
                default:
                    myLog = new LogNone();
                    break;
            }
        }
    }
}
