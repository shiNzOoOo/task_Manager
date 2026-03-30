using Microsoft.AspNetCore.Mvc;
using TMS.Api.Models;
using TMS.Api.Services;

namespace TMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var createdTask = await _service.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedTask = await _service.UpdateTaskAsync(id, task);
            if (updatedTask == null) return NotFound();

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteTaskAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
