using Cis.Domain.Models;
using Shared.CreationDto;
using Shared.UpdatingDto;
using Shared.GetResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IRecipeService
    {
        Task<RecipeDto> CreateRecipe(int categoryId, RecipeCreationDto recipeCreationDto);
        Task<RecipeDto> GetRecipeByIdFromCategory(int categoryId, int recipeId, bool trackChanges);
        Task<IEnumerable<RecipeDto>> GetAllRecipesFromCategory(int categoryId, bool trackChanges);
        Task<IEnumerable<AmountOfIngredientDto>> GetIngredientsFromRecipe(int recipeCategoryId, int recipeId, bool trackChanges);
        Task<AmountOfIngredientDto> AddIngredientToRecipe(int recipeCategoryId, int recipeId, int ingredientId, RecipeIngredientAddingDto addingDto, bool trackChanges);
        Task<(IEnumerable<AmountOfIngredientDto> dtos, string ids)> AddMultipleIngredientsToRecipe(int recipeCategoryId, int recipeId, IEnumerable<AmountOfIngredientToAddIntoRecipeDto> ingredientDtos);
    }
}
