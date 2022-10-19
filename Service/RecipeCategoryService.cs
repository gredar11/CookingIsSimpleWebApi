using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cis.Domain.Models;
using Contracts;
using Service.Contracts;
using Shared.CreationDto;
using Shared.GetResponseDto;

namespace Service
{
    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public RecipeCategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecipeCategoryDto> CreateRecipeCategory(RecipeCategoryCreationDto creationDto, bool trackChanges)
        {
            var entity = _mapper.Map<RecipeCategory>(creationDto);
            await _repository.RecipesCategoryRepository.CreateCategory(entity);
            await _repository.SaveAsync();
            return _mapper.Map<RecipeCategoryDto>(entity);
        }

        public async Task<IEnumerable<RecipeCategoryDto>> GetAllRecipeCategories(bool trackChanges)
        {
            var allEntities = await _repository.RecipesCategoryRepository.GetAllRecipeCategories(trackChanges);
            return _mapper.Map<IEnumerable<RecipeCategoryDto>>(allEntities);
        }

        public async Task<RecipeCategoryDto> GetRecipeCategoryById(int id, bool trackChanges)
        {
            var entity = await _repository.RecipesCategoryRepository.GetCategoryById(id, trackChanges);
            return _mapper.Map<RecipeCategoryDto>(entity);
        }
    }
}
