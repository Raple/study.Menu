using Easy.Domain.Application;
using study.Menu.Application.Models;
using study.Menu.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Application.Application
{
   public class CategoryApplication:BaseApplication
    {
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="name">商品分类对象</param>
        /// <param name="sort">排序码</param>
        /// <param name="restaurantId">门店ID</param>
        /// <returns>商品分类ID</returns>
        public IReturn Add(string name, int sort, int restaurantId)
        {
            var foodCategory = new DomainModel.Category(name, restaurantId);
            foodCategory.Sort = sort;

            if (foodCategory.Validate())
            {
                RepositoryRegistry.Category.Add(foodCategory);
            }

            return this.Write("Add", foodCategory);
        }

        public IReturn Select(int restaurantId)
        {
            int totalRow = 0;
            CategoryQuery query = new CategoryQuery
            {
                PageIndex = 1,
                PageSize = 100,
                RestaurantId=restaurantId
            };

            var category=RepositoryRegistry.Category.Select(query,out totalRow).ToList();

            return this.Write("Select", new PageList<DomainModel.Category> { TotalRows = totalRow, Collections = category });
        }
    }
}
