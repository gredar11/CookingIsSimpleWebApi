using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IFoodCategoryService FoodCategoryService { get; }
        IIngredientService IngredientService { get; }
        IRecipeCategoryService RecipeCategoryService { get; }
        IRecipeService RecipeService { get; }
    }
}
