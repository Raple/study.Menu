using Easy.Domain.Application;
using study.Menu.Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Application
{
    /// <summary>
    /// 应用服务注册中心
    /// </summary>
    public class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new CategoryApplication());
        }

        public static CategoryApplication Category
        {
            get
            {
                return ApplicationFactory.Instance().Get<CategoryApplication>();
            }
        }
    }
}
