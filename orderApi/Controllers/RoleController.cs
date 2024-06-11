using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.Model;
using orderApi.Repository;

namespace orderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRepository<Role> _repository;

        public RoleController(IRepository<Role> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            var role = _repository.GetAll();
            return Ok(role);
        }

        [HttpGet("{id:int}", Name = "ObterRole")]
        public ActionResult<Role> Get(int id)
        {
            var role = _repository.Get(r => r.RoleId == id);
            return Ok(role);
        }
        [HttpPost]
        public ActionResult Post(Role role)
        {
            if (role is null)
            {
                return BadRequest();
            }
            var createdRole = _repository.Create(role);
            return new CreatedAtRouteResult("ObterRole", new { id = createdRole.RoleId }, createdRole);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            _repository.Update(role);
            return Ok(role);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var role =_repository.Get(r => r.RoleId == id);
            if (role is null)
            {
                return NotFound();
            }
            var deletedRole = _repository.Delete(role);

            return Ok(deletedRole);
        }
    }
}
