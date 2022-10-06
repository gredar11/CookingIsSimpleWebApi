using Cis.Domain.Models;
using Cis.Persistance.Repositories;
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
    [Route("/[controller]")]
    public class FoodCategoryController: Controller
    {
        private readonly IServiceManager serviceManager;
        public FoodCategoryController(IServiceManager service)
        {
            this.serviceManager = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allFoodCategories = await serviceManager.FoodCategoryService.GetFoodCategories(trackChanges:false);
            return Ok(allFoodCategories);
        }

        [HttpGet("{id}", Name = "GetFoodCategoryById")]
        public async Task<IActionResult> GetFoodCategoryById(int id)
        {
            var result = await serviceManager.FoodCategoryService.GetFoodCategoryById(id, trackChanges: false);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFoodCategory([FromBody] FoodCategoryForCreationDto creationDto)
        {
            if (creationDto == null)
                return BadRequest("FoodCategory dto is empty..");
            var res = await serviceManager.FoodCategoryService.CreateFoodCategory(creationDto);
            return CreatedAtRoute("GetFoodCategoryById", new {res.Id}, res);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodCategory(int id, [FromBody] FoodCategoryForUpdateDto updateDto)
        {
            if (updateDto == null)
                return BadRequest("Dto is null");
            await serviceManager.FoodCategoryService.UpdateFoodCategory(id, updateDto, trackChanges: true);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            await serviceManager.FoodCategoryService.DeleteFoodCategory(id, trackChanges: true);
            return NoContent();
        }
    }
}
