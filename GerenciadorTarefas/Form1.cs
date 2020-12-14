using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorTarefas.ServicoGerenciadorTarefas;

namespace GerenciadorTarefas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCamposEntrada();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                TarefaServiceClient servico = new TarefaServiceClient();

                Tarefa novaTarefa = new Tarefa();
                novaTarefa.DescricaoTarefa = txtTarefa.Text;
                novaTarefa.DataTarefa = DateTime.Parse(txtCalendario.Text);
                novaTarefa.TarefaConcluida = false;

                servico.Add(novaTarefa);

                MessageBox.Show($"Tarefa inserida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);

                AtualizaListaTarefasPendentes();
                LimpaCamposEntrada();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizaListaTarefasPendentes()
        {
            TarefaServiceClient servico = new TarefaServiceClient();
            List<Tarefa> tarefasPendentes = new List<Tarefa>();

            tarefasPendentes = servico.GetTarefasAbertas().ToList();

            tarefasPendentes.ForEach(p => {
                lstPendentes.Items.Add($"{p.DataTarefa.ToShortDateString()} - {p.DescricaoTarefa}");
            });
        }

        private void LimpaCamposEntrada()
        {
            txtTarefa.Text = string.Empty;
            txtCalendario.Text = DateTime.Today.ToShortDateString();
        }

        private void lstPendentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tarefa tarefa = new Tarefa();
            
        }
    }
}
