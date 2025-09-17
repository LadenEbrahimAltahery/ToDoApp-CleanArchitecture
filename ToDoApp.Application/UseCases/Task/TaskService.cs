using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Application.UseCases.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> CreateTaskAsync(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Status = dto.Status,
                CategoryId = dto.CategoryId
            };

            await _taskRepository.AddAsync(task);
            return task.Id;
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Select(t => new ResponseTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Status = t.Status,
                CategoryId = t.CategoryId,
                CategoryName = t.Category.Name
            });
        }

        public async Task<ResponseTaskDto?> GetTaskByIdAsync(int id)
        {
            var t = await _taskRepository.GetByIdAsync(id);
            if (t == null) return null;

            return new ResponseTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Status = t.Status,
                CategoryId = t.CategoryId,
                CategoryName = t.Category.Name
            };
        }

        public async Task UpdateTaskAsync(UpdateTaskDto dto)
        {
            var task = await _taskRepository.GetByIdAsync(dto.Id);
            if (task == null) throw new Exception("Task not found");

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.Status = dto.Status;
            task.CategoryId = dto.CategoryId;

            await _taskRepository.UpdateAsync(task);
        }
    }
}
