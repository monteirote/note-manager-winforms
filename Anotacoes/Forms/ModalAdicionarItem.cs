using Anotacoes.Database.Models;
using Anotacoes.Database.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anotacoes.Forms
{
    public partial class ModalAdicionarItem : Form
    {

        private FormPrincipal _formPrincipal;
        private int? Id;

        public ModalAdicionarItem (FormPrincipal form, int? _id = null)
        {
            _formPrincipal = form;
            Id = _id;
            InitializeComponent();
            PreencherCampos();
        }

        private void button2_Click(object sender, EventArgs e) {

            var item = new Registro {
                Id = Id ?? 0,
                Name = textBox1.Text,
                Comment = richTextBox1.Text
            };

            this._formPrincipal.AdicionarItem(item);
            this.Close();
        }
            
        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void PreencherCampos () {
            if (Id == null) return;

            var registro = RegistroRepository.BuscarRegistroPorID(Id.Value);

            textBox1.Text = registro.Name;
            richTextBox1.Text = registro.Comment;
        }
    }
}
