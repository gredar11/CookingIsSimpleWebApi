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
        public IActionResult GetAll()
        {
            var allIngredients = repository.GetAllEntities();
            return Ok(allIngredients);
        }
        [HttpGet]
        [Route("/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(repository.GetEntity(id));
        }
        [HttpDelete]
        [Route("/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            repository.RemoveEntity(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Ingredient ingredient)
        {
            repository.AddEntity(ingredient);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] Ingredient ingredient)
        {
            repository.UpdateEntity(ingredient);
            return Ok();
        }
    }
}
