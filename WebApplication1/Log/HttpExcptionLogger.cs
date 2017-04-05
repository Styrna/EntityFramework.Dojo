using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace WebApplication1.Log
{
    public class HttpExcptionLogger : ExceptionLogger
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error(context.ExceptionContext.Exception.ToString());
        }
    }
    
}