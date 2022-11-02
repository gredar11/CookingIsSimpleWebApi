using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cis.Domain.Exceptions;
using Cis.Domain.Models;
using Contracts;
using Service.Contracts;
using Shared.CreationDto;
using Shared.GetResponseDto;
using Shared.RequestFeatures;
using Shared.UpdatingDto;

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

        public async Task<RecipeCategoryDto> CreateRecipeCategory(RecipeCategoryCreationDto creationDto)
        {
            var entity = _mapper.Map<RecipeCategory>(creationDto);
            _repository.RecipesCategoryRepository.CreateCategory(entity);
            await _repository.SaveAsync();
            return _mapper.Map<RecipeCategoryDto>(entity);
        }

        public async Task DeleteRecipeCategory(int id)
        {
            _repository.RecipesCategoryRepository.DeleteCategory(id);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<RecipeCategoryDto>> GetAllRecipeCategories(bool trackChanges)
        {
            var allEntities = await _repository.RecipesCategoryRepository.GetAllRecipeCategories(trackChanges);
            return _mapper.Map<IEnumerable<RecipeCategoryDto>>(allEntities);
        }

        public async Task<(IEnumerable<RecipeCategoryDto> recipeCategories, PageMetaData pageMetaData)> GetRecipeCategories(RequestParameters requestParameters, bool trackChanges)
        {
            var res = await _repository.RecipesCategoryRepository.GetRecipeCategories(requestParameters, trackChanges);
            var dtos = _mapper.Map<IEnumerable<RecipeCategoryDto>>(res);
            return (recipeCategories: dtos, pageMetaData: res.MetaData);
        }

        public async Task<RecipeCategoryDto> GetRecipeCategoryById(int id, bool trackChanges)
        {
            RecipeCategory entity = await GetRecipeCategory(id, trackChanges);
            return _mapper.Map<RecipeCategoryDto>(entity);
        }


        public async Task UpdateRecipeCategory(int id, RecipeCategoryUpdateDto updateDto)
        {
            var entity = await GetRecipeCategory(id, trackChanges: true);
            _mapper.Map(updateDto, entity);
            await _repository.SaveAsync();
        }
        private async Task<RecipeCategory> GetRecipeCategory(int id, bool trackChanges)
        {
            var entity = await _repository.RecipesCategoryRepository.GetCategoryById(id, trackChanges);
            if (entity == null)
                throw new EntityNotFoundException<FoodCategory>(id);
            return entity;
        }
    }
}
