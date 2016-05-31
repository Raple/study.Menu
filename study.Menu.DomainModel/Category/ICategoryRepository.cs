using Easy.Domain.Base;
using Easy.Domain.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.DomainModel
{
   public interface ICategoryRepository: IRepository<Category, int>
    {
        IEnumerable<Category> Select(CategoryQuery query, out int totalRows);
    }
}
