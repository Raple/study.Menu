using NUnit.Framework;
using study.Menu.DomainModel;
using System.Linq;

namespace study.Menu.Test.RepositoryTest.Category
{
    public class CategoryRepositoryTest
    {
        [Test]
        public void AddTest()
        {
            var foodCategory = Create();
            RepositoryRegistry.Category.Add(foodCategory);
            Assert.IsTrue(foodCategory.Id > 0);

            var result = RepositoryRegistry.Category.FindBy(foodCategory.Id);
            foodCategoryAssert(foodCategory, result);
        }


        [Test]
        public void SelectTest()
        {
            var foodCategory = Create();
            RepositoryRegistry.Category.Add(foodCategory);

            var foodCategory2 = Create();
            RepositoryRegistry.Category.Add(foodCategory2);

            int totalRows = 0;
            var query = new CategoryQuery() { PageIndex = 1, PageSize = 1, RestaurantId = 1 };
            var result = RepositoryRegistry.Category.Select(query, out totalRows);



            Assert.AreEqual(2, totalRows);
            Assert.AreEqual(1, result.Count());

            var query2 = new CategoryQuery() { PageIndex = 1, PageSize = 1, RestaurantId = 9 };
            var result2 = RepositoryRegistry.Category.Select(query2, out totalRows);
            Assert.AreEqual(0, totalRows);
            Assert.AreEqual(0, result2.Count());
        }

        public static DomainModel.Category Create(int restaurantId = 1)
        {
            var foodCategory = new DomainModel.Category("测试商品分类名称", restaurantId)
            {
                Sort = 99
            };
            return foodCategory;
        }

        private void foodCategoryAssert(DomainModel.Category expected, DomainModel.Category actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.CategoryName, actual.CategoryName);
            Assert.AreEqual(expected.RestaurantId, actual.RestaurantId);
            Assert.AreEqual(expected.Sort, actual.Sort);
        }

    }
}
