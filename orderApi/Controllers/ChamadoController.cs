using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.DTO;
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
        private readonly IMapper _mapper;
        public ChamadoController(IChamadoRepository chamadoRepository,
            IUnityOfWork uof, IMapper mapper)
        {
            _chamadoRepository = chamadoRepository;
            _uof = uof;
            _mapper = mapper;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public ActionResult<IEnumerable<ChamadoDTO>> GetAll()
        {

            var chamados = _uof.ChamadoRepository.GetAll();
            var chamadosDto = _mapper.Map<IEnumerable<ChamadoDTO>>(chamados);
            return Ok(chamadosDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}", Name = "ObterChamado")]
        public ActionResult<ChamadoDTO> Get(int id)
        {

            var chamado = _uof.ChamadoRepository.Get(c => c.ChamadoId == id);
            var chamadoDto = _mapper.Map<ChamadoDTO>(chamado);
            return Ok(chamadoDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Create")]
        public async Task<ActionResult> Post(ChamadoDTO chamadoDto, int clienteId, int setorId)
        {
            try
            {


                var chamado = _mapper.Map<Chamado>(chamadoDto);
                var newChamado = await _chamadoRepository.CreateAsync(chamado, clienteId, setorId);
                var newChamadoDto = _mapper.Map<ChamadoDTO>(newChamado);

                return Ok(newChamadoDto);
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id:int}")]
        public ActionResult Put(ChamadoDTO chamadoDto)
        {

            /*
            var cliente = _mapper.Map<Cliente>(clienteDto);

            var newCliente = _uof.ClienteRepository.Update(cliente);

            _uof.Commit();
            var newClienteDto = _mapper.Map<ClienteDTO>(newCliente);

            return Ok(newClienteDto);
             
             */
            var chamado = _mapper.Map<Chamado>(chamadoDto);
            var newChamado =_uof.ChamadoRepository.Update(chamado);
            _uof.Commit();
            var newChamadoDto = _mapper.Map<ChamadoDTO>(newChamado);
            return Ok(newChamadoDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id:int}")]
        public ActionResult<ChamadoDTO> Delete(int id)
        {

            /*

            _uof.Commit();
            var deletedClienteDto = _mapper.Map<ClienteDTO>(deletedCliente);
            return Ok(deletedClienteDto);
             
             */



            var chamado = _uof.ChamadoRepository.Get(c => c.ChamadoId == id);
            if(chamado == null)
            {
                return NotFound();
            }

            var deletedChamado = _uof.ChamadoRepository.Delete(chamado);
            _uof.Commit();
            var deletedChamadoDto = _mapper.Map<ChamadoDTO>(deletedChamado);
            return Ok(deletedChamadoDto);
        }
    }
}
