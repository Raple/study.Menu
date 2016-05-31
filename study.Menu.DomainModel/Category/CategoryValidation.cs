using Easy.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.DomainModel
{
   public class CategoryValidation: EntityValidation<Category>
    {
        public CategoryValidation()
        {
            this.IsNullOrWhiteSpace(m => m.CategoryName, CategoryBrokenRuleMessage.CategoryNameIsEmpty);

            this.AddRule(m => m.CategoryName, new ValidateCategoryName(), CategoryBrokenRuleMessage.CategoryNameIsRepeat);
        }
    }

    public class ValidateCategoryName : IValidate<Category>
    {
        public bool IsSatisfy(Category model)
        {
            return true;
        }
    }
}
