using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SplitBuddies.Presentation
{
    public partial class FrmGasto : Form
    {
        private readonly string _conn = "Server=.;Database=SplitBuddies;Trusted_Connection=True;";

        public FrmGasto()
        {
            InitializeComponent();
            CargarGrupos();
            CargarUsuarios();
            cmbGrupo.SelectionChangeCommitted += cmbGrupo_SelectionChangeCommitted;
        }

        private void CargarGrupos()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT IdGrupo, Nombre FROM Grupo", _conn))
            {
                da.Fill(dt);
            }
            cmbGrupo.DataSource = dt;
            cmbGrupo.DisplayMember = "Nombre";
            cmbGrupo.ValueMember = "IdGrupo";
            cmbGrupo.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT IdUsuario, Nombre FROM Usuario", _conn))
            {
                da.Fill(dt);
            }
            cmbUsuario.DataSource = dt;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedIndex = -1;
        }



        private void cmbGrupo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedIndex < 0)
            {
                cmbUsuario.DataSource = null;
                return;
            }

            int grupoId = (int)cmbGrupo.SelectedValue;
            var dt = new DataTable();
            using (var da = new SqlDataAdapter(
                "SELECT IdUsuario, Nombre FROM Usuario WHERE Grupo = @g",
                _conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@g", grupoId);
                da.Fill(dt);
            }

            cmbUsuario.DataSource = dt;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedIndex = -1;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal total = Convert.ToDecimal(txtMonto.Text);
            int grupo = (int)cmbGrupo.SelectedValue;
            int pagador = (int)cmbUsuario.SelectedValue;
            string nombre = txtNombre.Text;
            string desc = txtDescripcion.Text;
            /// Insertar el gasto en la base de datos:
            using (var cn = new SqlConnection(_conn))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {

                    int idGasto;
                    using (var cmd = new SqlCommand(
                        "INSERT INTO Gasto (Nombre, Descripcion, Enlace, MontoTotal, IdUsuarioPago, IdGrupo) " +
                        "VALUES (@n, @d, @e, @m, @p, @g); SELECT SCOPE_IDENTITY()",
                        cn, tran))
                    {
                        cmd.Parameters.AddWithValue("@n", nombre);
                        cmd.Parameters.AddWithValue("@d", desc);
                        cmd.Parameters.AddWithValue("@e", DBNull.Value);
                        cmd.Parameters.AddWithValue("@m", total);
                        cmd.Parameters.AddWithValue("@p", pagador);
                        cmd.Parameters.AddWithValue("@g", grupo);
                        idGasto = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    
                    tran.Commit();
                }
            }

            MessageBox.Show("Gasto registrado con éxito.");
        }

        private void FrmGasto_Load(object sender, EventArgs e)
        {

        }
    }
}
