using System.Collections.Generic;

namespace ApiCatalogoDeJogos.Models.ErrorModel
{
    public class ValidationErrorsModel
    {
        public IEnumerable<string> Erros { get; private set; }
        public ValidationErrorsModel(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
