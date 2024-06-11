using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cervantesforms
{
    public class Pessoa
    {
        private Pessoa() { }
        public Pessoa(int id, string? nome, string? cpf, string? email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Cpf  { get; private set; }
        public string? Email { get; private set; }

    }
}
