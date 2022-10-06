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

        public async Task<IngredientDto> CreateIngredientForCategory(int categoryId, int ingredientId, IngredientForCreationDto forCreationDto, bool trackChanges)
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

        public Task DeleteIngredient(int categoryId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientByCategory(int categoryId, int ingredientId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IngredientDto>> GetIngredientsByFoodCategory(int foodCategoryId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpgradeIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
