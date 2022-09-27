using Cis.Domain.Models;
using Cis.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
            var allFoodCategorys = await serviceManager.FoodCategoryService.GetFoodCategories();
            return Ok(allFoodCategorys);
        }
        
    }
}
