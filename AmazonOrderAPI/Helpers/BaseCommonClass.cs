using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Helpers
{
    public class BaseCommonClass
    {
        public ILoggerManager _logger;

        public BaseCommonClass(ILoggerManager logger)
        {
            _logger = logger;
        }
    }
}
