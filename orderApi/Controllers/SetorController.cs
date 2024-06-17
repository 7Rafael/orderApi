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
        private readonly IUnityOfWork _uof;
        public SetorController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Setor>> Get()
        {
            var setors = _uof.SetorRepository.GetAll();
            return Ok(setors);
        }

        [HttpGet("{id:int}", Name = "ObterSetor")]
        public ActionResult<Setor> Get(int id)
        {
            var setor = _uof.SetorRepository.Get(s => s.SetorId == id);
            return Ok(setor);
        }
        [HttpPost]
        public ActionResult Post(Setor setor)
        {
            if (setor is null)
            {
                return BadRequest();
            }
            var createdSetor = _uof.SetorRepository.Create(setor);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterSetor", new { id = createdSetor.SetorId }, createdSetor);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Setor setor)
        {
            if (id != setor.SetorId)
            {
                return BadRequest();
            }
            _uof.SetorRepository.Update(setor);
            _uof.Commit();
            return Ok(setor);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var setor = _uof.SetorRepository.Get(s => s.SetorId == id);
            if (setor is null)
            {
                return NotFound();
            }
            var deletedSetor = _uof.SetorRepository.Delete(setor);
            _uof.Commit();
            return Ok(deletedSetor);
        }
    }
}
