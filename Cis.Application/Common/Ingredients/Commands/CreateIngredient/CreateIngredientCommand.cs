using Cis.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Application.Common.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public FoodCategory Category { get; set; }
    }
}
