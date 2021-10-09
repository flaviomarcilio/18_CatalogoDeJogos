using System;

namespace ApiCatalogoDeJogos.Models.ViewModel
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Publicadora { get; set; }
        public string Serie { get; set; }
        public DateTime Lancamento { get; set; }
    }
}
