
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

/// <summary>
/// Declara la clase del formulario FrmControlGastos y la conexión a la base de datos.
namespace PtoyectoDanielKendall
{
    public partial class FrmControlGastos : Form
    {
        private readonly string _conn = "Server=.;Database=SplitBuddies;Trusted_Connection=True;";

        public FrmControlGastos()
        {
            InitializeComponent();
            CargarGrupos();
            cmbGrupo.SelectionChangeCommitted += cmbGrupo_SelectionChangeCommitted;
        }

        private void CargarGrupos()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT IdGrupo, Nombre FROM Grupo", _conn))
                da.Fill(dt);

            cmbGrupo.DataSource = dt;
            cmbGrupo.DisplayMember = "Nombre";
            cmbGrupo.ValueMember = "IdGrupo";
            cmbGrupo.SelectedIndex = -1;
        }

        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedIndex < 0)
            {
                dgvGastos.DataSource = null;
                lblTotal.Text = "Total: ₡0.00";
                return;
            }
            /// Obtiene el ID del grupo seleccionado y carga los gastos asociados a ese grupo.
            int grupoId = (int)cmbGrupo.SelectedValue;
            var dt = new DataTable();
            using (var da = new SqlDataAdapter(
                "SELECT * FROM Gasto WHERE IdGrupo = @g",
                _conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@g", grupoId);
                da.Fill(dt);
            }

            dgvGastos.DataSource = dt;

            /// Calcula el total.
            decimal suma = 0m;
            foreach (DataRow row in dt.Rows)
            {
                if (row["MontoTotal"] != DBNull.Value)
                    suma += Convert.ToDecimal(row["MontoTotal"]);
            }

            lblTotal.Text = $"Total: ₡{suma:N2}";


            dgvGastoMesActual.DataSource = dt;

        }
    }
}
