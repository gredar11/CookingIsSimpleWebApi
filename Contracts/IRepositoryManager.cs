using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IFoodCategoryRepository FoodCategoryRepository { get; }
        IIngreditentRepository IngreditentRepository { get; }
        IRecipesCategoryRepository RecipesCategoryRepository { get; }
        Task SaveAsync();

    }
}
