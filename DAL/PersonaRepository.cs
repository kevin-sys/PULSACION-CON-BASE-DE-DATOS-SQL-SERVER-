using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using System.Data.SqlClient;


namespace DAL
{
    public class PersonaRepository
    {
        private SqlConnection connection;

        private List<Persona> personas;

     

        public PersonaRepository (SqlConnection connectionDb)
        {
            connection = connectionDb;
            personas =new List<Persona>();
        }
            
           public void Guardar (Persona persona)
           {
               using(var command = connection.CreateCommand())
               {
                  command.CommandText = "Insert into personas (Identificacion, Nombre, Edad , Sexo,Pulsaciones) values(@Identificacion,@Nombre,@Edad,@Sexo,@Pulsaciones)";
                  command.Parameters.AddWithValue("@Identificacion",persona.Identificacion);
                  command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                  command.Parameters.AddWithValue("@Edad", persona.Edad);
                  command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                  command.Parameters.AddWithValue("@Pulsaciones", persona.Pulsaciones);
                  command.ExecuteNonQuery();
               }
           }


        public void Eliminar(string identificacion)
        {

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from personas where Identificacion = @Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                command.ExecuteNonQuery();
            }

        }



        private Persona Mapear(SqlDataReader reader)
        {
            Persona persona = new Persona();
            persona.Identificacion = (string)reader["Identificacion"];
            persona.Nombre = (string)reader["Nombre"];
            persona.Edad = (int)(Int32)reader["Edad"];
            persona.Sexo = (string)reader["Sexo"];
            return persona;
        }


        public Persona Buscar(string identificacion)
        {
  
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " select * from Personas where Identificacion = @Identificacion ";
                command.Parameters.AddWithValue("@Identificacion",identificacion);
                var reader = command.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        return Mapear(reader);
                    }
                }
            }
            return null;
        }



        public List<Persona> Consultar()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " select * from Personas";
                var Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Persona persona = new Persona();
                    persona = Mapear(Reader);
                    personas.Add(persona);
                }
            }
            return personas;
        }

        public List<Persona> ConsultarMujeres()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " select * from Personas WHERE Sexo='F'";
                var Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Persona persona = new Persona();
                    persona = Mapear(Reader);
                    personas.Add(persona);
                }
            }
            return personas;
        }
        public void Modificar(Persona persona)
        {

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update  personas set Nombre = @Nombre, Edad=@Edad, Sexo= @Sexo, Pulsaciones=@Pulsaciones where Identificacion = @Identificacion ";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Pulsaciones", persona.Pulsaciones);
                command.ExecuteNonQuery();
            }
        }

    }
}
