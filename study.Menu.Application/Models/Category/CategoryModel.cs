using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Application.Models
{
    /// <summary>
    /// 商品分类
    /// </summary>
   public class CategoryModel
    {
        /// <summary>
        /// 商品分类ID
        /// </summary>
        public Int32 Id;
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string CategoryName;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort;

        /// <summary>
        /// 菜品数量
        /// </summary>
        public int FoodCount;
    }
}
