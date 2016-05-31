using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using study.Menu.Application.Models;

namespace study.Menu.Application.Application.Category.Select
{
    public class SelectReturnTransformer : DefaultReturnTransformer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
            PageList<DomainModel.Category> tempList = data as PageList<DomainModel.Category>;
            int totalRows = tempList.TotalRows;
            IList<DomainModel.Category> list = tempList.Collections;

            List<CategoryModel> result = new List<CategoryModel>();
            foreach (var item in list)
            {
                var temp = new CategoryModel()
                {
                    CategoryName = item.CategoryName,
                    Id = item.Id,
                    Sort = item.Sort,
                    FoodCount = item.FoodCount
                };
                result.Add(temp);
            }

            return this.ResultValue(data: new PageList<CategoryModel> { Collections = result, TotalRows = totalRows });
        }
    }
}
