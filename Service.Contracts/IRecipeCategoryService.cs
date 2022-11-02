using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.GetResponseDto;
using Shared.CreationDto;
using Shared.UpdatingDto;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IRecipeCategoryService
    {
        Task<(IEnumerable<RecipeCategoryDto> recipeCategories, PageMetaData pageMetaData)> GetRecipeCategories(RequestParameters requestParameters, bool trackChanges);
        Task<RecipeCategoryDto> GetRecipeCategoryById(int id, bool trackChanges);
        Task<IEnumerable<RecipeCategoryDto>> GetAllRecipeCategories(bool trackChanges);
        Task<RecipeCategoryDto> CreateRecipeCategory(RecipeCategoryCreationDto creationDto);
        Task UpdateRecipeCategory(int id, RecipeCategoryUpdateDto updateDto);
        Task DeleteRecipeCategory(int id);
    }
}
