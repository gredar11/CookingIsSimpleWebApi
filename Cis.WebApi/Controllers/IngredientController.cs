using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.WebApi.Controllers
{
    [ApiController]
    [Route("/{foodCategoryId}/[controller]")]
    public class IngredientController:Controller
    {
        private readonly IServiceManager _serviceManager;
        public IngredientController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIngredientsByFoodCategory(int foodCategoryId)
        {
            var result = await _serviceManager.IngredientService.GetIngredientsByFoodCategory(foodCategoryId, trackChanges: false);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientByFoodCategory(int foodCategoryId, int id)
        {
            var res = await _serviceManager.IngredientService.GetIngredientByCategory(foodCategoryId, id, trackChanges: false);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> CreateIngredient(int foodCategoryId, [FromBody] IngredientForCreationDto creationDto)
        {
            var res = await _serviceManager.IngredientService.CreateIngredientForCategory(foodCategoryId, creationDto, trackChanges: false);
            return CreatedAtRoute(nameof(GetIngredientByFoodCategory), new { foodCategoryId = foodCategoryId, id = res.Id }, res);
        }
    }
}
