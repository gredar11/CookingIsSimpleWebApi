using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CreationDto;
using Shared.UpdatingDto;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("/recipecategory/{categoryId}/recipe")]
    public class RecipeController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public RecipeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(int categoryId, [FromBody] RecipeCreationDto creationDto)
        {
            var res = await _serviceManager.RecipeService.CreateRecipe(categoryId, creationDto);
            return Ok(res);
        }
        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipeById(int categoryId, int recipeId)
        {
            var res = await _serviceManager.RecipeService.GetRecipeByIdFromCategory(categoryId, recipeId, trackChanges: false);
            return Ok(res);
        }
        [HttpPut("{recipeId}/ingredient/{ingredientId}")]
        public async Task<IActionResult> AddIngredientToRecipe(int categoryId, int recipeId, int ingredientId, [FromBody] RecipeIngredientAddingDto addingDto)
        {
            var res = await _serviceManager.RecipeService.AddIngredientToRecipe(categoryId, recipeId, ingredientId, addingDto, trackChanges: false);
            return Ok(res);
        }
        [HttpGet("{recipeId}/ingredient/")]
        public async Task<IActionResult> GetIngredientsOfRecipe(int categoryId, int recipeId)
        {
            var res = await _serviceManager.RecipeService.GetIngredientsFromRecipe(categoryId, recipeId, trackChanges: false);
            return Ok(res);
        }
        [HttpPut("{recipeId}/ingredient/")]
        public async Task<IActionResult> AddMultipleIngredientsToRecipe(int categoryId, int recipeId, [FromBody] IEnumerable<AmountOfIngredientToAddIntoRecipeDto> amountOfIngredients)
        {
            var res = await _serviceManager.RecipeService.AddMultipleIngredientsToRecipe(categoryId, recipeId, amountOfIngredients);
            return Ok(res.dtos);
        }
    }
}
