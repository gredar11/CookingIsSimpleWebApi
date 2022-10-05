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
    public class IngredientService: IIngredientService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public IngredientService(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;
        }
    }
}
