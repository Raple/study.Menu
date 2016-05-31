using Dapper;
using Easy.Domain.RepositoryFramework;
using Easy.Public;
using study.Menu.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace study.Menu.Infrastructure.Repository
{
    public class CategoryRepository: ICategoryRepository,IDao
    {
        private static readonly EntityPropertyHelper<Category> propertyHelper = new EntityPropertyHelper<Category>();             
        IEnumerable<DomainModel.Category> ICategoryRepository.Select(CategoryQuery query, out int totalRows)
        {
            if (query.PageIndex <= 0)
            {
                query.PageIndex = 1;
            }
            if (query.PageSize <= 0 || query.PageSize > 100)
            {
                query.PageSize = 100;
            }

            using (var conn = DataBase.Open())
            {
                var tuple = CategorySql.Select(query);
                SqlMapper.GridReader reader = conn.QueryMultiple(tuple.Item1 + tuple.Item2, (object)tuple.Item3);

                var result = reader.Read<object>().First() as IDictionary<string, object>;
                totalRows = Convert.ToInt32(result["Count"]);
                return reader.Read<Category>();
            }
        }

        public void Add(Category item)
        {
            using (var conn = DataBase.Open())
            {
                var tuple = CategorySql.AddSql(item);
                int id = conn.ExecuteScalar<int>(tuple.Item1, (object)tuple.Item2);
                propertyHelper.SetValue(m => m.Id, item, id);
            }
        }

        public DomainModel.Category FindBy(int key)
        {
            throw new NotImplementedException();
        }

        public IList<DomainModel.Category> FindAll()
        {
            throw new NotImplementedException();
        }
       
        public void Update(DomainModel.Category item)
        {
            throw new NotImplementedException();
        }

        public void Remove(DomainModel.Category item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
