using Anotacoes.Database.Models;
using Anotacoes.Database.Repositories;
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
    public partial class FormPrincipal : Form {

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarItens();
        }

        private void CarregarItens()
        {
            Lista.Controls.Clear();

            var registros = RegistroRepository.BuscarRegistros();

            foreach (var registro in registros) {
                var item = new RegistroItemControl(registro.Name, registro.Id);
                item.EditarClick += Item_EditarClick;
                item.ExcluirClick += Item_ExcluirClick;
                Lista.Controls.Add(item);
            }
        }

        private void Item_EditarClick(object sender, EventArgs e) {
            if (sender is RegistroItemControl item) {

                var formEditar = new ModalAdicionarItem(this, item.Id);
                formEditar.Show();
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
                    RegistroRepository.ApagarRegistro(item.Id);
                    Lista.Controls.Remove(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {

            var form = new ModalAdicionarItem(this);
            form.ShowDialog();
        }

        public void AdicionarItem (Registro registro) {

            if (registro.Id == 0) {
                RegistroRepository.AdicionarRegistro(registro);
            } else {
                RegistroRepository.AtualizarRegistro(registro);
            }

            CarregarItens();

        }
    }
}

