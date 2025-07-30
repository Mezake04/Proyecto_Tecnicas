using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SplitBuddies.Presentation
{
    /// <summary>
    /// Validaciones normales.
    /// </summary>
    public partial class FrmUsuario : Form
    {
        private readonly string _conn = "Server=.;Database=SplitBuddies;Trusted_Connection=True;";

        public FrmUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarGrupos();
        }

        private void CargarUsuarios()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT * FROM Usuario", _conn))
            {
                da.Fill(dt);
            }
            dgvUsuarios.DataSource = dt;
        }

        private void CargarGrupos()
        {

            var dt = new DataTable();
            using (var da = new SqlDataAdapter(
                "SELECT IdGrupo, Nombre FROM Grupo",
                _conn))
            {
                da.Fill(dt);
            }

      
            cmbGrupo.DataSource = dt;
            cmbGrupo.ValueMember = "IdGrupo";  
            cmbGrupo.DisplayMember = "Nombre";   
            cmbGrupo.SelectedIndex = -1;
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ///Aqui se agregan los usuarios a la base de datos:
            if (cmbGrupo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor selecciona un grupo.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var cn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(
                "INSERT INTO Usuario (Nombre, Cedula, Email, Grupo, Contrasena) " +
                "VALUES (@n, @c, @e, @g, @p)", cn))
            {
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@c", txtCedula.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);


                int idGrupo = Convert.ToInt32(cmbGrupo.SelectedValue);
                cmd.Parameters.AddWithValue("@g", idGrupo);

                cmd.Parameters.AddWithValue("@p", txtContrasena.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarUsuarios();
            txtNombre.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtContrasena.Clear();
            cmbGrupo.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}