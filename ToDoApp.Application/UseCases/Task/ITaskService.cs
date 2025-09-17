using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Entities;
namespace ToDoApp.Application.UseCases.Tasks
{
    public interface ITaskService
    {
        Task<IEnumerable<ResponseTaskDto>> GetAllTasksAsync();
        Task<ResponseTaskDto?> GetTaskByIdAsync(int id);
        Task<int> CreateTaskAsync(CreateTaskDto task);
        Task UpdateTaskAsync(UpdateTaskDto task);
        Task DeleteTaskAsync(int id);
    }
}

