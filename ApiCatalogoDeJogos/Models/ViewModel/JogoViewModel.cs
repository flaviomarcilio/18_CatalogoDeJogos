using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoDeJogos.Models.ViewModel
{
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Publicadora { get; set; }
        public string Serie { get; set; }

        [DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }
    }
}
