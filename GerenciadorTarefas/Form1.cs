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

            lstPendentes.Items.Clear();
            tarefasPendentes.ForEach(p =>
            {
                lstPendentes.Items.Add(RetornaItemListaFormatado(p.IdTarefa, p.DataTarefa, p.DescricaoTarefa));
            });
        }

        private void LimpaCamposEntrada()
        {
            txtTarefa.Text = string.Empty;
            txtCalendario.Text = DateTime.Today.ToShortDateString();
        }

        private void lstPendentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TarefaServiceClient servico = new TarefaServiceClient();

                CheckedListBox lstTarefas = (CheckedListBox)sender;
                string selectedIndex = lstTarefas.SelectedItem.ToString();

                int idTarefa = int.Parse(selectedIndex.Split(':')[0].Remove(0, 1)) - 1;

                servico.Finish(idTarefa);

                MessageBox.Show($"Tarefa concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);

                AtualizaListaTarefasConcluidas();
                AtualizaListaTarefasPendentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RetornaItemListaFormatado(int idTarefa, DateTime dtTarefa, string descricaoTarefa)
        {
            return $"#{idTarefa + 1}: {dtTarefa.ToShortDateString()} - {descricaoTarefa}";
        }

        private void AtualizaListaTarefasConcluidas()
        {
            TarefaServiceClient servico = new TarefaServiceClient();
            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            tarefasConcluidas = servico.GetTarefasConcluidas().ToList();

            lstConcluidas.Items.Clear();
            tarefasConcluidas.ForEach(p =>
            {
                lstConcluidas.Items.Add(RetornaItemListaFormatado(p.IdTarefa, p.DataTarefa, p.DescricaoTarefa), true);
            });
        }

        private void lstConcluidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TarefaServiceClient servico = new TarefaServiceClient();

                CheckedListBox lstTarefas = (CheckedListBox)sender;
                string selectedIndex = lstTarefas.SelectedItem.ToString();

                int idTarefa = int.Parse(selectedIndex.Split(':')[0].Remove(0, 1)) - 1;

                servico.Reopen(idTarefa);

                MessageBox.Show($"Tarefa reaberta com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);

                AtualizaListaTarefasPendentes();
                AtualizaListaTarefasConcluidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}