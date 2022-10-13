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
    public partial class FormPaginaInicial : Form
    {
        public FormPaginaInicial()
        {
            InitializeComponent();
        }

        #region Events

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.msn.com/en-us/travel/news/stimulus-update-exact-date-direct-check-payments-worth-up-to-300-will-be-sent-out-revealed/ar-AA12Sz0d?cvid=e628632939f8432cfabf5e736f1150cb&ocid=winp2sv1plustaskbarhover");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.msn.com/en-us/news/technology/scientists-shocked-as-black-hole-spews-out-something-they-ve-never-seen-before/ar-AA12TiCp?cvid=16328ac55901436ac76bf81e351490d7&ocid=winp2sv1plustaskbar");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.msn.com/en-us/news/us/herschel-walker-says-his-grandma-was-full-blood-cherokee-his-mom-says-otherwise/ar-AA12TF8t?cvid=8269557d8a1944fb80aef8f3bdff7273&ocid=winp2sv1plustaskbarhover");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnContact_Click(object sender, EventArgs e)
        {

        }

        private void btnCompromissos_Click(object sender, EventArgs e)
        {
            
            FormCompromissos formCompromissos = new FormCompromissos();
            this.Hide();
            formCompromissos.ShowDialog();
        }
    }
}
