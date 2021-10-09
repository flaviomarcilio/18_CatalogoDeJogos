using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoDeJogos.Exceptions;
using ApiCatalogoDeJogos.Models.InputModel;
using ApiCatalogoDeJogos.Models.ViewModel;
using ApiCatalogoDeJogos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoDeJogos.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        /// <summary>
        /// Buscar todos os jogos de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar os jogos sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de registros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de jogos</response>
        /// <response code="204">Caso não haja jogos para listar</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        /// <summary>
        /// Buscar um jogo pelo seu ID
        /// </summary>
        /// <param name="idJogo">ID do jogo buscado</param>
        /// <response code="200">Retorna o jogo filtrado</response>
        /// <response code="404">Caso não haja jogo com este ID</response>
        [HttpGet("{idJogo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NotFound();

            return Ok(jogo);
        }

        /// <summary>
        /// Inserir um jogo no catálogo
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /Jogos
        ///     {
        ///        "Nome": "FIFA 14",
        ///        "Publicadora": "EA Games",
        ///        "Serie": "FIFA",
        ///        "Lancamento": "26-10-2004"
        ///     }
        ///
        /// </remarks>
        /// <param name="jogoInputModel">Dados do jogo a ser inserido</param>
        /// <returns>Um novo jogo criado</returns>
        /// <response code="201">Caso o jogo seja inserido com sucesso</response>
        /// <response code="400">Caso seja feita uma requisição sem corpo</response>
        /// <response code="422">Caso já exista um jogo com mesmo nome para a mesma produtora</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return CreatedAtRoute("/Jogos", jogo);

            }
            catch (JogoJaCadastradoException)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        /// <summary>
        /// Atualizar um jogo no catálogo
        /// </summary>
        /// <param name="idJogo">ID do jogo a ser atualizado</param>
        /// <param name="jogoInputModel">Novos dados para atualizar o jogo indicado</param>
        /// <response code="200">Caso o jogo seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este ID</response>
        [HttpPut("{idJogo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Atualizar a data de lançamento de um jogo
        /// </summary>
        /// <param name="idJogo">Id do jogo a ser atualizado</param>
        /// <param name="lancamento">Nova data de lançamento</param>
        /// <response code="200">Caso a data seja atualizada com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>
        [HttpPatch("{idJogo:guid}/lancamento/{lancamento:DateTime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] DateTime lancamento)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, lancamento);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Excluir um jogo
        /// </summary>
        /// <param name="idJogo">Id do jogo a ser excluído</param>
        /// <response code="200">Caso o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>
        [HttpDelete("{idJogo:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
