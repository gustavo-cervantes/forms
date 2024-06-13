using cervantesforms.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cervantesforms
{
    public partial class Cervantes : Form
    {
        public Cervantes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            var pessoa = new Pessoa(0,txtNome.Text, txtCPF.Text, txtEmail.Text);
            var pessoaRepositorio = new PessoaRepositorio();
            pessoaRepositorio.Inserir(pessoa);
            LimparCampos();
            BuscarTodasAsPessoas(pessoaRepositorio);
        }
            
        private void LimparCampos()
        {
            txtCPF.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtID.Text = string.Empty;
        }



        private void BuscarTodasAsPessoas(PessoaRepositorio pessoaRepositorio)
        {
            var pessoas = pessoaRepositorio.BuscarTodasPessoas();
            dgPessoa.DataSource = pessoas.ToList();
        }

        private void Cervantes_Load(object sender, EventArgs e)
        {
            var pessoaRepositorio = new PessoaRepositorio();
            BuscarTodasAsPessoas(pessoaRepositorio);
        }

        private void dgPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;

            txtID.Text = dgv.CurrentRow.Cells["Id"]?.Value?.ToString();
            txtNome.Text = dgv.CurrentRow.Cells["Nome"]?.Value?.ToString();
            txtCPF.Text = dgv.CurrentRow.Cells["Cpf"]?.Value?.ToString();
            txtEmail.Text = dgv.CurrentRow.Cells["Email"]?.Value?.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var pessoa = new Pessoa(Convert.ToInt32(txtID.Text),txtNome.Text,txtCPF.Text,txtEmail.Text);
            var pessoaRepositorio = new PessoaRepositorio();
            pessoaRepositorio.Atualizar(pessoa);
            LimparCampos();
            BuscarTodasAsPessoas(pessoaRepositorio);
        }
                                                                    
        private void btnRemover_Click(object sender, EventArgs e)
        {
            var pessoaRepositorio = new PessoaRepositorio();
            pessoaRepositorio.Deletar(Convert.ToInt32(txtID.Text));
            LimparCampos();
            BuscarTodasAsPessoas(pessoaRepositorio);
        }

       
    }
}
