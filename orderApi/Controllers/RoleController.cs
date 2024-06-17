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
        private readonly IUnityOfWork _uof;

        public RoleController(IUnityOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            var role = _uof.RoleRepository.GetAll();
            return Ok(role);
        }

        [HttpGet("{id:int}", Name = "ObterRole")]
        public ActionResult<Role> Get(int id)
        {
            var role = _uof.RoleRepository.Get(r => r.RoleId == id);
            return Ok(role);
        }
        [HttpPost]
        public ActionResult Post(Role role)
        {
            if (role is null)
            {
                return BadRequest();
            }
            var createdRole = _uof.RoleRepository.Create(role);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterRole", new { id = createdRole.RoleId }, createdRole);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            _uof.RoleRepository.Update(role);
            _uof.Commit();
            return Ok(role);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var role = _uof.RoleRepository.Get(r => r.RoleId == id);
            if (role is null)
            {
                return NotFound();
            }
            var deletedRole = _uof.RoleRepository.Delete(role);
            _uof.Commit();

            return Ok(deletedRole);
        }
    }
}
