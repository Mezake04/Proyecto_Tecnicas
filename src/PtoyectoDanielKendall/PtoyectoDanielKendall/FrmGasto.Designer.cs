using System.Windows.Forms;

namespace SplitBuddies.Presentation
{
    partial class FrmGasto
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbGrupo;
        private ComboBox cmbUsuario;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Label lblGrupo;
        private Label lblPagador;
        private Label lblNombre;
        private Label lblMonto;
        private Label lblDescripcion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblPagador = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.Location = new System.Drawing.Point(120, 18);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(200, 21);
            this.cmbGrupo.TabIndex = 1;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Location = new System.Drawing.Point(120, 58);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(200, 21);
            this.cmbUsuario.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 98);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(120, 178);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 60);
            this.txtDescripcion.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(120, 250);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Registrar Gasto";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblGrupo
            // 
            this.lblGrupo.Location = new System.Drawing.Point(20, 20);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(100, 23);
            this.lblGrupo.TabIndex = 0;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblPagador
            // 
            this.lblPagador.Location = new System.Drawing.Point(20, 60);
            this.lblPagador.Name = "lblPagador";
            this.lblPagador.Size = new System.Drawing.Size(100, 23);
            this.lblPagador.TabIndex = 2;
            this.lblPagador.Text = "Pagador:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre Gasto:";
            // 
            // lblMonto
            // 
            this.lblMonto.Location = new System.Drawing.Point(20, 140);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(100, 23);
            this.lblMonto.TabIndex = 6;
            this.lblMonto.Text = "Monto Total:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(20, 180);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(120, 140);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(200, 20);
            this.txtMonto.TabIndex = 11;
            // 
            // FrmGasto
            // 
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.lblPagador);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Name = "FrmGasto";
            this.Text = "Registro de Gastos";
            this.Load += new System.EventHandler(this.FrmGasto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txtMonto;
    }
}
