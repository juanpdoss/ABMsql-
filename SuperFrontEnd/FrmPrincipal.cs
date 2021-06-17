using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABMsql;

namespace SuperFrontEnd
{
    public partial class FrmPrincipal : Form
    {

        List<Persona> personas;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.personas = PersonasDAO.SelectPersonas();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmInput frmInput = new FrmInput();

            DialogResult respuestUsuario = frmInput.ShowDialog();

            if(respuestUsuario == DialogResult.OK)                    
            {
                Persona nuevaPersona = new Persona();
                nuevaPersona.Nombre = frmInput.GetNombre;
                nuevaPersona.Email = frmInput.GetCorreo;
                nuevaPersona.Celular= frmInput.GetCelular;

                if(!PersonasDAO.InsertPersona(nuevaPersona))
                {
                    MessageBox.Show("Ocurrio un error durante la insercion.");
                }
              

            }

        }

        private void frmPersonas_Load(object sender, EventArgs e)
        {

            this.dgPersonas.DataSource = this.personas;
          

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.ActualizarDg();

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(this.dgPersonas.SelectedRows.Count > 0)
            {
                //SelectedRows es una coleccion de fila, pero esta seteado que solo se puedan seleccionar de a una

                DataGridViewRow fila = this.dgPersonas.SelectedRows[0]; //tiene un indexador grax a dios
                int id = (int)fila.Cells[0].Value; //las celdas tambien estan indexadas, en el orden en que se muestra el dg
                                                   //value retorna object, por eso casteo     
                if(!PersonasDAO.DeletePersona(id))
                {
                    MessageBox.Show("Error al intentar eliminar persona.");

                }
                else
                {
                    MessageBox.Show("persona eliminada c:");
                }




            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmInput frmInput = new FrmInput();

            DialogResult respuestUsuario = frmInput.ShowDialog();

            if (respuestUsuario == DialogResult.OK)
            {
                Persona nuevaPersona = new Persona();
                nuevaPersona.Nombre = frmInput.GetNombre;
                nuevaPersona.Email = frmInput.GetCorreo;
                nuevaPersona.Celular = frmInput.GetCelular;

                if (!PersonasDAO.InsertPersona(nuevaPersona))
                {
                    MessageBox.Show("Ocurrio un error durante la modificacion.");
                }
                else
                {
                    MessageBox.Show("m o d i f i c a c i o n 100% e x i t o s a");
                }

            }


        }

        private void ActualizarDg()
        {
            this.dgPersonas.DataSource = null;
            this.dgPersonas.DataSource = PersonasDAO.SelectPersonas();
        }

    }
}
