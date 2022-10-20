using AutoMapper;
using Cis.Domain.Models;
using Contracts;
using Service.Contracts;
using Shared.CreationDto;
using Shared.GetResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public RecipeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AmountOfIngredientDto> AddIngredientToRecipe(int recipeId, int ingredientId, RecipeIngredientAddingDto addingDto, bool trackChanges)
        {
            var entity = _mapper.Map<AmountOfIngredient>(addingDto);
            _repository.RecipesRepository.AddIngredient(recipeId, ingredientId, entity);
            await _repository.SaveAsync();
            return _mapper.Map<AmountOfIngredientDto>(entity);
        }

        public async Task<RecipeDto> CreateRecipe(int categoryId, RecipeCreationDto recipeCreationDto)
        {
            var entity = _mapper.Map<Recipe>(recipeCreationDto);
            _repository.RecipesRepository.CreateReceip(categoryId, entity);
            await _repository.SaveAsync();
            return _mapper.Map<RecipeDto>(entity);
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesFromCategory(int categoryId, bool trackChanges)
        {
            var entitiesOfCategory = await _repository.RecipesRepository.GetAllReceipsOfCategory(categoryId, trackChanges);
            return _mapper.Map<IEnumerable<RecipeDto>>(entitiesOfCategory);
        }

        public async Task<IEnumerable<AmountOfIngredientDto>> GetIngredientsFromRecipe(int recipeId, bool trackChanges)
        {
            var entities = await _repository.RecipesRepository.GetIngredientsFromRecipe(recipeId, trackChanges);
            return _mapper.Map<IEnumerable<AmountOfIngredientDto>>(entities);
        }

        public async Task<RecipeDto> GetRecipeByIdFromCategory(int categoryId, int recipeId, bool trackChanges)
        {
            var entity = await _repository.RecipesRepository.GetRecipeById(categoryId, recipeId, trackChanges);
            return _mapper.Map<RecipeDto>(entity);
        }

    }
}
