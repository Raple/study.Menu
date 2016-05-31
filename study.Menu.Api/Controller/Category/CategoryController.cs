using study.Menu.Api.Models;
using study.Menu.Api.Utility;
using study.Menu.Application;
using study.Menu.Application.Models;
using System.Web.Http;
using Easy.Domain.Application;

namespace study.Menu.Api.Controller.Category
{
    public class CategoryController: ApiController
    {
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns>商品分类ID</returns>
        [HttpPost]
        public ResultWithData<CategoryModel> Add(AddModel addModel)
        {

            IReturn @IReturn = ApplicationRegistry.Category.Add(addModel.Name, addModel.Sort, addModel.RestaurantId);
            ResultWithData<CategoryModel> result = @IReturn.Result(SystemHelper.GetSystemIdAndVersion(this.Request));
            return result;
        }

        /// <summary>
        /// 更新商品分类
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns>商品分类ID</returns>
        [HttpPost]
        public ResultWithData<PageList<CategoryModel>> Select(int restaurantId)
        {
            IReturn @IReturn = ApplicationRegistry.Category.Select(restaurantId);
            ResultWithData<PageList<CategoryModel>> result = @IReturn.Result(SystemHelper.GetSystemIdAndVersion(this.Request));
            return result;
        }

    }
}
