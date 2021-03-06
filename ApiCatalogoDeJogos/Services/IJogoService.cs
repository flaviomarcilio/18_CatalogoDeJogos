using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCatalogoDeJogos.Models.InputModel;
using ApiCatalogoDeJogos.Models.ViewModel;

namespace ApiCatalogoDeJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, DateTime lancamento);
        Task Remover(Guid id);
    }
}
