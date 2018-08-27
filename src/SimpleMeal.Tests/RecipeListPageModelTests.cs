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
    public class RecipeListPageModelTests : IDisposable
    {
        RecipeListPageModel recipeListPageModel;
        Mock<IRestService> restServiceMock;

        public RecipeListPageModelTests()
        {
            restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;
        }

        public void Dispose()
        {
            restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            recipeListPageModel = new RecipeListPageModel(restServiceMock.Object);
            recipeListPageModel.CoreMethods = coreMethodsMock.Object;
        }

        [Theory]
        [InlineData("Beef")]
        [InlineData("Chicken")]
        public void InitSetsTitleFromPassedModelWithDishesConcatenation(string value)
        {
            recipeListPageModel.Init(value);
            Assert.Equal(value + " dishes", recipeListPageModel.Title);
        }

        [Fact]
        public async Task GetRecipesPopulatesRecipeList()
        {
            restServiceMock.Setup(a => a.GetAllAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Recipe> { new Recipe() });
            await recipeListPageModel.GetRecipes();
            Assert.True(recipeListPageModel.Recipes.Count > 0);
        }

        [Fact]
        public void InitSetsIsLoadingToTrue()
        {
            recipeListPageModel.Init(null);
            Assert.True(recipeListPageModel.IsLoading);
        }

        [Fact]
        public async Task GetRecipesSetsIsLoadingFromTrueToFalseWhenRecipeListIsPopulated()
        {
            restServiceMock.Setup(a => a.GetAllAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Recipe> { new Recipe() });
            recipeListPageModel.Init(null);
            await recipeListPageModel.GetRecipes();
            Assert.False(recipeListPageModel.IsLoading);
        }

        [Fact]
        public async Task GetRecipesDoesNotChangeIsLoadingFromTrueWhenRecipeListIsNotPopulated()
        {
            restServiceMock.Setup(a => a.GetAllAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<Recipe>());
            recipeListPageModel.Init(null);
            await recipeListPageModel.GetRecipes();
            Assert.True(recipeListPageModel.IsLoading);
        }
    }
}
