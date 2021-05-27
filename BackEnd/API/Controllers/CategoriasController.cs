using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Business.Interface;
using Business.Excecoes;
using System.ComponentModel.DataAnnotations;
using Repository.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categorias/")]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices]ICategoriaGetAllUseCase useCase)
        {
            var listaDados = await useCase.Execute();
            return  Ok(listaDados);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById
        (Guid id, [FromServices]ICategoriaGetByIdUseCase useCase)
        {
            var categoria = await useCase.Execute(id);
            return Ok(categoria);
        }
        
        [HttpGet("search")]
        public async Task<IActionResult> GetByDescription
        ([FromQuery] string descricao, [FromServices] ICategoriaGetByDescriptionUseCase useCase)
        {
            var categorias = await useCase.Execute(descricao);
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Post
        ([FromBody] CategoriaInputModel model, [FromServices] ICategoriaPostUseCase useCase)
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
        ([Required] Guid id, [FromBody][Required] CategoriaInputModel model, 
         [FromServices] ICategoriaUpdateUseCase useCase)
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
        (Guid id, [FromServices] ICategoriaDeleteUseCase useCase)
        {
            try
            {
                await useCase.Execute(id);
                return NoContent();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
        } 
    }
}
