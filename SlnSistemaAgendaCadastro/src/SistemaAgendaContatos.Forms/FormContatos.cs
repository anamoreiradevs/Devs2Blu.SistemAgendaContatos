using MySql.Data.MySqlClient;
using SistemaAgendaContatos.Forms.DataBase;
using SistemAgendaContatos.Models.Enum;
using SistemAgendaContatos.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAgendaContatos.Forms
{
    public partial class FormContatos : Form
    {

        public EstadoRepository EstadoRepository { get; set; }
        public ContatoRepository ContatoRepository { get; set; }
        public Contato Contato { get; set; }

        public FormContatos()
        {
            InitializeComponent();
        }
        #region Events
        private void FormContatos_Load(object sender, EventArgs e)
        {
            EstadoRepository = new EstadoRepository();
            ContatoRepository = new ContatoRepository();
            Contato = new Contato();
            PopulaComboUF();
            PopulaDataGridContatos();
        }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidaFormCadastro())
            {
                FillClassContato();
                if (Contato.Id > 0)
                {
                    AtualizaContato();
                }
                else
                {
                    SalvaContato();
                }
                LimparCampos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Contato.Id > 0)
            {
                AtualizaContato();
            }
            btnDelete.Visible = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show($"Deseja Excluir o Contato {Contato.Id} - {Contato.Nome}?", "Excluir Contato", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (ContatoRepository.DeleteById(Contato.Id))
                {
                    MessageBox.Show($"Contato {Contato.Id} - {Contato.Nome} excluído com sucesso!");
                }
                PopulaDataGridContatos();
            }

        }
      
        private void dataGridContatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Contato = new Contato();
            Contato.Id = (int)dataGridContatos.Rows[e.RowIndex].Cells["id"].Value;
            Contato.Nome = (string)dataGridContatos.Rows[e.RowIndex].Cells["nome"].Value;
        }
        private void dataGridContatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idContato = (int)dataGridContatos.Rows[e.RowIndex].Cells["id"].Value;
            Contato = ContatoRepository.FindById(idContato);
            PopulaCamposForm();
        }
        #endregion
        #region Methods
        private void PopulaComboUF()
        {
            MySqlDataReader rdrEstados = EstadoRepository.GetAll();
            cboUF.DataSource = new BindingSource(rdrEstados, null);
            cboUF.DisplayMember = "descricao";
            cboUF.ValueMember = "uf";
        }
        private void PopulaDataGridContatos()
        {
            MySqlDataReader rdrContatos = ContatoRepository.GetAll();
            dataGridContatos.DataSource = new BindingSource(rdrContatos, null);
        }
        private bool ValidaFormCadastro()
        {
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Favor informar um Nome!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            if (cboUF.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Favor informar um Estado!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboUF.Focus();
                return false;
            }
            return true;
        }
        private void SalvaContato()
        {
            string columns, values;
            var status = rbAtivo.Checked ? StatusEnum.A : StatusEnum.I;

            columns = "nome, telefone, celular, email, rua, numero, bairro, cidade, uf, status";
            values = $"'{Contato.Nome}','{Contato.Telefone}','{Contato.Celular}','{Contato.Email}','{Contato.Rua}',{Contato.Numero},'{Contato.Bairro}','{Contato.Cidade}','{Contato.UF}','{Contato.Status}'";

            try
            {
                int idInsert = ContatoRepository.Insert(columns, values);
                if (idInsert > 0)
                {
                    MessageBox.Show($"Contato {idInsert} - {txtNome.Text} salvo com sucesso!");
                    PopulaDataGridContatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AtualizaContato()
        {
            string columns;
            var status = rbAtivo.Checked ? StatusEnum.A : StatusEnum.I;
            columns = $@"nome = '{Contato.Nome}', telefone = '{Contato.Telefone}', celular ='{Contato.Celular}', email = '{Contato.Email}', rua = '{Contato.Rua}', 
            numero = {Contato.Numero}, bairro = '{Contato.Bairro}', cidade = '{Contato.Cidade}', uf = '{Contato.UF}', status = '{Contato.Status}'";

            try
            {
                int idUpdate = ContatoRepository.Update(columns, Contato.Id);
                if (idUpdate > 0)
                {
                    MessageBox.Show($"Contato {Contato.Id} - {Contato.Nome} atualizado com sucesso!");
                    PopulaDataGridContatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FillClassContato()
        {
            Contato.Nome = txtNome.Text;
            Contato.Rua = txtRua.Text;
            Contato.Email = txtEmail.Text;
            Contato.Telefone = txtTelefone.Text;
            Contato.Celular = txtCelular.Text;
            Contato.Numero = Int32.Parse(txtNumero.Text);
            Contato.Bairro = txtBairro.Text;
            Contato.Cidade = txtCidade.Text;
            Contato.UF = cboUF.SelectedValue.ToString();
            Contato.Status = (rbAtivo.Checked) ? StatusEnum.A : StatusEnum.I;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            maskCep.Clear();
            cboUF.Text = "";
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Text = "";
            txtCidade.Clear();
            txtBairro.Clear();
            txtRua.Clear();
            txtNumero.Clear();
        }
        private void PopulaCamposForm()
        {
            txtNome.Text = Contato.Nome;
            txtRua.Text = Contato.Rua;
            txtEmail.Text = Contato.Email;
            txtTelefone.Text = Contato.Telefone;
            txtCelular.Text = Contato.Celular;
            txtNumero.Text = Contato.Numero.ToString();
            txtBairro.Text = Contato.Bairro;
            txtCidade.Text = Contato.Cidade;
            cboUF.SelectedValue = Contato.UF;
            rbAtivo.Checked = Contato.Status.Equals(StatusEnum.A) ? true : false;
            rbInativo.Checked = Contato.Status.Equals(StatusEnum.I) ? true : false;
        }
        #endregion

        
    }
}