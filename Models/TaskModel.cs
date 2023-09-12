namespace teste_de_api.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public TaskStatus Status { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }
}
