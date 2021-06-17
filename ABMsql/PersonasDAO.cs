using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMsql
{
    public static class PersonasDAO //DAO = data access object 
    {
    
        static SqlCommand comando;
        static SqlConnection conexion;
        static SqlDataReader lector; //objeto que se usa al traer registros de la bd 

        static PersonasDAO()
        {
            PersonasDAO.conexion = new SqlConnection("Data Source = localhost; Initial Catalog = personas; Integrated security = true");
            PersonasDAO.comando = new SqlCommand();


            PersonasDAO.comando.CommandType = CommandType.Text;
            comando.Connection = PersonasDAO.conexion;

        }


        /// <summary>
        /// Trae todos los registros de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static List<Persona> SelectPersonas()
        {
            List<Persona> listaPersonas = new List<Persona>();
            string query = "SELECT * FROM personas";    
            comando.CommandText = query;
            

            try
            {
                if (PersonasDAO.conexion.State != ConnectionState.Open)
                {
                    PersonasDAO.conexion.Open();
                }

                PersonasDAO.lector = PersonasDAO.comando.ExecuteReader();
                //mi clase Persona tiene los atributos id-nombre-celular-email
                //mi tabla tiene las columnas respetando el mismo orden de arriba
                while(PersonasDAO.lector.Read())
                {
                    Persona nuevaPersona = new Persona();
                    nuevaPersona.ColumnaID = (int)lector["id"]; //uso indexador con string 
                    nuevaPersona.Nombre = lector[1].ToString(); //uso indexador con numero
                    nuevaPersona.Celular = (int)lector[2]; 
                    nuevaPersona.Email = lector.GetString(3); //uso metodo getter

                    listaPersonas.Add(nuevaPersona);
                }
            }
            catch
            {
                listaPersonas = null;

            }
            finally
            {
                if (PersonasDAO.conexion.State == ConnectionState.Open)
                    PersonasDAO.conexion.Close();
            }       

            return listaPersonas;
        }


        /// <summary>
        /// Modifica la persona recibida por parametro en la tabla de la base de datos.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool UpdatePersona(Persona persona)
        {
            bool pudeModificar = true; 
            string statement = "UPDATE personas SET(nombre=@nombre,celular=@celular,email=@email) WHERE id=@id";

            PersonasDAO.comando.CommandText = statement;
            PersonasDAO.comando.Parameters.AddWithValue("@nombre",persona.Nombre);
            PersonasDAO.comando.Parameters.AddWithValue("@celular", persona.Celular);
            PersonasDAO.comando.Parameters.AddWithValue("@email", persona.Email);
            PersonasDAO.comando.Parameters.AddWithValue("@id", persona.ColumnaID);

            try
            {
                if(PersonasDAO.conexion.State != ConnectionState.Open)
                {
                    PersonasDAO.conexion.Open();
                }

                int filasAfectadas = PersonasDAO.comando.ExecuteNonQuery();

                if(filasAfectadas == 0)
                {
                    pudeModificar = false;
                }

            }
            catch
            {
                pudeModificar = false;

            }
            finally
            {
                if(PersonasDAO.conexion.State==ConnectionState.Open)
                {
                    PersonasDAO.conexion.Close();
                }

                PersonasDAO.comando.Parameters.Clear();
            }

            return pudeModificar;
        }


        /// <summary>
        /// Inserta la persona recibida por parametro en la tabla de la base de datos.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>

        public static bool InsertPersona(Persona persona)
        {
            bool pudeInsertar = true;
            string statement = "INSERT INTO personas (nombre,celular,email) values(@nombre,@celular,@email)";
            PersonasDAO.comando.CommandText = statement;
            PersonasDAO.comando.Parameters.AddWithValue("@nombre", persona.Nombre);
            PersonasDAO.comando.Parameters.AddWithValue("@celular", persona.Celular);
            PersonasDAO.comando.Parameters.AddWithValue("@email", persona.Email);

            try
            {
                if(PersonasDAO.conexion.State != ConnectionState.Open)
                {
                    PersonasDAO.conexion.Open();
                }

                int filasAfectadas = PersonasDAO.comando.ExecuteNonQuery();

                if(filasAfectadas == 0)
                {
                    pudeInsertar = false;
                }

            }
            catch
            {
                pudeInsertar = false;
                //string ahre = e.Message;

            }
            finally
            {
                if(PersonasDAO.conexion.State == ConnectionState.Open)
                {
                    PersonasDAO.conexion.Close();
                }

                PersonasDAO.comando.Parameters.Clear();
            }

            return pudeInsertar;

        }



        /// <summary>
        /// Eliminar de la tabla en la base de datos la persona recibida por parametro.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool DeletePersona(int id)
        {
            bool pudeEliminar = true;
            string statement = "DELETE FROM personas WHERE id=@id";
            PersonasDAO.comando.CommandText = statement;
            PersonasDAO.comando.Parameters.AddWithValue("@id",id);

            try
            {
                if(PersonasDAO.conexion.State != ConnectionState.Open)
                {
                    PersonasDAO.conexion.Open();
                }

                int filasAfectadas = PersonasDAO.comando.ExecuteNonQuery();

                if(filasAfectadas == 0)
                {
                    pudeEliminar = false;
                }


            }
            catch(Exception e) 
            {
                pudeEliminar = false;
                string ahre = e.Message;
               
            }
            finally
            {
                if (PersonasDAO.conexion.State == ConnectionState.Open)
                {
                    PersonasDAO.conexion.Close();
                }

                PersonasDAO.comando.Parameters.Clear();

            }


            return pudeEliminar;
        }




    }
}
