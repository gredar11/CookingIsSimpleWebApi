using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FoodCategoryService:IFoodCategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public FoodCategoryService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FoodCategoryDto>> GetFoodCategories()
        {
            try
            {
                var foodCategories = await _repository.FoodCategoryRepository.GetFoodCategories();
                var foodCategoryDtos = _mapper.Map<IEnumerable<FoodCategoryDto>>(foodCategories);
                return foodCategoryDtos;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
