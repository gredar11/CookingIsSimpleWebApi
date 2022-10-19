using Shared.GetResponseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record FoodCategoryForUpdateDto
    {
        [Required(ErrorMessage = $"{nameof(FoodCategoryDto.NameOfCategory)} is required field.")]
        [MaxLength(50)]
        public string NameOfCategory { get; init; }
        [Required]
        public string Description { get; init; }
        
    }
}
