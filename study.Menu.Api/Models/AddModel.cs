using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.Api.Models
{
   public class AddModel
    {
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 餐厅ID
        /// </summary>
        public int RestaurantId { get; set; }
    }
}
