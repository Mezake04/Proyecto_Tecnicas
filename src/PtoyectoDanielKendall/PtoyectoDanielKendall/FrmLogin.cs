using Reportes;
using SplitBuddies.Presentation;  
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PtoyectoDanielKendall
{
    public partial class FrmLogin : Form
    {
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
            // 1) Aca hago las Validaciones del nombre usuario
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

            // 2) Aca revisa la contraseña contra la base de datos
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

            // 3) Ente lado revida la contraseña
            if (claveGuardada == claveIngresada)
            {
                // Ocultamos este login
                this.Hide();

                // Se redifique la from rpincipal que yo lo llamo contenedor
                var principal = new frmPrincipal
                {
                    IsMdiContainer = true
                };
                // Cuando cierre el frmlogon, que se me cierre el login
                principal.FormClosed += (s, args) => this.Close();
                // Mostramos el principal
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