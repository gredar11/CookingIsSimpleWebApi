using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.CreationDto;
using Cis.WebApi.ActionFilters;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System.Text.Json;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("recipecategory")]
    public class RecipeCategoryController : Controller
    {
        IServiceManager serviceManager;
        public RecipeCategoryController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipeCategories([FromQuery] RecipeCategoryParameters requestParameters)
        {
            var entities = await serviceManager.RecipeCategoryService.GetRecipeCategories(requestParameters, trackChanges: false);
            Request.Headers.Add("X-Pagination", JsonSerializer.Serialize(entities.pageMetaData));
            return Ok(entities.recipeCategories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeCategoryById(int id)
        {
            var entity = await serviceManager.RecipeCategoryService.GetRecipeCategoryById(id, trackChanges: false);
            return Ok(entity);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> CreateRecipeCategory([FromBody]RecipeCategoryCreationDto categoryCreationDto)
        {
            var createdDto = await serviceManager.RecipeCategoryService.CreateRecipeCategory(categoryCreationDto);
            return Ok(createdDto);
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterArrtibute))]
        public async Task<IActionResult> UpdateRecipeCategory(int id, [FromBody] RecipeCategoryUpdateDto updateDto)
        {
            await serviceManager.RecipeCategoryService.UpdateRecipeCategory(id, updateDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            await serviceManager.RecipeCategoryService.DeleteRecipeCategory(id);
            return NoContent();
        }
    }
}
