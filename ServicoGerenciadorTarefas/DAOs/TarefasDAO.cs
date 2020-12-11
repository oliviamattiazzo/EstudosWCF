using ServicoGerenciadorTarefas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoGerenciadorTarefas.DAOs
{
    public class TarefasDAO
    {
        public List<Tarefa> lstTarefas = new List<Tarefa>();

        public void Adicionar(Tarefa novaTarefa)
        {
            int proximoId = lstTarefas.LastOrDefault() == null ? 1 : lstTarefas.Last().IdTarefa + 1;

            lstTarefas.Add(novaTarefa);
        }

        public void Finalizar(int idTarefa)
        {
            Tarefa tarefaAlterar = lstTarefas.FirstOrDefault(p => p.IdTarefa == idTarefa);

            lstTarefas.Remove(tarefaAlterar);
            tarefaAlterar.TarefaConcluida = true;
            lstTarefas.Add(tarefaAlterar);
        }

        public void Reabrir(int idTarefa)
        {
            Tarefa tarefaAlterar = lstTarefas.First(p => p.IdTarefa == idTarefa);

            lstTarefas.Remove(tarefaAlterar);
            tarefaAlterar.TarefaConcluida = false;
            lstTarefas.Add(tarefaAlterar);
        }
    }
}
