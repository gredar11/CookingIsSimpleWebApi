using Domain.Exceptions;
using Domain.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
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

        public void AddIngredient(int recipeId, AmountOfIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void CreateReceip(int categoryId, Recipe recipe)
        {
            recipe.RecipeCategoryId = categoryId;
            Create(recipe);
            RepositoryContext.Entry(recipe).Reference(x => x.RecipeCategory).Load();
            RepositoryContext.Entry(recipe).Collection(x => x.Ingredients).Load();
        }
        // добавить проверку на поиск категории в таблице с категориями
        public async Task<IEnumerable<Recipe>> GetAllReceipsOfCategory(int categoryId, bool trackChanges)
        {
            return await FindByCondition(x => x.RecipeCategoryId == categoryId, trackChanges).ToListAsync();
        }

        public async Task<AmountOfIngredient> GetIngredientForRecipe(int recipeId, int ingredientId)
        {
            var entity = await RepositoryContext.Set<AmountOfIngredient>().Where(x => x.RecipeId == recipeId && x.IngredientId == ingredientId).Include(x => x.Ingredient).Include(x => x.Recipe).SingleOrDefaultAsync();
            return entity;
        }

        public async Task<IEnumerable<AmountOfIngredient>> GetIngredientsFromRecipe(int recipeId, bool trackChanges)
        {
            if(trackChanges)
                return await RepositoryContext.Set<AmountOfIngredient>().Where(x => x.RecipeId == recipeId).ToListAsync();
            return await RepositoryContext.Set<AmountOfIngredient>().Where(x => x.RecipeId == recipeId).AsNoTracking().ToListAsync();
        }

        public async Task<Recipe> GetRecipeById(int categoryId, int id, bool trackChanges)
        {
            var recipe = await FindByCondition(x => x.RecipeCategoryId == categoryId && x.Id == id, trackChanges).Include(x =>x.RecipeCategory).SingleOrDefaultAsync();
            await RepositoryContext.Entry(recipe).Collection(x => x.Ingredients).LoadAsync();
            return recipe;
        }
    }
}
