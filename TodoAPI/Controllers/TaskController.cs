using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Dto;
using TodoAPI.Model;
using TodoAPI.Repository.Interface;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskController(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTaskAsync([FromBody]TaskDto taskDto)
        {
            var newTask = _mapper.Map<UserTask>(taskDto);
            newTask = await _taskRepository.CreateTaskAsync(newTask);
            return Ok(newTask);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var currentTasks = await _taskRepository.GetAllTasksAsync();
            return Ok(_mapper.Map<List<UserTask>>(currentTasks));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] Guid id)
        {
            var deleteTask = await _taskRepository.DeleteTaskAsync(id);

            if(deleteTask == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDto>(deleteTask));
        }
    }
}
