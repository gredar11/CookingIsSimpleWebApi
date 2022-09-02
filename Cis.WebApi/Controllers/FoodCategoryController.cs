using Cis.Domain.Models;
using Cis.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
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
        private readonly FoodCategoryRepository _foodCategoryRepository;
        public FoodCategoryController(FoodCategoryRepository foodCategoryRepository)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allFoodCategorys = await _foodCategoryRepository.GetAllEntities();
            return Ok(allFoodCategorys);
        }
        [HttpGet]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _foodCategoryRepository.GetEntity(id);
            ViewBag.FoodCategory = res;
            return Ok(res);
        }
        [HttpDelete]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _foodCategoryRepository.RemoveEntity(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FoodCategory ingredient)
        {
            var idOfEntity = await _foodCategoryRepository.AddEntity(ingredient);
            return Ok(idOfEntity);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FoodCategory ingredient)
        {
            await _foodCategoryRepository.UpdateEntity(ingredient);
            return Ok();
        }
        public async Task<IActionResult> AddCategoryToIngredient([FromBody] FoodCategory ingredient)
        {
            
            await _foodCategoryRepository.UpdateEntity(ingredient);
            return Ok();
        }
    }
}
