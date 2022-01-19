using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.UserTypes;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class LoggerService
    {
        private ILog _log;

        public LoggerService(ILog log)
        {
            _log = log;
        }
        
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsFatalEnabled;

        public void Info(object LogMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(LogMessage);
            }
        }

        public void Debug(object LogMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(LogMessage);
            }
        }

        public void Warn(object LogMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(LogMessage);
            }
        }

        public void Fatal(object LogMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(LogMessage);
            }
        }

        public void Error(object LogMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(LogMessage);
            }
        }
    }
}
