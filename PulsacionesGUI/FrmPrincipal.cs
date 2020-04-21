using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulsacionesGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroPersona frmRegistroPersona = new FrmRegistroPersona();
            frmRegistroPersona.MdiParent = this;
            frmRegistroPersona.Show();

        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaPersona frmConsultaPersona = new FrmConsultaPersona();
            frmConsultaPersona.MdiParent = this;
            frmConsultaPersona.Show();
        }

        private void PersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deLaAPlicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
