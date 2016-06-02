using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.DomainModel
{
   public class RepositoryRegistry
    {
        readonly static RepositoryFactory factory;
        static RepositoryRegistry()
        {
            RepositoryFactoryBuilder b = new RepositoryFactoryBuilder();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "study.Menu.Infrastructure.dll");
            Stream stream = Assembly.ReflectionOnlyLoadFrom(path).GetManifestResourceStream("study.Menu.Infrastructure.Repository.repositories.config");
            factory = b.Build(stream);
        }

        public static ICategoryRepository Category
        {
            get
            {
                return factory.Get<ICategoryRepository>();
            }
        }

    }
}
