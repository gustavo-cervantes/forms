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

        private void btnAdicionar_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var pessoaRepositorio = new PessoaRepositorio();
            BuscarTodasAsPessoas(PessoaRepositorio);
        }
    }
}
