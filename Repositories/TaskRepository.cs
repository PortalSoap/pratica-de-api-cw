using Microsoft.EntityFrameworkCore;
using teste_de_api.Data;
using teste_de_api.Models;
using teste_de_api.Repositories.Interfaces;

namespace teste_de_api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.Include(x => x.User).ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await _dbContext.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel target = await GetById(id);

            if(target == null)
            {
                throw new Exception($"ID de Tarefa: {id} não foi encontrado.");
            }

            target.Name = task.Name;
            target.Description = task.Description;
            target.Status = task.Status;
            target.UserId = task.UserId;

            _dbContext.Tasks.Update(target);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel target = await GetById(id);

            if(target == null)
            {
                throw new Exception($"Id de Tarefa: {id} não foi encontrado.");
            }

            _dbContext.Tasks.Remove(target);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
