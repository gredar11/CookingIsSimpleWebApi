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
        public RepositoryManager(CisDbContext repositoryConext)
        {
            _foodCategoryRepository = new Lazy<IFoodCategoryRepository>(() => new FoodCategoryRepository(repositoryConext));
            _repositoryConext = repositoryConext;
        }

        public IFoodCategoryRepository FoodCategoryRepository => _foodCategoryRepository.Value;
        public async Task SaveAsync()
        {
            await _repositoryConext.SaveChangesAsync();
        }
    }
}
