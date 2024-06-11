using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cervantesforms.Repositorios
{
    internal class PessoaRepositorio
    {
        public void Inserir(Pessoa pessoa)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("INSERT INTO PESSOA (NOME, CPF, EMAIL) VALUES(@NOME, @CPF, @EMAIL);")
                new
                {
                    nome = pessoa.Nome,
                    Cpf = pessoa.Cpf,
                    email = pessoa.Email,
                }); ;

        }

        public void Atualizar(Pessoa pessoa)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("UPDATE PESSOA SET NOME = @nome, CPF = @cpf, EMAIL = @email WHERE ID = @id;")
                new
                {
                    nome = pessoa.Nome,
                    Cpf = pessoa.Cpf,
                    email = pessoa.Email,
                    id = pessoa.Id
                }); ;
        }

        public void Deletar(int id)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            conexao.Execute("DELETE FROM PESSOA WHERE ID = @id;")
                new
                {
                    id
                }); ;
        }

        public Pessoa BuscarPessoaPeloId(int id)
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.QueryFirstOrDefault<Pessoa>(@"SELECT * FROM PESSOA WHERE ID = @id",
                new { id });
        }

        public IEnumerable<Pessoa> BuscarTodasPessoas()
        {
            using NpgsqlConnection conexao = (NpgsqlConnection)new DbConexao().GetConnection();
            return conexao.Query<Pessoa>(@"SELECT * FROM PESSOA");
        }
    } 
}   
