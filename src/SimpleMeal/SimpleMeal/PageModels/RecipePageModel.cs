using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using SimpleMeal.Models;

namespace SimpleMeal.PageModels
{
    public class RecipePageModel : FreshBasePageModel
    {
        public Recipe Recipe { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            Recipe = initData as Recipe;
        }
    }
}
