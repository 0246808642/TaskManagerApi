using System.ComponentModel.DataAnnotations;
using TaskManagerApi.Models.Enums;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data.Dtos.TaskOnDto
{
    public class UpdateTaskDto
    {
 
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string Title { get; set; }
        [MaxLength(600)]
        public string? Descripption { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public TaskStatusOn Status { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
    }
}
