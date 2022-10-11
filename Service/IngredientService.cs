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
            await CheckIfFoodCategoryIsExist(categoryId, trackChanges);

            var entity = _mapper.Map<Ingredient>(forCreationDto);
            _repository.IngreditentRepository.CreateIngredient(categoryId, entity);
            await _repository.SaveAsync();
            var res = _mapper.Map<IngredientDto>(entity);
            return res;
        }

        public async Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges)
        {
            await CheckIfFoodCategoryIsExist(categoryId, trackChanges);

            var entityToDelete = await var entity = await CheckIfIngredientIsExist(categoryId, ingredientId, trackChanges);

            _repository.IngreditentRepository.DeleteIngredientById(entityToDelete);
            await _repository.SaveAsync();
        }

        public async Task<IngredientDto> GetIngredientByCategory(int categoryId, int ingredientId, bool trackChanges)
        {
            await CheckIfFoodCategoryIsExist(categoryId, trackChanges);

            var entity = await var entity = await CheckIfIngredientIsExist(categoryId, ingredientId, trackChanges);

            return _mapper.Map<IngredientDto>(entity);

        }

        public async Task<IEnumerable<IngredientDto>> GetIngredientsByFoodCategory(int foodCategoryId, bool trackChanges)
        {
            await CheckIfFoodCategoryIsExist(foodCategoryId, trackChanges);

            var entities = await _repository.IngreditentRepository.GetIngredients(foodCategoryId, trackChanges);
            return _mapper.Map<IEnumerable<IngredientDto>>(entities);

        }

        public async Task UpdateIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges)
        {
            await CheckIfFoodCategoryIsExist(categoryId, trackChanges);

            var entity = await CheckIfIngredientIsExist(categoryId, ingredientId, trackChanges);
            _mapper.Map(updateDto, entity);
            await _repository.SaveAsync();
        }
        public async Task CheckIfFoodCategoryIsExist(int id, bool trackchanges)
        {
            var category = await _repository.FoodCategoryRepository.GetFoodCategoryById(id, trackchanges);
            if (category == null)
                throw new FoodCategoryNotFoundException(id);
        }
        public async Task<Ingredient> CheckIfIngredientIsExist(int categoryId, int ingredientId, bool trackChanges)
        {
            var entity = await _repository.IngreditentRepository.GetIngredientById(categoryId, ingredientId, trackChanges);
            if (entity is null)
                throw new IngredientNotFoundException(ingredientId);
            return entity;
        }
    }
}
