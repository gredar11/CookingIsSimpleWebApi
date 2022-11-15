using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
using Contracts;
using Service.Contracts;
using Shared.CreationDto;
using Shared.GetResponseDto;
using Shared.UpdatingDto;

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

        public async Task<AmountOfIngredientDto> AddIngredientToRecipe(int recipeCategoryId,int recipeId, int ingredientId, RecipeIngredientAddingDto addingDto, bool trackChanges)
        {
            var entity = _mapper.Map<AmountOfIngredient>(addingDto);
            _repository.RecipesRepository.AddIngredient(recipeId, ingredientId, entity);
            await _repository.SaveAsync();
            entity = await _repository.RecipesRepository.GetIngredientForRecipe(recipeId, ingredientId);
            return _mapper.Map<AmountOfIngredientDto>(entity);
        }

        public async Task<RecipeDto> CreateRecipe(int categoryId, RecipeCreationDto recipeCreationDto)
        {
            await CheckIfRecipeCategoryExists(categoryId);
            var entity = _mapper.Map<Recipe>(recipeCreationDto);
            _repository.RecipesRepository.CreateReceip(categoryId, entity);
            await _repository.SaveAsync();
            return _mapper.Map<RecipeDto>(entity);
        }

        private async Task CheckIfRecipeCategoryExists(int categoryId)
        {
            var recipeCategory = await _repository.RecipesCategoryRepository.GetCategoryById(categoryId, false);
            if (recipeCategory is null)
                throw new EntityNotFoundException<RecipeCategory>(categoryId);
        }

        public async Task<IEnumerable<RecipeDto>> GetAllRecipesFromCategory(int categoryId, bool trackChanges)
        {
            await CheckIfRecipeCategoryExists(categoryId);
            var entitiesOfCategory = await _repository.RecipesRepository.GetAllReceipsOfCategory(categoryId, trackChanges);
            return _mapper.Map<IEnumerable<RecipeDto>>(entitiesOfCategory);
        }

        public async Task<IEnumerable<AmountOfIngredientDto>> GetIngredientsFromRecipe(int recipeCategoryId, int recipeId, bool trackChanges)
        {
            var entities = await _repository.RecipesRepository.GetIngredientsFromRecipe(recipeId, trackChanges);
            return _mapper.Map<IEnumerable<AmountOfIngredientDto>>(entities);
        }

        public async Task<RecipeDto> GetRecipeByIdFromCategory(int categoryId, int recipeId, bool trackChanges)
        {
            await CheckIfRecipeCategoryExists(categoryId);
            var entity = await _repository.RecipesRepository.GetRecipeById(categoryId, recipeId, trackChanges);
            return _mapper.Map<RecipeDto>(entity);
        }

        public async Task<(IEnumerable<AmountOfIngredientDto> dtos, string ids)> AddMultipleIngredientsToRecipe(int recipeCategoryId, int recipeId, IEnumerable<AmountOfIngredientToAddIntoRecipeDto> ingredientDtos)
        {
            if (ingredientDtos == null)
                throw new IngredientCollectionBadRequest();
            var recipeEntity = await _repository.RecipesRepository.GetRecipeById(recipeCategoryId, recipeId, false);
            if (recipeEntity is null)
                throw new EntityNotFoundException<Recipe>(recipeId);
            var amntOfIngredientsEntities = _mapper.Map<IEnumerable<AmountOfIngredient>>(ingredientDtos);
            foreach (var ingredient in amntOfIngredientsEntities)
            {
                _repository.RecipesRepository.AddIngredient(recipeId, ingredient);
            }
            await _repository.SaveAsync();
            var res = _mapper.Map<IEnumerable<AmountOfIngredientDto>>(amntOfIngredientsEntities);
            var idsString = string.Join(",",amntOfIngredientsEntities.Select(x => x.RecipeId.ToString() + x.IngredientId.ToString()));
            return (res, idsString);
        }
    }
}
