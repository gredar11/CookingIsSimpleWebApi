using Cis.Domain.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.Repositories
{
    public class RecipeRepository :RepositoryBase<Recipe>, IRecipesRepository
    {
        public RecipeRepository(CisDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void AddIngredient(int recipeId, int ingredientId, AmountOfIngredient ingredient)
        {
            ingredient.IngredientId = ingredientId;
            ingredient.RecipeId = recipeId;
            RepositoryContext.Set<AmountOfIngredient>().Add(ingredient);
        }

        public void CreateReceip(int categoryId, Recipe recipe)
        {
            recipe.RecipeCategoryId = categoryId;
            Create(recipe);
        }
        // добавить проверку на поиск категории в таблице с категориями
        public async Task<IEnumerable<Recipe>> GetAllReceipsOfCategory(int categoryId, bool trackChanges)
        {
            return await FindByCondition(x => x.RecipeCategoryId == categoryId, trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<AmountOfIngredient>> GetIngredientsFromRecipe(int recipeId, bool trackChanges)
        {
            if(trackChanges)
                return await RepositoryContext.Set<AmountOfIngredient>().Where(x => x.RecipeId == recipeId).ToListAsync();
            return await RepositoryContext.Set<AmountOfIngredient>().Where(x => x.RecipeId == recipeId).AsNoTracking().ToListAsync();
        }

        public async Task<Recipe> GetRecipeById(int categoryId, int id, bool trackChanges)
        {
            return await FindByCondition(x => x.RecipeCategoryId == categoryId && x.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }
}
