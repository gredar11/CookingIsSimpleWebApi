using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.GetResponseDto;
using Shared.CreationDto;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IRecipeCategoryService
    {
        Task<RecipeCategoryDto> GetRecipeCategoryById(int id, bool trackChanges);
        Task<IEnumerable<RecipeCategoryDto>> GetAllRecipeCategories(bool trackChanges);
        Task<RecipeCategoryDto> CreateRecipeCategory(RecipeCategoryCreationDto creationDto, bool trackChanges);
    }
}
