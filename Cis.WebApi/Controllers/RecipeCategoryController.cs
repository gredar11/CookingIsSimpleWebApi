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
    [Route("recipecategory")]
    public class RecipeCategoryController : Controller
    {
        IServiceManager serviceManager;
        public RecipeCategoryController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipeCategories()
        {
            var allEntities = await serviceManager.RecipeCategoryService.GetAllRecipeCategories(trackChanges: false);
            return Ok(allEntities);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeCategoryById(int id)
        {
            var entity = await serviceManager.RecipeCategoryService.GetRecipeCategoryById(id, trackChanges: false);
            return Ok(entity);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipeCategory([FromBody]RecipeCategoryCreationDto categoryCreationDto)
        {
            var createdDto = await serviceManager.RecipeCategoryService.CreateRecipeCategory(categoryCreationDto);
            return Ok(createdDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeCategory(int id)
        {
            await serviceManager.RecipeCategoryService.DeleteRecipeCategory(id);
            return NoContent();
        }
    }
}
