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
        private readonly Lazy<IRecipesCategoryRepository> _recipesCategoryRepository;
        public RepositoryManager(CisDbContext repositoryConext)
        {
            _foodCategoryRepository = new Lazy<IFoodCategoryRepository>(() => new FoodCategoryRepository(repositoryConext));
            _ingredientsRepository = new Lazy<IIngreditentRepository>(() => new IngredientsRepository(repositoryConext));
            _recipesCategoryRepository = new Lazy<IRecipesCategoryRepository>(() => new RecipeCategoryRepository(repositoryConext));
            _repositoryConext = repositoryConext;
        }

        public IFoodCategoryRepository FoodCategoryRepository => _foodCategoryRepository.Value;
        public IIngreditentRepository IngreditentRepository => _ingredientsRepository.Value;
        public IRecipesCategoryRepository RecipesCategoryRepository => _recipesCategoryRepository.Value;
        public async Task SaveAsync()
        {
            await _repositoryConext.SaveChangesAsync();
        }
    }
}
