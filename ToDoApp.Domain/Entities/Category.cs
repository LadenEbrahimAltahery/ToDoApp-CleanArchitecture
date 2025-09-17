using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
