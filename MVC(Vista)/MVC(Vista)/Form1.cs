using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace MVC_Vista_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null; //inicializa la instancia
        ClsContactoMgr objContactoMgr = null; //inicializa la instancia
        DataTable Dtt; //inicializa la instancia
        public Form1()
        {
            InitializeComponent();
          
           
        }


        private void Listar() {

            objContacto = new ClsContacto(); //completo la instancia
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Guardar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Contacto guardado exitosamente", "Mensaje");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txtcodigo.Focus();
        }

        private void GuardarCambios()
        {

            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios guardados exitosamente", "Mensaje");

        }

        private void dtregistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txttelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            txtcodigo.Enabled = false;
            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btneliminar.Enabled = true;
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();
            txtcodigo.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        public void Eliminar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);

            objContactoMgr.EliminarDatos();
            MessageBox.Show("Registro eliminado exitosamente", "Mensaje");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            txtcodigo.Enabled = true;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Listar();
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            txtcodigo.Enabled = true;
            LimpiarCampos();
        }
    }
}
