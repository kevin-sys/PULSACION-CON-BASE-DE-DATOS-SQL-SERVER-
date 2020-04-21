using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using Infraestructura;
using System.Data.SqlClient;
namespace BLL
{
    public  class PersonaService
    {

       
        List<Persona> personas;
        SqlConnection connection;
        string CadenaCnexion = @"Data Source=DESKTOP-NVQ1I8P;Initial Catalog=Pulsacion;Integrated Security=True";
        PersonaRepository repositorio;
        
        Email email = new Email();

        public PersonaService()
        {
            connection = new SqlConnection(CadenaCnexion);
            repositorio = new PersonaRepository(connection);
        }
        public string Guardar(Persona persona)
        {
            Email email = new Email();
            string mensajeEmail = string.Empty;
            try
            {
                connection.Open();
                repositorio.Guardar(persona);
                mensajeEmail = email.EnviarEmail(persona);
                return "SE GUARDO CORRECTAMENTE"+mensajeEmail;

            }
            catch (Exception ex)
            {

                return " ERROR EN LOS DATOS: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }

        }

        public string Eliminar(string identificacion)
        {
            try
            {
                connection.Open();
                repositorio.Eliminar(identificacion);
                return "SE ELIMINO CORRECTAMENTE";

            }
            catch (Exception ex)
            {

                return " ERROR EN LOS DATOS: " + ex.Message;
            }
            finally
            {
                connection.Close();
            }

        }
        public List<Persona> Consultar()
        {
           connection.Open();
           personas = new List<Persona>();
            personas = repositorio.Consultar();
            connection.Close();
            return personas;
        }

        public List<Persona> ConsultarMujeres()
        {
            connection.Open();
            personas = new List<Persona>();
            personas = repositorio.ConsultarMujeres();
            connection.Close();
            return personas;
        }

        public Persona BuscarID(string identificacion)
        {
            Persona persona = new Persona();
            try
            {
                connection.Open();
                return repositorio.Buscar(identificacion);
            }
            catch (Exception e)
            {
                string mensaje = " ERROR EN LA BASE DE DATOS " + e.Message;
                return null;
            }
            finally
            {
                connection.Close();
            }    
        }
        public Persona Modificar(Persona persona)
        {
            try
            {
                connection.Open();
                repositorio.Modificar(persona);
                return persona;

            }
            catch (Exception ex)
            {

                string mensaje = " ERROR DE DATOS: " + ex.Message;
                return null;
            }
            finally
            {
                connection.Close();
            }

        }
        public string GuardarPDF(List<Persona> personas, string fileName )
        {
            GenerarPDF generarPDF = new GenerarPDF();
            generarPDF.GuardarPDF(personas, fileName);
            return "Se genero el documento en la ruta deseada";
        }

        public string EnviarReporte(string correo, string ruta)
        {
            try
            {
                string mensaje = email.EnviarEmailReporte(correo, ruta);
                return mensaje;
            }
            catch (Exception ex)
            {

                return $"Error al enviar el correo {ex.Message}";
            }
        }
            


    }
}
