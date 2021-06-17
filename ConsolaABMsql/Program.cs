using System;
using System.Collections.Generic;
using ABMsql;
using System.Data.SqlClient;

namespace ConsolaABMsql
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = PersonasDAO.SelectPersonas();

            Console.WriteLine(personas.Count);


            if(personas != null)
            {
                foreach (Persona item in personas)
                {

                    Console.WriteLine(item.ToString());
                }
            }


            Persona nuevaPersona = new Persona();
            nuevaPersona.Nombre = "carlitos";
            nuevaPersona.Celular = 113344555;
            nuevaPersona.Email = "carlitos@gmail.com";

            if(PersonasDAO.InsertPersona(nuevaPersona))
            {
                Console.WriteLine("Persona insertada ok");
            }


            if(PersonasDAO.DeletePersona(personas[0]))
            {
                Console.WriteLine("Persona eliminada ok");
            }




           
        }
    }
}
