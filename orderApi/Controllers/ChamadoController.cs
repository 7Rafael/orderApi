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
        private readonly IUnityOfWork _uof;
        public ChamadoController(IChamadoRepository chamadoRepository,
            IUnityOfWork uof)
        {
            _chamadoRepository = chamadoRepository;
            _uof = uof;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Chamado>> GetAll()
        {
            var chamados = _uof.ChamadoRepository.GetAll();
            
            return Ok(chamados);
        }

        [HttpGet("{id:int}", Name = "ObterChamado")]
        public ActionResult<Chamado> Get(int id)
        {
            var chamado = _uof.ChamadoRepository.Get(c => c.ChamadoId == id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(Chamado chamado)
        {

            _uof.ChamadoRepository.Update(chamado);
            _uof.Commit();
            return Ok(chamado);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var chamado = _uof.ChamadoRepository.Get(c => c.ChamadoId == id);

            var deletedChamado = _uof.ChamadoRepository.Delete(chamado);
            _uof.Commit();
            return Ok(deletedChamado);
        }
    }
}
