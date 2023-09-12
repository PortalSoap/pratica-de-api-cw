using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste_de_api.Models;
using teste_de_api.Repositories.Interfaces;

namespace teste_de_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetById(int id)
        {
            TaskModel task = await _taskRepository.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Add([FromBody]TaskModel newTask)
        {
            TaskModel task = await _taskRepository.Add(newTask);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel newTask, int id)
        {
            newTask.Id = id;
            TaskModel task = await _taskRepository.Update(newTask, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _taskRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
