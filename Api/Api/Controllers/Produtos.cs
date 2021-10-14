using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Produces("application/json")]
    public class Produtos : ControllerBase
    {
        private IProdutoService _produtoService;

        public Produtos(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [Route("/todos/produtos/{pagina}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutos(int pagina)
        {
            try
            {
                var alunos = await _produtoService.GetProdutos(pagina);
                return Ok(alunos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter os produtos");
            }
        }


        [Route("/produto/{codBarras}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Produto>> GetProduto(string codBarras)
        {
            try
            {
                var alunos = await _produtoService.GetProduto(codBarras);
                

              if ( alunos == null ) { return NotFound($"Não existe Produto com o código de barras: {codBarras}"); }

                return Ok(alunos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o produto");
            }
        }
    }
}
