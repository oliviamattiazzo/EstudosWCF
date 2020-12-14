using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicoGerenciadorTarefas.DAOs;
using ServicoGerenciadorTarefas.Modelos;

namespace ServicoGerenciadorTarefas
{
    public class TarefaService : ITarefaService
    {
        public void Add(Tarefa tarefa)
        {
            TarefasDAO dao = new TarefasDAO();
            dao.Adicionar(tarefa);
        }

        public void Finish(int idTarefa)
        {
            TarefasDAO dao = new TarefasDAO();
            dao.Finalizar(idTarefa);
        }

        public List<Tarefa> GetTarefasAbertas()
        {
            return TarefasDAO.lstTarefas.Where(p => p.TarefaConcluida == false).ToList();
        }

        public List<Tarefa> GetTarefasConcluidas()
        {
            return TarefasDAO.lstTarefas.Where(p => p.TarefaConcluida == true).ToList();
        }

        public void Reopen(int idTarefa)
        {
            TarefasDAO dao = new TarefasDAO();
            dao.Reabrir(idTarefa);
        }
    }
}
