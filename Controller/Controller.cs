using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.DTOs;
using TaskFlow.Models;
using TaskFlow.Services;

namespace TaskFlow.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        // GET: api/task
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // GET: api/task/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/task
       /* [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }
        */
       [HttpPost]
       public async Task<IActionResult> Create(TaskCreateDto dto)
       {
           var task = _mapper.Map<TaskItem>(dto);
           await _taskService.CreateTaskAsync(task);
           var result = _mapper.Map<TaskReadDto>(task);
           return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
       }


        // PUT: api/task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            if (id != task.Id)
                return BadRequest();

            await _taskService.UpdateTaskAsync(task);
            return NoContent();
        }

        // DELETE: api/task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}