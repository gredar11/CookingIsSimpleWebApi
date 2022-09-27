using AutoMapper;
using Cis.Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.WebApi.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodCategory, FoodCategoryDto>();
        }
    }
}
