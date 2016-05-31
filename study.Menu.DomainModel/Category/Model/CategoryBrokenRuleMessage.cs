using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study.Menu.DomainModel
{
    public class CategoryBrokenRuleMessage : BrokenRuleMessage
    {
        public const string CategoryNameIsEmpty = "81001";
        public const string CategoryNameIsRepeat = "81002";

        protected override void PopulateMessage()
        {
            this.Messages.Add(CategoryNameIsEmpty, "商品分类名称不能为空");
            this.Messages.Add(CategoryNameIsRepeat, "商品分类名称不能重复");
        }
    }
}
