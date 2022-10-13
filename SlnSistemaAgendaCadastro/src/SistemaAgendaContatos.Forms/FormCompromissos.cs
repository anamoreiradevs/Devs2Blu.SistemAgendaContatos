using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgendaContatos.Forms
{
    public partial class FormCompromissos : Form
    {
        public FormCompromissos()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVoltarPagina_Click(object sender, EventArgs e)
        {
            FormPaginaInicial formPaginaInicial = new FormPaginaInicial();
            this.Hide();
            formPaginaInicial.ShowDialog();
        }
    }
}
