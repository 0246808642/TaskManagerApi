using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Data.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string? Name { get; set; }
        [MaxLength(7)] // Para hex colors como #FF5733 
        public string? Color { get; set; }
    }
}
