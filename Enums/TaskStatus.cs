using System.ComponentModel;

namespace teste_de_api.Enums
{
    public enum TaskStatus
    {
        [Description("À Fazer")]
        ToDo = 1,
        [Description("Em Progresso")]
        InProgress = 2,
        [Description("Concluído")]
        Concluded = 3
    }
}
