using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperFrontEnd
{
    public partial class FrmInput : Form
    {
        public FrmInput()
        {
            InitializeComponent();
        }


        public string GetNombre
        {
            get
            {
                  if(!String.IsNullOrEmpty(this.txtNombre.Text))
                  {
                    return this.txtNombre.Text;
                  }
                  else
                  {
                    return "Sin nombre.";

                  }

            }
        }

        public string GetCorreo
        {
            get
            {
                if(!String.IsNullOrEmpty(this.txtCorreo.Text))
                {
                    return this.txtCorreo.Text;
                }
                else
                {
                    return "Sin correo";
                }
            }
        }

        public int GetCelular
        {
            get
            {
                if(this.numCelular.Value>0)
                {
                    return (int)this.numCelular.Value;
                }
                else
                {
                    return 0;
                }

            }
        }


    }
}
