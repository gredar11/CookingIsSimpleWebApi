using Cis.Domain.Models;
using Cis.Persistance.Repositories;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly CisDbContext _repositoryConext;
        private readonly Lazy<IFoodCategoryRepository> _foodCategoryRepository;
        private readonly Lazy<IIngreditentRepository> _ingredientsRepository;
        public RepositoryManager(CisDbContext repositoryConext)
        {
            _foodCategoryRepository = new Lazy<IFoodCategoryRepository>(() => new FoodCategoryRepository(repositoryConext));
            _ingredientsRepository = new Lazy<IIngreditentRepository>(() => new IngredientsRepository(repositoryConext));
            _repositoryConext = repositoryConext;
        }

        public IFoodCategoryRepository FoodCategoryRepository => _foodCategoryRepository.Value;
        public IIngreditentRepository IngreditentRepository => _ingredientsRepository.Value;
        public async Task SaveAsync()
        {
            await _repositoryConext.SaveChangesAsync();
        }
    }
}
