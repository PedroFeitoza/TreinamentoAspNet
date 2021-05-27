using Business.Excecoes;
using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Entidades.Produto;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produtos/")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IProdutoGetAllUseCase useCase )
        {
            var produtos = await useCase.Execute();
            return Ok(produtos);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById
            (
                Guid id,
                [FromServices] IProdutoGetByIdUseCase useCase
            )
        {
            var produto = await useCase.Execute(id);
            return Ok(produto);
        }
        
        [HttpGet("search")]
        public async Task<IActionResult> GetByDescription
            (
                [FromQuery] string descricao,
                [FromServices] IProdutoGetByDescriptionUseCase useCase
            )
        {
            var produtos = await useCase.Execute(descricao);
            return Ok(produtos);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post
            (
                ProdutoInputModel model,
                [FromServices] IProdutoPostUseCase useCase
            )
        {
            try
            {
                await useCase.Execute(model);
                return Ok(model);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put
            (
                Guid id,
                [FromBody] ProdutoInputModel model,
                [FromServices] IProdutoUpdateUseCase useCase
            )
        {
            try
            {
                await useCase.Execute(id, model);
                return Ok(model);
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete
            (
                Guid id,
                [FromServices] IProdutoDeleteUseCase useCase
            )
        {
            await useCase.Execute(id);
            return NoContent();
        }
    }
}
