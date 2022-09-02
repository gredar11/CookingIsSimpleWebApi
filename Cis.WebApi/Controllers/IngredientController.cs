using Cis.Domain.Models;
using Cis.Persistance;
using Cis.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.WebApi.Controllers
{
    [Route("/[controller]")]
    public class IngredientController : Controller
    {
        private readonly IngredientsRepository repository;
        public IngredientController(IngredientsRepository cisDb)
        {
            repository = cisDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allIngredients = await repository.GetAllEntities();
            return Ok(allIngredients);
        }
        [HttpGet]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await repository.GetEntity(id);
            ViewBag.Ingredient = res;
            return Ok(res);
        }
        [HttpDelete]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.RemoveEntity(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Ingredient ingredient)
        {
            var idOfEntity = await repository.AddEntity(ingredient);
            return Ok(idOfEntity);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Ingredient ingredient)
        {
            await repository.UpdateEntity(ingredient);
            return Ok();
        }
        public ViewResult GetModelView()
        {

            return View("Index");
        }
    }
}
