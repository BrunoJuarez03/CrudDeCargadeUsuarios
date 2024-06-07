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
        public void InicioDeSesion(string ConnectionString)
        {
           
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();
                MessageBox.Show("Conexion Correcta", "Conexion.", MessageBoxButtons.OK);
                con.Close();
                Aplicacion aplicacion = new Aplicacion(ConnectionString);
                aplicacion.Closed += (s, args) => this.Close();
                aplicacion.Show();
                Hide();

            }
            catch(MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void ejecutarQuery(string ConnectionString, string query)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Operacion realizada correctamente.", "Nueva Base de datos", MessageBoxButtons.OK);
            }
            catch (MySqlException ex)
            {
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
            string server = txtServer.Text;
            string dt = txtDt.Text;

            string connectionString = "Server="+server+";uid=" + usuario + ";pwd=" + contraseña + ";database="+dt+";";

            if (txtUsuario.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                MessageBox.Show("Rellene el formulario...","Error",MessageBoxButtons.OK);
            }
            else
            {
                InicioDeSesion(connectionString);
            }
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;
            string server = txtServer.Text;
            string dt = txtDt.Text;

            string connectionString = "Server=" + server + ";uid=" + usuario + ";pwd=" + contraseña + ";";
            string query = "CREATE DATABASE "+dt+";";

            if (txtUsuario.Text.Length == 0 || txtPass.Text.Length == 0)
            {
                MessageBox.Show("Rellene el formulario...", "Error", MessageBoxButtons.OK);
            }
            else
            {
                ejecutarQuery(connectionString, query);
            }

            DialogResult dialogResult = MessageBox.Show("Desea crear una la tabla de usuarios?", "Base de datos creada.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string connectionString1 = "Server=" + server + ";uid=" + usuario + ";pwd=" + contraseña + ";database="+dt+";";
                string query1 = "create table usuarios(idusuario int auto_increment, correo varchar(255), contraseña varchar(255), compañia varchar(255), direccion varchar(1000), numero varchar(255), primary key(idusuario));";
                ejecutarQuery(connectionString1, query1);
            }

        }
    }
}
