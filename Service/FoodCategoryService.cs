using AutoMapper;
using Cis.Domain.Exceptions;
using Cis.Domain.Models;
using Contracts;
using Service.Contracts;
using Shared.CreationDto;
using Shared.GetResponseDto;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public FoodCategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FoodCategoryDto> CreateFoodCategory(FoodCategoryForCreationDto creationDto)
        {
            var entity = _mapper.Map<FoodCategory>(creationDto);
            await _repository.FoodCategoryRepository.CreateFoodCategory(entity);
            await _repository.SaveAsync();
            return _mapper.Map<FoodCategoryDto>(entity);
        }

        public async Task DeleteFoodCategory(int foodCategoryId, bool trackChanges)
        {
            var entity = await GetCompanyAndCheckIfItExists(foodCategoryId, trackChanges);

            _repository.FoodCategoryRepository.DeleteFoodCategory(entity);
            await _repository.SaveAsync();
        }

        public async Task<(IEnumerable<FoodCategoryDto> dtos, PageMetaData metaData)> GetFoodCategories(RequestParameters requestParameters, bool trackChanges)
        {
            var foodCategories = await _repository.FoodCategoryRepository.GetFoodCategories(requestParameters, trackChanges);
            var res = _mapper.Map<IEnumerable<FoodCategoryDto>>(foodCategories);
            return (dtos: res, metadata: foodCategories.MetaData);
        }

        public async Task<FoodCategoryDto> GetFoodCategoryById(int id, bool trackChanges)
        {
            var entity = await GetCompanyAndCheckIfItExists(id, trackChanges);

            var result = _mapper.Map<FoodCategoryDto>(entity);
            return result;
        }

        public async Task<(FoodCategoryForUpdateDto foodCategoryToPatch, FoodCategory foodCategoryEntity)> GetFoodCategoryForPatch(int id, bool trackChanges)
        {
            var foodCategoryEntity = await _repository.FoodCategoryRepository.GetFoodCategoryById(id, trackChanges);
            if (foodCategoryEntity == null)
                throw new EntityNotFoundException<FoodCategory>(id);
            var foodcategoryToPatch = _mapper.Map<FoodCategoryForUpdateDto>(foodCategoryEntity);
            return (foodcategoryToPatch, foodCategoryEntity);
        }

        public async Task SaveChangesForPatch(FoodCategoryForUpdateDto foodCategoryToPatch, FoodCategory foodCategoryEntity)
        {
            _mapper.Map(foodCategoryToPatch, foodCategoryEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateFoodCategory(int id, FoodCategoryForUpdateDto updateDto, bool trackChanges)
        {
            var entity = await GetCompanyAndCheckIfItExists(id, trackChanges);
            _mapper.Map(updateDto, entity);
            await _repository.SaveAsync();
        }
        private async Task<FoodCategory> GetCompanyAndCheckIfItExists(int id, bool trackChanges) 
        { 
            var foodCategory = await _repository.FoodCategoryRepository.GetFoodCategoryById(id, trackChanges); 
            if (foodCategory is null) throw new EntityNotFoundException<FoodCategory>(id); 
            return foodCategory; 
        }
    }
}
