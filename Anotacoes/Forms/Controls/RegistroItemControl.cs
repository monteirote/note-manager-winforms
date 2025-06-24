using System;
using System.Collections.Generic;
using System.Drawing;
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

        public RegistroItemControl (string titulo, int id) : this()
        {
            lblTitulo.Text = titulo;
            Id = id;
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTitulo.Location = new System.Drawing.Point(5, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 17);
            this.lblTitulo.TabIndex = 0;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.LightYellow;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditar.Location = new System.Drawing.Point(477, 3);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(195, 34);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.IndianRed;
            this.btnExcluir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExcluir.Location = new System.Drawing.Point(678, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(110, 34);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // RegistroItemControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcluir);
            this.Name = "RegistroItemControl";
            this.Size = new System.Drawing.Size(793, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string Titulo {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value; }
        }

        public int Id { get; set; }

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
