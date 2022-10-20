using Cis.WebApi.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("/foodcategory/{foodCategoryId}/[controller]")]
    public class IngredientController:Controller
    {
        private readonly IServiceManager _serviceManager;
        public IngredientController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIngredientsByFoodCategory(int foodCategoryId, [FromQuery] IngredientParameters ingredientParameters)
        {
            var result = await _serviceManager.IngredientService.GetAllIngredientsFromFoodCategory(foodCategoryId, ingredientParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Item2));
            return Ok(result.Item1);
        }
        [HttpGet("{id}", Name = "GetIngredientByFoodCategory")]
        public async Task<IActionResult> GetIngredientByFoodCategory(int foodCategoryId, int id)
        {
            var res = await _serviceManager.IngredientService.GetIngredientFromFoodCategoryById(foodCategoryId, id, trackChanges: false);
            return Ok(res);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> CreateIngredient(int foodCategoryId, [FromBody] IngredientForCreationDto creationDto)
        {
            var res = await _serviceManager.IngredientService.CreateIngredientForCategory(foodCategoryId, creationDto, trackChanges: false);
            return CreatedAtRoute("GetIngredientByFoodCategory", new { foodCategoryId = foodCategoryId, id = res.Id }, res);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> UpdateIngredient(int foodCategoryId, int id, [FromBody] IngredientForUpdateDto updateDto)
        {
            await _serviceManager.IngredientService.UpdateIngredientForCategory(foodCategoryId, id, updateDto, trackChanges: false);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int foodCategoryId, int id)
        {
            await _serviceManager.IngredientService.DeleteIngredient(foodCategoryId, id, trackChanges: false);
            return NoContent();
        }
    }
}
