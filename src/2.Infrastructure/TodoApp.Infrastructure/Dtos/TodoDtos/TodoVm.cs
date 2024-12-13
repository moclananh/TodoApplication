using TodoApp.Domain.Models.Enums;

namespace TodoApp.Infrastructure.Dtos.TodoDtos
{
    public class TodoVm
    {
        public int Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; }
        public int Priority { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Star { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
    }
}
