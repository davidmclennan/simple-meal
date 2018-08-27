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
    public class RecipePageModelTests : IDisposable
    {
        RecipePageModel recipePageModel;
        Mock<IRestService> restServiceMock;

        public RecipePageModelTests()
        {
            restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;
        }

        public void Dispose()
        {
            restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void InitSetsIdFromPassedModel(int value)
        {
            var recipe = new Recipe { Id = value };
            recipePageModel.Init(recipe);
            Assert.Equal(value, recipePageModel.Id);
        }

        [Theory]
        [InlineData("Beef and Mustard Pie")]
        [InlineData("Beef and Oyster Pie")]
        public void InitSetsTitleFromPassedModel(string value)
        {
            var recipe = new Recipe { Name = value };
            recipePageModel.Init(recipe);
            Assert.Equal(value, recipePageModel.Title);
        }

        [Fact]
        public void InitSetsIsLoadingToTrue()
        {
            recipePageModel.Init(new Recipe());
            Assert.True(recipePageModel.IsLoading);
        }

        [Fact]
        public async Task GetRecipeSetsIsLoadingFromTrueToFalse()
        {
            restServiceMock.Setup(a => a.GetAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Recipe());
            recipePageModel.Init(new Recipe());
            await recipePageModel.GetRecipe();
            Assert.False(recipePageModel.IsLoading);
        }

        [Theory]
        [InlineData("Beef and Mustard Pie")]
        [InlineData("Beef and Oyster Pie")]
        public async Task GetRecipeSetsRecipeModel(string value)
        {
            restServiceMock.Setup(a => a.GetAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Recipe { Name = value });
            await recipePageModel.GetRecipe();
            Assert.Equal(value, recipePageModel.Recipe.Name);
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=jNQXAC9IVRw", "https://i.ytimg.com/vi/jNQXAC9IVRw/hqdefault.jpg")]
        [InlineData("https://www.youtube.com/watch?v=LeAltgu_pbM", "https://i.ytimg.com/vi/LeAltgu_pbM/hqdefault.jpg")]
        public async Task GetRecipeSetsVideoThumbnailFromRetrievedRecipe(string videoUrl, string expectedThumbnailurl)
        {
            restServiceMock.Setup(a => a.GetAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Recipe { Video = videoUrl });
            await recipePageModel.GetRecipe();
            Assert.Equal(expectedThumbnailurl, recipePageModel.VideoThumbnail);
        }

        [Theory]
        [InlineData("Instruction1")]
        [InlineData("Instruction2")]
        public async Task GetRecipeSetsInstructionsListFirstEntryToRecipeInstructions(string value)
        {
            restServiceMock.Setup(a => a.GetAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Recipe { Instructions = value });
            await recipePageModel.GetRecipe();
            Assert.Equal(value, recipePageModel.Instructions.First());
        }

        // Change to theory with models as inline data
        [Fact]
        public void PopulateIngredientsPopulatesIngredientsAndRemovesBlankEntries()
        {
            recipePageModel.Recipe = new Recipe { Measure1 = "1kg", Ingredient1 = "Beef", Measure2 = "", Ingredient2 = "" };
            recipePageModel.PopulateIngredients();
            Assert.True(recipePageModel.Ingredients.Count == 1);
        }
    }
}
