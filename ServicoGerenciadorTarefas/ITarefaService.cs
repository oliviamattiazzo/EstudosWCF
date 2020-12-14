using ServicoGerenciadorTarefas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicoGerenciadorTarefas
{
    [ServiceContract]
    public interface ITarefaService
    {
        [OperationContract]
        void Add(Tarefa tarefa);

        [OperationContract]
        void Finish(int idTarefa);

        [OperationContract]
        void Reopen(int idTarefa);

        [OperationContract]
        List<Tarefa> GetTarefasAbertas();

        [OperationContract]
        List<Tarefa> GetTarefasConcluidas();
    }
}
