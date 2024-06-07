using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CargarUsuarios
{
    public partial class Form1 : Form
    {
        public void InicioDeSesion(string Usuario, string Contraseña)
        {
            string ConnectionString = "Server=localhost;uid="+Usuario+";pwd="+Contraseña+";database=mayorista;";
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();
                MessageBox.Show("Conexion Correcta", "Conexion.", MessageBoxButtons.OK);
                con.Close();
                Aplicacion aplicacion = new Aplicacion();
                aplicacion.Closed += (s, args) => this.Close();
                aplicacion.Show();
                Hide();

            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

            if (txtUsuario.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                MessageBox.Show("Rellene el formulario...","Error",MessageBoxButtons.OK);
            }
            else
            {
                InicioDeSesion(usuario, contraseña);
            }
        }
    }
}
