using Cis.Domain.Models;
using Shared;
using Shared.GetResponseDto;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IIngredientService
    {
        Task<IngredientDto> CreateIngredientForCategory(int categoryId, IngredientForCreationDto forCreationDto, bool trackChanges);
        Task<(IEnumerable<IngredientDto> ingredients, string ids)> CreateCollectionOfIngredients(int categoryId, IEnumerable<IngredientForCreationDto> creationDtos);
        Task<(IEnumerable<IngredientDto>, PageMetaData)> GetAllIngredientsFromFoodCategory(int foodCategoryId, IngredientParameters ingredientParameters, bool trackChanges);
        Task<IngredientDto> GetIngredientFromFoodCategoryById(int categoryId, int ingredientId, bool trackChanges);
        Task<IEnumerable<IngredientDto>> GetByIds(int categoryId, IEnumerable<int> ids, bool trackChanges);
        Task UpdateIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges);
        Task<(IngredientForUpdateDto updateDto,Ingredient entity)> PartiallyUpdateIngredient(int categoryId, int ingredientId, bool trackChanges);
        Task SavePatchChanges(IngredientForUpdateDto updateDto, Ingredient ingredient);
        Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges);

    }
}
