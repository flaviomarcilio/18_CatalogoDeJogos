using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoDeJogos.Models.InputModel
{
    public class JogoInputModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A publicadora é obrigatória")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da publicadora deve conter entre 1 e 100 caracteres")]
        public string Publicadora { get; set; }

        [Required(ErrorMessage = "A série é obrigatória")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A série deve conter entre 3 e 100 caracteres")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "A data de lançamento dever ser no formato yyyy-MM-dd")]
        public DateTime Lancamento { get; set; }
    }
}
