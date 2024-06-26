﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargarUsuarios
{
    public partial class Aplicacion : Form
    {
        public string AccionGuardar;

        public string ConnectionString;

        public void ActivarFormulario()
        {
            txtCompañia.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNumero.Text = string.Empty;

            txtCompañia.Enabled = true;
            txtContraseña.Enabled = true;
            txtCorreo.Enabled = true;  
            txtDireccion.Enabled = true; 
            txtNumero.Enabled = true;

            btnAñadir.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            dgvUsuarios.Enabled = false;
        }

        public void DesactivarFormulario()
        {
            txtCompañia.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNumero.Text = string.Empty;

            txtCompañia.Enabled = false;
            txtContraseña.Enabled = false;
            txtCorreo.Enabled = false;
            txtDireccion.Enabled = false;
            txtNumero.Enabled = false;

            btnAñadir.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            dgvUsuarios.Enabled = true;

            CargarTabladeUsuarios();
        }

        public void CargarTabladeUsuarios()
        {
            
            string myquery = "SELECT * FROM usuarios;";
            DataTable dataTable = new DataTable();

            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();

                MySqlCommand command = new MySqlCommand(myquery, con);
                MySqlDataReader register = command.ExecuteReader();
                dataTable.Load(register);
                con.Close();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.DataSource = dataTable;

        }

        public void EjecutarQuery(string query)
        {
            
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();

                MySqlCommand command = new MySqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Aplicacion(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            CargarTabladeUsuarios();
            DesactivarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesactivarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            string compañia = txtCompañia.Text;
            string direccion = txtDireccion.Text;
            string numero = txtNumero.Text;

            


            if (AccionGuardar == "Añadir")
            {
                string query = "INSERT INTO usuarios(correo, contraseña, compañia, direccion, numero) VALUES('" + correo + "', '" + contraseña + "', '" + compañia + "','" + direccion + "', '" + numero + "')";
                EjecutarQuery(query);
            }else if(AccionGuardar == "Editar")
            {
                int selectedrowofindex = dgvUsuarios.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvUsuarios.Rows[selectedrowofindex];
                int id = Convert.ToInt32(selectedRow.Cells["idusuario"].Value);
                string query = "UPDATE usuarios SET correo = '"+correo+"', contraseña ='"+contraseña+ "', compañia='"+compañia+"' , direccion = '"+direccion+"', numero = '"+numero+"' WHERE idusuario = " + id + ";";
                EjecutarQuery(query);
            }
            
            DesactivarFormulario();

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            ActivarFormulario();
            AccionGuardar = "Añadir";
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarFormulario();
            AccionGuardar = "Editar";
            

            int selectedrowofindex = dgvUsuarios.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvUsuarios.Rows[selectedrowofindex];
            int id = Convert.ToInt32(selectedRow.Cells["idusuario"].Value);

            txtCorreo.Text = Convert.ToString(selectedRow.Cells["correo"].Value);
            txtContraseña.Text = Convert.ToString(selectedRow.Cells["contraseña"].Value);
            txtCompañia.Text = Convert.ToString(selectedRow.Cells["compañia"].Value);
            txtDireccion.Text = Convert.ToString(selectedRow.Cells["direccion"].Value);
            txtNumero.Text = Convert.ToString(selectedRow.Cells["numero"].Value);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedrowofindex = dgvUsuarios.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvUsuarios.Rows[selectedrowofindex];
            int id = Convert.ToInt32(selectedRow.Cells["idusuario"].Value);
            DialogResult dialogResult = MessageBox.Show("Està seguro?", "Eliminar Usuario", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "DELETE FROM usuarios WHERE idusuario=" + id + ";";
                EjecutarQuery(query);
            }
            DesactivarFormulario();
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea crear una la tabla de usuarios?", "Base de datos creada.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {                string query1 = "create table usuarios(idusuario int auto_increment, correo varchar(255), contraseña varchar(255), compañia varchar(255), direccion varchar(1000), numero varchar(255), primary key(idusuario));";
                EjecutarQuery( query1);
                CargarTabladeUsuarios();
            }
        }
    }
}
