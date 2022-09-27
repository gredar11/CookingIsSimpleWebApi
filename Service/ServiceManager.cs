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
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _foodCategoryService = new Lazy<IFoodCategoryService>(() => new FoodCategoryService(repositoryManager, mapper));
        }
        public IFoodCategoryService FoodCategoryService => _foodCategoryService.Value;
    }
}
