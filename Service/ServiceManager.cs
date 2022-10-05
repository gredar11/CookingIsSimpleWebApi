using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFoodCategoryService> _foodCategoryService;
        private readonly Lazy<IIngredientService> _ingredientService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _foodCategoryService = new Lazy<IFoodCategoryService>(() => new FoodCategoryService(repositoryManager, mapper));
            _ingredientService = new Lazy<IIngredientService>(() => new IngredientService(repositoryManager, mapper));
        }
        public IFoodCategoryService FoodCategoryService => _foodCategoryService.Value;
        public IIngredientService IngredientService => _ingredientService.Value;
    }
}
