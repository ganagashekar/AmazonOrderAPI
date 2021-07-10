using LoggerService;
using Microsoft.Extensions.Options;

namespace AmazonOrderAPI.Business.Common
{
    public class BaseCommonClass
    {
        public ILoggerManager _logger;
        public IOptions<AppSetting> setting;

        public string SellerId { set; get; }
        public string ClientId { set; get; }

        public BaseCommonClass(ILoggerManager logger, IOptions<AppSetting> _setting)
        {
            _logger = logger;
            setting = _setting;
            SellerId = _setting.Value.SellerId;
            ClientId = _setting.Value.ClientId;
        }
    }
}