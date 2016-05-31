using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.DomainModel
{
   public class Category : EntityBase<Int32>
    {
        public Category()
        {

        }

        public Category(String categoryName, int restaurantId, int foodCount = 0)
        {
            this.CategoryName = categoryName;
            this.Sort = 0;
            this.RestaurantId = restaurantId;
            this.FoodCount = foodCount;
        }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public String CategoryName
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get;
            set;
        }
        /// <summary>
        /// 门店ID
        /// </summary>
        public int RestaurantId
        {
            get;
            private set;
        }

        public int FoodCount
        {
            get;
            private set;
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new CategoryBrokenRuleMessage();
        }

        public override bool Validate()
        {
            return new CategoryValidation().IsSatisfy(this);
        }
    }
}
