using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FreshMvvm;
using SimpleMeal.Models;
using SimpleMeal.PageModels;
using SimpleMeal.Services;

namespace SimpleMeal.Tests
{
    public class RecipeListPageModelTests
    {
        [Theory]
        [InlineData("Beef")]
        [InlineData("Chicken")]
        public void GetTitleReturnsAssignedValue(string value)
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;

            recipeListPageModel.Title = value;

            Assert.Equal(value, recipeListPageModel.Title);
        }

        [Fact]
        public async Task GetRecipesPopulatesRecipeList()
        {
            var restServiceMock = new Mock<IRestService>();
            //restServiceMock.Setup(a => a.GetAllAsync<Recipe>("https://www.themealdb.com/api/json/v1/1/filter.php?c=", "meals")).ReturnsAsync(new List<Recipe> { new Recipe() });
            restServiceMock.Setup(a => a.GetAllAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Recipe> { new Recipe() });
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;

            await recipeListPageModel.GetRecipes();

            Assert.True(recipeListPageModel.Recipes.Count > 0);
        }

        [Fact]
        public void InitSetsIsLoadingToTrue()
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;

            recipeListPageModel.Init(null);

            Assert.True(recipeListPageModel.IsLoading);
        }

        [Fact]
        public async Task GetRecipesPopulatesRecipeListAndSetsIsLoadingToFalse()
        {
            var restServiceMock = new Mock<IRestService>();
            restServiceMock.Setup(a => a.GetAllAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Recipe> { new Recipe() });
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;

            recipeListPageModel.Init(null);

            await recipeListPageModel.GetRecipes();

            Assert.False(recipeListPageModel.IsLoading);
        }
    }
}
