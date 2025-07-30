// FrmControlGastos.Designer.cs
using System.Windows.Forms;

namespace PtoyectoDanielKendall
{
    partial class FrmControlGastos
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox cmbGrupo;
        private Label label1;
        private DataGridView dgvGastos;
        private Label lblTotal;      // <-- renombrado aquí

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvGastoMesActual = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastoMesActual)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(27, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 530);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.dgvGastos);
            this.tabPage1.Controls.Add(this.cmbGrupo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(959, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gastos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(45, 456);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(181, 32);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total: ₡0.00";
            // 
            // dgvGastos
            // 
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos.Location = new System.Drawing.Point(29, 66);
            this.dgvGastos.Name = "dgvGastos";
            this.dgvGastos.RowHeadersWidth = 51;
            this.dgvGastos.Size = new System.Drawing.Size(900, 358);
            this.dgvGastos.TabIndex = 1;
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(161, 25);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(200, 21);
            this.cmbGrupo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccionar Grupo";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvGastoMesActual);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(959, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mes Actual";
            this.tabPage2.Visible = false;
            // 
            // dgvGastoMesActual
            // 
            this.dgvGastoMesActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastoMesActual.Location = new System.Drawing.Point(34, 36);
            this.dgvGastoMesActual.Name = "dgvGastoMesActual";
            this.dgvGastoMesActual.RowHeadersWidth = 51;
            this.dgvGastoMesActual.Size = new System.Drawing.Size(887, 430);
            this.dgvGastoMesActual.TabIndex = 0;
            // 
            // FrmControlGastos
            // 
            this.ClientSize = new System.Drawing.Size(1021, 554);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmControlGastos";
            this.Text = "Control de Gastos";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastoMesActual)).EndInit();
            this.ResumeLayout(false);

        }

        private TabPage tabPage2;
        private DataGridView dgvGastoMesActual;
    }
}
