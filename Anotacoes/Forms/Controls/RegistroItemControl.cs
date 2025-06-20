using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anotacoes {
    public partial class RegistroItemControl : UserControl
    {
        public RegistroItemControl()
        {
            InitializeComponent();
        }

        public RegistroItemControl(string titulo) : this()
        {
            lblTitulo.Text = titulo;
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnEditar = new Button();
            this.btnExcluir = new Button();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(5, 10);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTitulo.Size = new System.Drawing.Size(150, 20);

            // btnEditar
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(200, 5);
            this.btnEditar.Width = 75;
            this.btnEditar.Click += btnEditar_Click;

            // btnExcluir
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new System.Drawing.Point(280, 5);
            this.btnExcluir.Width = 75;
            this.btnExcluir.Click += btnExcluir_Click;
            this.btnExcluir.BackColor = System.Drawing.Color.LightCoral;

            // Configurações do UserControl
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Size = new System.Drawing.Size(360, 35);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public string Titulo {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }

        public event EventHandler EditarClick;
        public event EventHandler ExcluirClick;

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarClick?.Invoke(this, e);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirClick?.Invoke(this, e);
        }

        #region Componentes
        private Label lblTitulo;
        private Button btnEditar;
        private Button btnExcluir;
        #endregion
    }
}
