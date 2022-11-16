using WebApi.ActionFilters;
using WebApi.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/foodcategory/{foodCategoryId}/[controller]")]
    public class IngredientController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public IngredientController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> CreateIngredient(int foodCategoryId, [FromBody] IngredientForCreationDto creationDto)
        {
            var res = await _serviceManager.IngredientService.CreateIngredientForCategory(foodCategoryId, creationDto, trackChanges: false);
            return CreatedAtRoute("GetIngredientByFoodCategory", new { foodCategoryId = foodCategoryId, id = res.Id }, res);
        }
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCollectionForFoodCategory(int foodCategoryId, [FromBody] IEnumerable<IngredientForCreationDto> creationDtos)
        {
            var result = await _serviceManager.IngredientService.CreateCollectionOfIngredients(foodCategoryId, creationDtos);
            return CreatedAtRoute("IngredientCollection", new { foodCategoryId = foodCategoryId, result.ids }, result.ingredients);
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

        [HttpGet("collection/({ids})", Name = "IngredientCollection")]
        public async Task<IActionResult> GetIngredientCollection(int foodCategoryId, [ModelBinder(binderType: typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var companies = await _serviceManager.IngredientService.GetByIds(foodCategoryId, ids, trackChanges: false);
            return Ok(companies);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> UpdateIngredient(int foodCategoryId, int id, [FromBody] IngredientForUpdateDto updateDto)
        {
            await _serviceManager.IngredientService.UpdateIngredientForCategory(foodCategoryId, id, updateDto, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateIngredient(int foodCategoryId, int id, [FromBody] JsonPatchDocument<IngredientForUpdateDto> document)
        {
            if (document is null)
                return BadRequest("patch document is empty");
            var res = await _serviceManager.IngredientService.PartiallyUpdateIngredient(foodCategoryId, id, trackChanges: true);
            document.ApplyTo(res.updateDto);
            await _serviceManager.IngredientService.SavePatchChanges(res.updateDto, res.entity);
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
