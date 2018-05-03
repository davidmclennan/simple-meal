using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FreshMvvm;
using SimpleMeal.PageModels;
using SimpleMeal.Services;

namespace SimpleMeal.Tests
{
    public class Class1
    {
        [Fact]
        public void GetTitleReturnsAssignedValue()
        {
            var restServiceMock = new Mock<RestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;

            recipeListPageModel.Title = "Beef";

            Assert.Equal("Beef", recipeListPageModel.Title);
        }
    }
}
