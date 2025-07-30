using Reportes;
using SplitBuddies.Presentation;  
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PtoyectoDanielKendall
{
    /// <summary>
    ///    Formulario de inicio de sesión para la aplicación SplitBuddies.
    /// </summary>
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// Conexión a la base de datos.
        /// </summary>
        private readonly string _conn = "Server=.;Database=SplitBuddies;Trusted_Connection=True;";

        public FrmLogin()
        {
            InitializeComponent();
            CargarUsuarios();


            btnLogin.Click += btnLogin_Click;
        }

        private void CargarUsuarios()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT IdUsuario, Nombre FROM Usuario", _conn))
                da.Fill(dt);

            cmbUsuario.DataSource = dt;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedIndex = -1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (cmbUsuario.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un usuario.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingresa la contraseña.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = (int)cmbUsuario.SelectedValue;
            string claveIngresada = txtContrasena.Text.Trim();
            string claveGuardada;


            using (var cn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand(
                "SELECT Contrasena FROM Usuario WHERE IdUsuario = @id", cn))
            {
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cn.Open();
                object result = cmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Usuario no encontrado.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                claveGuardada = result.ToString();
            }


            if (claveGuardada == claveIngresada)
            {

                this.Hide();


                var principal = new frmPrincipal
                {
                    IsMdiContainer = true
                };

                principal.FormClosed += (s, args) => this.Close();

                principal.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new FrmUsuario();
            frm.Show();
        }
    }
}