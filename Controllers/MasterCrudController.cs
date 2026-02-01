using LibraryCrud.Framework.Exceptions;
using LibraryCrud.Services.interfaces.shared;
using Microsoft.AspNetCore.Mvc;
using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public abstract class MasterCrudController<TEntity> : ControllerBase where TEntity : class, IEntity
    {
        protected readonly ICrudService<TEntity> _service;
        protected readonly ILogger<MasterCrudController<TEntity>> _logger;
        protected readonly string _includePatch;

        public MasterCrudController(ILogger<MasterCrudController<TEntity>> logger, ICrudService<TEntity> service, string includePatch = "")
        {
            _logger = logger;
            _service = service;
            _includePatch = includePatch;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Post([FromBody] TEntity model)
        {
            try
            {
                await _service.Post(model);
                // Retornar o objeto criado com 201 Created é o padrão REST
                return CreatedAtAction(nameof(Post), new { id = model.Id }, model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao realizar Post");
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(Guid id, [FromBody] TEntity model)
        {
            if (id != model.Id)
                return BadRequest("O ID da URL não coincide com o ID do objeto.");

            try
            {
                await _service.Put(model);
                return Ok(new { message = "Edição feita com sucesso!" });
            }
            catch (NotFoundException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { message = "Excluído com sucesso!" });
            }
            catch (NotFoundException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
    }

}

    
