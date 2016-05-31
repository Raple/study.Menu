using System;
using System.Threading.Tasks;
using System.Web.Http;
using study.Menu.Api.Utility;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(study.Menu.Api.Startup))]

namespace study.Menu.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Filters.Add(new ErrorAttribute());

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
