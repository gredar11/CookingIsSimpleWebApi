using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.CreationDto;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("/recipecategory/{categoryId}/recipe")]
    public class RecipeController:Controller
    {
        private readonly IServiceManager _serviceManager;
        public RecipeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(int categoryId, [FromBody]RecipeCreationDto creationDto)
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
            var res = await _serviceManager.RecipeService.AddIngredientToRecipe(recipeId, ingredientId, addingDto, trackChanges: false);
            return Ok(res);
        }
        [HttpGet("{recipeId}/ingredient/")]
        public async Task<IActionResult> GetIngredientsOfRecipe(int categoryId, int recipeId)
        {
            var res = await _serviceManager.RecipeService.GetIngredientsFromRecipe(recipeId, trackChanges: false);
            return Ok(res);
        }
    }
}
