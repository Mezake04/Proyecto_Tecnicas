using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*Declaración del formulario:*/
namespace SplitBuddies.Presentation
{
    /// <summary>
    /// Constructor del formulario:
    /// </summary> 
    public partial class FrmGrupo : Form
    {
        private readonly string _conn = "Server=.;Database=SplitBuddies;Trusted_Connection=True;";


        /// <summary>
        /// 
        /// </summary> 
        public FrmGrupo()
        {
            InitializeComponent();
            CargarGrupos();
        }

        private void CargarGrupos()
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter("SELECT IdGrupo, Nombre FROM Grupo", _conn))
            {
                da.Fill(dt);
            }
            dgvGrupos.DataSource = dt;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            pbImagen.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            if (pbImagen.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    pbImagen.Image.Save(ms, pbImagen.Image.RawFormat);
                    img = ms.ToArray();
                }
            }
            ///Guarda la imagen en la base de datos:
            using (var cn = new SqlConnection(_conn))
            using (var cmd = new SqlCommand("INSERT INTO Grupo (Nombre, Imagen) VALUES (@n, @i)", cn))
            {
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@i", (object)img ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }

            CargarGrupos();
            txtNombre.Clear();
            pbImagen.Image = null;
        }
    }
}

