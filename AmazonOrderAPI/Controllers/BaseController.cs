using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Helpers;
using AmazonOrderAPI.Configuration;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmazonOrderAPI.Controllers
{
    public class BaseController : Controller
    {
        public ILoggerManager _logger;
        private readonly IOptions<AppSetting> _config;

        public BaseController(ILoggerManager logger, IOptions<AppSetting> settings)
        {
            _logger = logger;
            _config = settings;
            //_config.Value.SellerId = SellerId;
            //_config.Value.ClientId = ClientId;
        }

        private string _sellerId { get; set; }

        public string SellerId
        {
            get
            {
                return User != null ? User.Identity.GetSellerId() : "";
            }

            set { _sellerId = value; }
        }

        private string _clientId { get; set; }

        public string ClientId
        {
            get
            {
                return User != null ? User.Identity.GetClientId() : "";
            }

            set { _clientId = value; }
        }

        protected void SuccessNotification(string message, string title = "")
        {
            CreateNotification(NotificationHelpers.AlertType.Success, message, title);
        }

        protected void FailureNotification(string message, string title = "")
        {
            CreateNotification(NotificationHelpers.AlertType.Error, message, title);
        }

        protected void CreateNotification(NotificationHelpers.AlertType type, string message, string title = "")
        {
            var toast = new NotificationHelpers.Alert
            {
                Type = type,
                Message = message,
                Title = title
            };

            var alerts = new List<NotificationHelpers.Alert>();
            try
            {
                if (TempData.ContainsKey(NotificationHelpers.NotificationKey))
                {
                    alerts = JsonConvert.DeserializeObject<List<NotificationHelpers.Alert>>(TempData[NotificationHelpers.NotificationKey].ToString());
                    TempData.Remove(NotificationHelpers.NotificationKey);
                }

                alerts.Add(toast);

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                var alertJson = JsonConvert.SerializeObject(alerts, settings);

                TempData.Add(NotificationHelpers.NotificationKey, alertJson);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(""+ex.Message);
            }
            finally
            {
                toast = null;
                alerts = null;
            }
        }

        protected void GenerateNotifications()
        {
            if (!TempData.ContainsKey(NotificationHelpers.NotificationKey)) return;
            ViewBag.Notifications = TempData[NotificationHelpers.NotificationKey];
            TempData.Remove(NotificationHelpers.NotificationKey);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GenerateNotifications();

            base.OnActionExecuting(context);
        }

        public override ViewResult View(object model)
        {
            GenerateNotifications();

            return base.View(model);
        }
    }
}