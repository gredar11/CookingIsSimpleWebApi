using Cis.Domain.Models;
using Shared;
using Shared.GetResponseDto;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IIngredientService
    {
        Task<(IEnumerable<IngredientDto>, PageMetaData)> GetAllIngredientsFromFoodCategory(int foodCategoryId, IngredientParameters ingredientParameters, bool trackChanges);
        Task<IngredientDto> GetIngredientFromFoodCategoryById(int categoryId, int ingredientId, bool trackChanges);
        Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges);
        Task<IngredientDto> CreateIngredientForCategory(int categoryId, IngredientForCreationDto forCreationDto, bool trackChanges);
        Task UpdateIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges);
        Task<IEnumerable<IngredientDto>> GetByIds(int categoryId, IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<IngredientDto> ingredients, string ids)> CreateCollectionOfIngredients(int categoryId, IEnumerable<IngredientForCreationDto> creationDtos);

    }
}
