using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Application.Common.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, int>
    {
        public Task<int> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
