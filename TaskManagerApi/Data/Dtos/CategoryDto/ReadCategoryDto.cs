using TaskManagerApi.Data.Dtos.TaskOnDto;

namespace TaskManagerApi.Data.Dtos.CategoryDto
{
    public class ReadCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        public DateTime LastView { get; set; } = DateTime.Now;

        public List<TaskReadDto> Tasks { get; set; }

    }
}
