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
    public class RecipePageModelTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void InitSetsIdFromPassedModel(int value)
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;

            var recipe = new Recipe { Id = value };

            recipePageModel.Init(recipe);

            Assert.Equal(value, recipePageModel.Id);
        }

        [Theory]
        [InlineData("Beef and Mustard Pie")]
        [InlineData("Beef and Oyster Pie")]
        public async Task GetRecipeSetsRecipeModel(string value)
        {
            var restServiceMock = new Mock<IRestService>();
            restServiceMock.Setup(a => a.GetAsync<Recipe>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new Recipe { Name = value });
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;

            await recipePageModel.GetRecipe();

            Assert.Equal(value, recipePageModel.Recipe.Name);
        }

        // Change to theory with models as inline data
        [Fact]
        public void PopulateIngredientsRemovesBlankEntries()
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;

            recipePageModel.Recipe = new Recipe { Measure1 = "1kg", Ingredient1 = "Beef" };
            recipePageModel.PopulateIngredients();

            Assert.True(recipePageModel.Ingredients.Count == 1);
        }

        [Fact]
        public void SelectTabReturnsWhenTrue()
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;

            recipePageModel.InstructionsSelected = true;
            recipePageModel.IngredientsSelected = false;

            recipePageModel.SelectTab.Execute(true);

            Assert.True(recipePageModel.InstructionsSelected == true && recipePageModel.IngredientsSelected == false);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void SelectTabSetsIngredientsAndInstructionsSelectedToOppositeValues(bool value)
        {
            var restServiceMock = new Mock<IRestService>();
            var coreMethodsMock = new Mock<IPageModelCoreMethods>();
            var recipePageModel = new RecipePageModel(restServiceMock.Object);
            recipePageModel.CoreMethods = coreMethodsMock.Object;

            recipePageModel.InstructionsSelected = value;

            recipePageModel.SelectTab.Execute(false);

            Assert.True(recipePageModel.InstructionsSelected == !recipePageModel.IngredientsSelected);
        }
    }
}
