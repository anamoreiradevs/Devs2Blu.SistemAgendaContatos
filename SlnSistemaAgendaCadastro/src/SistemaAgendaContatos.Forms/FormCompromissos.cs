using MySql.Data.MySqlClient;
using SistemaAgendaContatos.Forms.DataBase;
using SistemAgendaContatos.Models.Enum;
using SistemAgendaContatos.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace SistemaAgendaContatos.Forms
{
    public partial class FormCompromissos : Form
    {
        public CompromissoRepository CompromissoRepository { get; set; }
        public Compromisso Compromisso { get; set; }
        public FormCompromissos()
        {
            InitializeComponent();
        }

        #region Events
        private void FormCompromissos_Load_1(object sender, EventArgs e)
        {
            CompromissoRepository = new CompromissoRepository();
            Compromisso = new Compromisso();
            PopulaDataGridCompromissos();
          
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

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            dataGridCompromissos.Visible = true;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidaFormCadastro())
            {
                FillClassCompromisso();
                if (Compromisso.Id > 0)
                {
                    AtualizaCompromisso();
                }
                else
                {
                    SalvaCompromisso();
                }
                PopulaDataGridCompromissos();
                LimparCampos();
            }
        }
    

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show($"Deseja Excluir o Compromisso {Compromisso.Id} - {Compromisso.Descricacao}?", "Excluir Compromisso", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (CompromissoRepository.DeleteById(Compromisso.Id))
                {
                    MessageBox.Show($"Compromisso {Compromisso.Id} - {Compromisso.Descricacao} excluído com sucesso!");
                }
                PopulaDataGridCompromissos();
            }
        }

        private void dataGridCompromissos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Compromisso = new Compromisso();
            Compromisso.Id = (int)dataGridCompromissos.Rows[e.RowIndex].Cells["id"].Value;
            /*Compromisso.Data = (string)(dataGridCompromissos.Rows[e.RowIndex].Cells["data_compromisso"].Value);*/
            Compromisso.Data = Convert.ToString(dataGridCompromissos.Rows[e.RowIndex].Cells["data_compromisso"].Value);
            Compromisso.Descricacao = (string)dataGridCompromissos.Rows[e.RowIndex].Cells["descricao"].Value;
        }

        private void dataGridCompromissos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCompromisso = (int)dataGridCompromissos.Rows[e.RowIndex].Cells["id"].Value;
            Compromisso = CompromissoRepository.FindById(idCompromisso);
            PopulaCamposForm();
        }

        #endregion
        #region Methods
        private void PopulaDataGridCompromissos()
        {
            MySqlDataReader compromisso = CompromissoRepository.GetAll();
            dataGridCompromissos.DataSource = new BindingSource(compromisso, null);
        }
        private bool ValidaFormCadastro()
        {
            if (txtDescricao.Text.Equals(""))
            {
                MessageBox.Show("Favor informar A Descrição!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
                return false;
            }
            return true;
        }
        private void SalvaCompromisso()
        {
            string columns, values;
            var status = rbConcluido.Checked ? StatusEnum.C : StatusEnum.R;

            columns = "descricao,data_compromisso,status";
            values = $"'{Compromisso.Descricacao}','{Compromisso.Data}','{Compromisso.Status}'";

            try
            {
                int idInsert = CompromissoRepository.Insert(columns, values);
                if (idInsert > 0)
                {
                    MessageBox.Show($"Compromisso {idInsert} - {txtDescricao.Text} Salvo Com Sucesso!");
                    PopulaDataGridCompromissos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AtualizaCompromisso()
        {
            string columns;
            var status = rbConcluido.Checked ? StatusEnum.C : StatusEnum.R;
            columns = $@"descricao = '{Compromisso.Descricacao}', data_compromisso = '{Compromisso.Data},{Compromisso.Status}'";

            try
            {
                int idUpdate = CompromissoRepository.Update(columns, Compromisso.Id);
                if (idUpdate > 0)
                {
                    MessageBox.Show($"Compromisso {Compromisso.Id} - {Compromisso.Descricacao} atualizado com sucesso!");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FillClassCompromisso()
        {
            Compromisso.Descricacao = txtDescricao.Text;
            Compromisso.Data = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            Compromisso.Status = (rbConcluido.Checked) ? StatusEnum.C : StatusEnum.R;
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
        }

        private void PopulaCamposForm()
        {
            txtDescricao.Text = Compromisso.Descricacao;
            rbConcluido.Checked = Compromisso.Status.Equals(StatusEnum.A) ? true : false;
            rbRemarcado.Checked = Compromisso.Status.Equals(StatusEnum.I) ? true : false;
        }


        #endregion

      
    }
}



