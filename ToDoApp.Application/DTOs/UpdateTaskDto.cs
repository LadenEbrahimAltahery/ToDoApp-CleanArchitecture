using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public taskStatus Status { get; set; }
        public int CategoryId { get; set; }
    }
}
