using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.UseCases.Tasks;

namespace ToDoApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseTaskDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTaskDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _taskService.CreateTaskAsync(dto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            await _taskService.UpdateTaskAsync(dto);
            return NoContent();
        }
    }
}
