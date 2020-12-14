using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoGerenciadorTarefas.Modelos
{
    public class Tarefa
    {
        public int IdTarefa { get; private set; }

        public string DescricaoTarefa { get; set; }

        public DateTime DataTarefa { get; set; }

        public bool TarefaConcluida { get; set; }
    }
}
