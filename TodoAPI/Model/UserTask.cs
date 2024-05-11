using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Model
{
    public class UserTask
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public UserTask()
        {
            Name = "";
        }
    }
}
