using AmazonOrderExtentions.CoreExtentions;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AmazonOrderAPI.Filters
{
    public class LoggingFilterAttribute : IActionFilter
    {
        public ILoggerManager _logger;

        public LoggingFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
            _logger.LogInfo(((filterContext.HttpContext.Response.ToString()).Encrypt() + "Controller : " + filterContext.Controller + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.DisplayName.ToString() + "JSON"));
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
            }
            _logger.LogInfo((filterContext.HttpContext.Request.ToString().Encrypt() + "Controller : " + filterContext.Controller + Environment.NewLine + "Action : " + filterContext.ActionDescriptor.DisplayName.ToString() + "JSON" + filterContext.ActionArguments));
        }
    }
}