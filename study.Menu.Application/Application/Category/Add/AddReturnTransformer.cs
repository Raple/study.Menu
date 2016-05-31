using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using study.Menu.Application.Models;

namespace study.Menu.Application.Application.Category.Add
{
    public class AddReturnTransformer : DefaultReturnTransformer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
            DomainModel.Category foodCategory = data as DomainModel.Category;
            if (foodCategory.GetBrokenRules().Count > 0)
            {
                var brokenRule = foodCategory.GetBrokenRules()[0];
                return this.ResultValue<CategoryModel>(Int32.Parse(brokenRule.Name), null, brokenRule.Description);
            }

            return this.ResultValue(data: new CategoryModel()
            {
                CategoryName = foodCategory.CategoryName,
                Id = foodCategory.Id,
                Sort = foodCategory.Sort,
                FoodCount = foodCategory.FoodCount
            });
        }
    }
}
