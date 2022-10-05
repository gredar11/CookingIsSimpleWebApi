using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Exceptions
{
    public class FoodCategoryNotFoundException:NotFoundException
    {
        public FoodCategoryNotFoundException(int id):base($"Foodcategory with id = {id} not found in database.")
        {

        }
    }
}
