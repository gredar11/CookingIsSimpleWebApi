using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRecipesRepository
    {
        Task<IEnumerable<Recipe>> GetAllReceipsOfCategory(int categoryId, bool trackChanges);
        Task<Recipe> GetRecipeById(int categoryId, int id, bool trackChanges);
        void CreateReceip(int categoryId, Recipe recipe);
        void AddIngredient(int recipeId, int ingredientId, AmountOfIngredient ingredient);
        void AddIngredient(int recipeId, AmountOfIngredient ingredient);
        Task<IEnumerable<AmountOfIngredient>> GetIngredientsFromRecipe(int recipeId, bool trackChanges);
        Task<AmountOfIngredient> GetIngredientForRecipe(int recipeId, int ingredientId);
    }
}
