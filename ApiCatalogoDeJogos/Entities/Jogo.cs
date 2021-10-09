using System;
using System.Collections.Generic;

namespace ApiCatalogoDeJogos.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Publicadora { get; set; }
        public string Serie { get; set; }
        public DateTime Lancamento { get; set; }
    }
}