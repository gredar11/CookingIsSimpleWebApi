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
    public class RecipeCategoryController:Controller
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
        [HttpPost]
        public async Task<IActionResult> CreateRecipeCategory([FromBody]RecipeCategoryCreationDto categoryCreationDto)
        {
            var createdDto = await serviceManager.RecipeCategoryService.CreateRecipeCategory(categoryCreationDto, trackChanges: false);
            return Ok(createdDto);
        }
    }
}
