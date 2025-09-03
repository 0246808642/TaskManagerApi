namespace TaskManagerApi.Data.Dtos.TaskOnDto
{
    public class TaskReadDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Descripption { get; set; }
        public DateTime DeadLine { get; set; }
        public string DeadLineFormatada => DeadLine.ToString("dd/MM/ yyyy : HH:mm");
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtFormatada => CreatedAt.ToString("dd/MM/yyyy HH:mm");
        public DateTime? CompletedAt { get; set; }
        public string? CompletedAtFormatada =>
          CompletedAt.HasValue ? CompletedAt.Value.ToString("dd/MM/yyyy HH:mm") : null;

    }
}
