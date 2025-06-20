using Anotacoes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anotacoes
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarItens();
        }

        private void CarregarItens()
        {
            Lista.Controls.Clear();

            // Exemplo estático de itens
            var titulos = new List<string>
            {
                "Tarefa 1",
                "Anotação importante",
                "Lembrete: Reunião às 15h"
            };

            foreach (var titulo in titulos)
            {
                var item = new RegistroItemControl(titulo);
                item.EditarClick += Item_EditarClick;
                item.ExcluirClick += Item_ExcluirClick;
                Lista.Controls.Add(item);
            }
        }

        private void Item_EditarClick(object sender, EventArgs e)
        {
            if (sender is RegistroItemControl item)
            {
                MessageBox.Show($"Editar: {item.Titulo}");
            }
        }

        private void Item_ExcluirClick(object sender, EventArgs e)
        {
            if (sender is RegistroItemControl item)
            {
                DialogResult result = MessageBox.Show(
                    $"Tem certeza que deseja excluir '{item.Titulo}'?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Lista.Controls.Remove(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string novoTitulo = Prompt.ShowDialog("Digite o título:", "Novo Item");
            //if (!string.IsNullOrWhiteSpace(novoTitulo))
            //{
            //    var item = new RegistroItemControl(novoTitulo);
            //    item.EditarClick += Item_EditarClick;
            //    item.ExcluirClick += Item_ExcluirClick;
            //    Lista.Controls.Add(item);
            //}

            var form = new ModalAdicionarItem();
            form.ShowDialog();
        }
    }

    // Classe auxiliar para caixa de diálogo
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240 };
            Button confirmation = new Button() { Text = "OK", Left = 200, Top = 80, Width = 60, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

