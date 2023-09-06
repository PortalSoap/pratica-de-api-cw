using Microsoft.EntityFrameworkCore;

namespace teste_de_api.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options) : base(options)
        {
            
        }
    }
}
