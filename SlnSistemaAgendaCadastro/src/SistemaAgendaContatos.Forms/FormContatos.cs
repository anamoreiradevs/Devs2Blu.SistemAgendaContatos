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
    public partial class FormContatos : Form
    {
        public FormContatos()
        {
            InitializeComponent();
        }
        #region Events

        
        private void backWindow_Click(object sender, EventArgs e)
        {
            FormPaginaInicial formPaginaInicial = new FormPaginaInicial();
            this.Hide();
            formPaginaInicial.ShowDialog();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        #endregion

    }
}
