using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using System.Net.Mail;
namespace PulsacionesGUI
{
    public partial class FrmRegistroPersona : Form,InterfaceIRecepcion
    {

        Persona persona;

        public FrmRegistroPersona()
        {
            InitializeComponent();
        }
        public void Recibir(Persona persona)
        {
            if(persona!=null)
            {
                txtIdentificacion.Text = persona.Identificacion;
                txtNombre.Text = persona.Nombre;
                txtEdad.Text = (persona.Edad.ToString());
                txtPulsaciones.Text = persona.Pulsaciones.ToString();
                txtCorreo.Text = persona.Email;
                comboSexo.Text = persona.Sexo;
            }
        }
       
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        public void Limpiar()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            comboSexo.Text = "";
            txtPulsaciones.Text = "";
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private Persona MapearPersona()
        {
            if (txtCorreo.Text.Length==0 || txtEdad.Text.Length==0 || txtNombre.Text.Length==0 || txtIdentificacion.Text.Length==0 )
            {
                MessageBox.Show("Algunos campos estan vacios", "MENSAJE DE GUARDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                persona = new Persona();
                persona.Identificacion = txtIdentificacion.Text;
                persona.Nombre = txtNombre.Text;
                persona.Edad = int.Parse(txtEdad.Text);
                persona.Sexo = comboSexo.Text;
                persona.Email = txtCorreo.Text;
                return persona;
            }
            return null;

        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            PersonaService personaService = new PersonaService();
            Persona persona = MapearPersona();
            string mensaje = personaService.Guardar(persona);
            MessageBox.Show(mensaje, "MENSAJE DE GUARDADO", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PersonaService personaService = new PersonaService();
            string identificacion = txtIdentificacion.Text;
            if (identificacion != "")
            {
                Persona persona = personaService.BuscarID(identificacion);

                if (persona != null)
                {
                    txtNombre.Text = persona.Nombre;
                    txtEdad.Text = persona.Edad.ToString();
                    txtPulsaciones.Text = persona.Pulsaciones.ToString();
                    comboSexo.Text = persona.Sexo;
                }
                else
                {
                    MessageBox.Show($"LA PERSONA CON LA IDENTIFICACIÓN:  {identificacion} NO SE ENCUENTRA EN NUESTRA BASE DE DATOS");
                    Limpiar();
                }

            }
            else
            {
                MessageBox.Show("DIGITE IDENTIFICACIÓN");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("ESTA SEGURO DE ELIMINAR EL REGISTRO", "MENSAJE DE ELIMINACIÓN", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                PersonaService personaService = new PersonaService();
                string identificacion = txtIdentificacion.Text;
                string mensaje2 = personaService.Eliminar(identificacion);
                MessageBox.Show(mensaje2);
                Limpiar();
            }


        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text != "" && txtNombre.Text != "" && txtEdad.Text != "" && comboSexo.Text != "")
            {
                PersonaService personaService = new PersonaService();
                Persona persona = new Persona();
                persona.Identificacion = txtIdentificacion.Text;
                persona.Nombre = txtNombre.Text;
                persona.Sexo = comboSexo.Text;
                persona.Edad = int.Parse(txtEdad.Text);
                personaService.Modificar(persona);
                MessageBox.Show("SE MODIFICO CORRECTAMENTE EL REGISTRO");
                Limpiar();
            }
            else
            {
                MessageBox.Show("ALGUNOS CAMPOS ESTAN VACIOS");
            }
        }

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmRegistroPersona_Load(object sender, EventArgs e)
        {

        }

        private void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPulsaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona frmConsulta = new FrmConsultaPersona(this);
            frmConsulta.Show();
        }

       
    }
}
