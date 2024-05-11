using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Dto
{
    public class TaskDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public TaskDto()
        {
            Name = "";
        }
    }
}
