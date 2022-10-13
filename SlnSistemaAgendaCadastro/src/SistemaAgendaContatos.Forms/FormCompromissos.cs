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

        #region Events


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

        private void FormCompromissos_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            gridSchedule.Visible = true;
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            gridSchedule.Visible = true;
            btnDelete.Enabled = true;
        }
        #endregion

        #region Methods


    }
        #endregion
    }



