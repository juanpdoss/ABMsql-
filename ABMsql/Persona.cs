using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMsql
{
    public class Persona
    {
        int id;
        string nombre;
        int celular;
        string email;

        public int ColumnaID
        {
            get
            {
                return this.id;
            }
            set
            {
                
                this.id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    this.nombre = value;
                }
                else
                {
                    this.nombre = "error.";
                }
            }
        }


        public int Celular
        {
            get
            {
                return this.celular;
            }
            set
            {
                this.celular = value;

            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    this.email = value;
                }
                else
                {
                    this.email = "error.";
                }
            }
        }


        public override string ToString()
        {
            return $"{this.id} - {this.nombre} - {this.celular} - {this.email}";
        }
    }
}
