using AutoMapper;
using Cis.Domain.Exceptions;
using Cis.Domain.Models;
using Contracts;
using Service.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class IngredientService: IIngredientService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public IngredientService(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;
        }

        public async Task<IngredientDto> CreateIngredientForCategory(int categoryId, IngredientForCreationDto forCreationDto, bool trackChanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(categoryId, trackChanges);
            if(category is null)
                throw new FoodCategoryNotFoundException(categoryId);
            var entity = _mapper.Map<Ingredient>(forCreationDto);
            _repository.IngreditentRepository.CreateIngredient(categoryId, entity);
            await _repository.SaveAsync();
            var res = _mapper.Map<IngredientDto>(entity);
            return res;
        }

        public async Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(categoryId, trackChanges);
            if (category == null)
                throw new FoodCategoryNotFoundException(categoryId);
            var entityToDelete = await _repository.IngreditentRepository.GetIngredientById(categoryId, ingredientId, trackChanges);
            if (entityToDelete is null)
                throw new IngredientNotFoundException(ingredientId);
            _repository.IngreditentRepository.DeleteIngredientById(entityToDelete);
            await _repository.SaveAsync();
        }

        public async Task<IngredientDto> GetIngredientByCategory(int categoryId, int ingredientId, bool trackChanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(categoryId, trackChanges);
            if (category == null)
                throw new FoodCategoryNotFoundException(categoryId);
            var entity = await _repository.IngreditentRepository.GetIngredientById(categoryId, ingredientId, trackChanges);
            if (entity is null)
                throw new IngredientNotFoundException(ingredientId);
            return _mapper.Map<IngredientDto>(entity);

        }

        public async Task<IEnumerable<IngredientDto>> GetIngredientsByFoodCategory(int foodCategoryId, bool trackChanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(foodCategoryId, trackChanges);
            if (category == null)
                throw new FoodCategoryNotFoundException(foodCategoryId);
            var entities = await _repository.IngreditentRepository.GetIngredients(foodCategoryId, trackChanges);
            return _mapper.Map<IEnumerable<IngredientDto>>(entities);

        }

        public async Task UpgradeIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(categoryId, trackChanges);
            if (category == null)
                throw new FoodCategoryNotFoundException(categoryId);
            var entity = await _repository.IngreditentRepository.GetIngredientById(categoryId, ingredientId, trackChanges);
            if (entity is null)
                throw new IngredientNotFoundException(ingredientId);
            _mapper.Map(updateDto, entity);
            await _repository.SaveAsync();
        }
    }
}
