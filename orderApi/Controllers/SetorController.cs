using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository;
using System.Data;

namespace orderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly IRepository<Setor> _repository;
        public SetorController(IRepository<Setor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Setor>> Get()
        {
            var setors = _repository.GetAll();
            return Ok(setors);
        }

        [HttpGet("{id:int}", Name = "ObterSetor")]
        public ActionResult<Setor> Get(int id)
        {
            var setor = _repository.Get(s => s.SetorId == id);
            return Ok(setor);
        }
        [HttpPost]
        public ActionResult Post(Setor setor)
        {
            if (setor is null)
            {
                return BadRequest();
            }
            var createdSetor = _repository.Create(setor);
            return new CreatedAtRouteResult("ObterSetor", new { id = createdSetor.SetorId }, createdSetor);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Setor setor)
        {
            if (id != setor.SetorId)
            {
                return BadRequest();
            }
            _repository.Update(setor);
            return Ok(setor);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var setor = _repository.Get(s => s.SetorId == id);
            if (setor is null)
            {
                return NotFound();
            }
            var deletedSetor = _repository.Delete(setor);

            return Ok(deletedSetor);
        }
    }
}
