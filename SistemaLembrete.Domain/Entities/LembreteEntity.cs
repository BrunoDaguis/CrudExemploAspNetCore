
using SistemaLembrete.Domain.Entities.Base;
using System;

namespace SistemaLembrete.Domain.Entities
{
    public class LembreteEntity : EntidadeBase
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual UsuarioEntity Usuario { get; set; }
    }
}
