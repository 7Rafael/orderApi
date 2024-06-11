using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository;
using orderApi.Repository.ChamadoRepositories;

namespace orderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IRepository<Chamado> _repository;
        public ChamadoController(IRepository<Chamado> repository,
            IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Chamado>> GetAll()
        {
            var chamados = _repository.GetAll();
            return Ok(chamados);
        }

        [HttpGet("{id:int}", Name = "ObterChamado")]
        public ActionResult<Chamado> Get(int id)
        {
            var chamado = _repository.Get(c => c.ChamadoId == id);
            return Ok(chamado);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Post(Chamado chamado, int clienteId, int setorId)
        {
            try
            {
                var chamadoCriado = await _chamadoRepository.CreateAsync(chamado, clienteId, setorId);
                return Ok(chamadoCriado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Trate outros erros
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /*
        [HttpPost]
        public ActionResult Post(Chamado chamado)
        {
            var createdChamado = _repository.Create(chamado);
            return new CreatedAtRouteResult("ObterChamado", new { id = createdChamado.ChamadoId }, createdChamado);
        }
        */
        [HttpPut("{id:int}")]
        public ActionResult Put(Chamado chamado)
        {

            _repository.Update(chamado);
            return Ok(chamado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var chamado = _repository.Get(c => c.ChamadoId == id);

            var deletedChamado = _repository.Delete(chamado);
            return Ok(deletedChamado);
        }
    }
}
