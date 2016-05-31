using Easy.Public;
using study.Menu.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Infrastructure.Repository
{
   public class CategorySql
    {
        public static string BaseSelectSql()
        {
            return @"select Id,CategoryName,RestaurantId,Sort,FoodCount from foodcategory";
        }

        public static Tuple<string, dynamic> AddSql(Category foodCategory)
        {
            const string sql = "insert into foodcategory(CategoryName,RestaurantId,Sort,FoodCount) values(@CategoryName,@RestaurantId,@Sort,@FoodCount); select LAST_INSERT_ID()";
            return new Tuple<string, dynamic>(sql, InsertAndUpdateData(foodCategory));
        }

        public static Tuple<string, string, dynamic> Select(CategoryQuery query)
        {
            string whereSql = QuerySql(query);
            string countsql = string.Format("select count(Id) as Count from foodcategory {0};", whereSql);
            string selectsql = string.Join(" ", BaseSelectSql(), whereSql, "order by Id desc", "limit @limit offset @offset;");

            return new Tuple<string, string, dynamic>(countsql, selectsql, new
            {
                limit = query.Limit,
                offset = query.Offset,
                RestaurantId = query.RestaurantId
            });
        }

        private static String QuerySql(CategoryQuery query)
        {
            var builder = new SQLBuilder();
            builder.AppendWhere();
            builder.Append(query.RestaurantId > 0, "and", "RestaurantId=@RestaurantId");

            return builder.Sql();
        }

        private static dynamic InsertAndUpdateData(Category foodCategory)
        {
            var data = new
            {
                Id = foodCategory.Id,
                CategoryName = foodCategory.CategoryName ?? "",
                RestaurantId = foodCategory.RestaurantId,
                Sort = foodCategory.Sort,
                FoodCount = foodCategory.FoodCount
            };
            return data;
        }
    }
}
