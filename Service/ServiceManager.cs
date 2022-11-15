using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IFoodCategoryService> _foodCategoryService;
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<IRecipeCategoryService> _recipeCategoryService;
        private readonly Lazy<IRecipeService> _recipeService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _foodCategoryService = new Lazy<IFoodCategoryService>(() => new FoodCategoryService(repositoryManager, mapper));
            _ingredientService = new Lazy<IIngredientService>(() => new IngredientService(repositoryManager, mapper));
            _recipeCategoryService = new Lazy<IRecipeCategoryService>(() => new RecipeCategoryService(repositoryManager, mapper));
            _recipeService = new Lazy<IRecipeService>(() => new RecipeService(repositoryManager, mapper));
        }
        public IFoodCategoryService FoodCategoryService => _foodCategoryService.Value;
        public IIngredientService IngredientService => _ingredientService.Value;
        public IRecipeCategoryService RecipeCategoryService => _recipeCategoryService.Value;
        public IRecipeService RecipeService => _recipeService.Value;
    }
}
