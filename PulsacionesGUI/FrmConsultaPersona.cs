using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entity;
using BLL;
namespace PulsacionesGUI
{
    public partial class FrmConsultaPersona : Form
    {
        InterfaceIRecepcion FrmRecepcion;
        PersonaService Service = new PersonaService();
        public FrmConsultaPersona()
        {
            InitializeComponent();
        }
        public FrmConsultaPersona(InterfaceIRecepcion recepcion)
        {
            InitializeComponent();
            FrmRecepcion = recepcion;
        }
        List<Persona> personas = new List<Persona>();
        private void BtnConsultar_Click(object sender, EventArgs e)
        {

            DtgPersona.DataSource = null;
            personas.Clear();
            personas = Service.Consultar();
            DtgPersona.DataSource = personas;
          
        }

        private void DtgPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FrmRecepcion!=null)
            {
                Persona persona = (Persona)DtgPersona.CurrentRow.DataBoundItem;
                FrmRecepcion.Recibir(persona);
                this.Hide();
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            PersonaService service = new PersonaService();
            DtgPersona.DataSource = null;
            DtgPersona.DataSource = service.ConsultarMujeres();
        }

        private void FrmConsultaPersona_Load(object sender, EventArgs e)
        {

        }

        private void pedirRuta()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = @"D:/Descargas/";
            fileDialog.Title = "Guardar Reporte";
            fileDialog.DefaultExt = "pdf";
            fileDialog.Filter = "pdf files (*.pdf)|*.pdf| all files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
            string filename = string.Empty;
            if(fileDialog.ShowDialog()==DialogResult.OK)
            {
                filename = fileDialog.FileName;
            }
            if(filename.Trim()!="" && personas.Count>0)
            {
                string mensaje = Service.GuardarPDF(personas, filename);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO SE HA GUARDADO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            string filename = string.Empty;
            FileDialog.RestoreDirectory = true;
            FileDialog.Filter = "Pdf Files| *.pdf";
            FileDialog.ShowDialog();
            if (!FileDialog.FileName.Equals(""))
            {
                filename = FileDialog.FileName;
                TxtAdjuntarArchivo.Text = filename;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!TxtCorreo.Text.Equals("") || !TxtAdjuntarArchivo.Equals(""))
            {
                string mensaje = Service.EnviarReporte(TxtCorreo.Text, TxtAdjuntarArchivo.Text);
                MessageBox.Show(mensaje, "MENSAJE");
                TxtCorreo.Text = "";
                TxtAdjuntarArchivo.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pedirRuta();
        }
    }
}
