using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Easy.Public.MyLog;

namespace study.Menu.Api.Utility
{
    public class ErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string url = actionExecutedContext.Request.RequestUri.ToString();
            LogManager.Error(url, actionExecutedContext.Exception.Message + actionExecutedContext.Exception.StackTrace);
        }
    }
}
