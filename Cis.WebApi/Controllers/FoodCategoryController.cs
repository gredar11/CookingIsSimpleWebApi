using Cis.WebApi.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CreationDto;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System.Text.Json;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class FoodCategoryController : Controller
    {
        private readonly IServiceManager serviceManager;
        public FoodCategoryController(IServiceManager service)
        {
            this.serviceManager = service;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> CreateFoodCategory([FromBody] FoodCategoryForCreationDto creationDto)
        {
            var res = await serviceManager.FoodCategoryService.CreateFoodCategory(creationDto);
            return CreatedAtRoute("GetFoodCategoryById", new { res.Id }, res);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FoodCategoryParameters requestParameters)
        {
            var allFoodCategories = await serviceManager.FoodCategoryService.GetFoodCategories(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(allFoodCategories.metaData));
            return Ok(allFoodCategories.dtos);
        }

        [HttpGet("{id}", Name = "GetFoodCategoryById")]
        public async Task<IActionResult> GetFoodCategoryById(int id)
        {
            var result = await serviceManager.FoodCategoryService.GetFoodCategoryById(id, trackChanges: false);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> UpdateFoodCategory(int id, [FromBody] FoodCategoryForUpdateDto updateDto)
        {
            await serviceManager.FoodCategoryService.UpdateFoodCategory(id, updateDto, trackChanges: true);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            await serviceManager.FoodCategoryService.DeleteFoodCategory(id, trackChanges: true);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateFoodCategory(int id, [FromBody] JsonPatchDocument<FoodCategoryForUpdateDto> patchDocument)
        {
            if (patchDocument is null)
                return BadRequest("patch document sent from client is null");
            var res = await serviceManager.FoodCategoryService.GetFoodCategoryForPatch(id, trackChanges: true);
            patchDocument.ApplyTo(res.foodCategoryToPatch);
            await serviceManager.FoodCategoryService.SaveChangesForPatch(res.foodCategoryToPatch, res.foodCategoryEntity);
            return NoContent();
        }
    }
}
