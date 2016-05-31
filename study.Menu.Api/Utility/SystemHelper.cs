using Easy.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Api.Utility
{
    static class SystemHelper
    {
        public static ReturnContext GetSystemIdAndVersion(HttpRequestMessage req)
        {
            var systemId = req.Headers.GetValues("SystemId").FirstOrDefault();
            var version = req.Headers.GetValues("Version").FirstOrDefault();

            return new ReturnContext() { SystemId = systemId, Version = version };
        }
    }
}
