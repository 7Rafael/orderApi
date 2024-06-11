using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository;
using orderApi.Repository.ClienteRepositories;

namespace orderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepository<Cliente> _repository;

        public ClienteController(IRepository<Cliente> repository,
            IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _repository.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id:int}", Name = "ObterCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _repository.Get(c => c.ClienteId == id);
            return Ok(cliente);
        }


        [HttpPost("Create")]
        public async Task<ActionResult> PostWithRole(Cliente cliente, int roleId)
        {
            try
            {
                var clienteRole = await _clienteRepository.CreateClientWithRoleAsync(cliente, roleId);
                return Ok(clienteRole);
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

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }
            _repository.Update(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _repository.Get(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var deletedCliente = _repository.Delete(cliente);
            return Ok(deletedCliente);
        }
    }
}
