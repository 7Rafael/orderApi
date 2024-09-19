using AutoMapper;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using orderApi.Context;
using orderApi.DTO;
using orderApi.Model;
using orderApi.Repository;
using System.Data;
using System.Diagnostics;

namespace orderApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly IUnityOfWork _uof;
        private readonly IMapper _mapper;
        public SetorController(IUnityOfWork uof,IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public ActionResult<IEnumerable<SetorDTO>> Get()
        {
            var setores = _uof.SetorRepository.GetAll();
            var setoresDto = _mapper.Map<IEnumerable<SetorDTO>>(setores);
            return Ok(setoresDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id:int}", Name = "ObterSetor")]
        public ActionResult<SetorDTO> Get(int id)
        {
            var setor = _uof.SetorRepository.Get(s => s.SetorId == id);
            var setorDto = _mapper.Map<SetorDTO>(setor);
            return Ok(setorDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public ActionResult Post(SetorDTO setorDto)
        {
            if (setorDto is null)
            {
                return BadRequest();
            }
            var setor = _mapper.Map<Setor>(setorDto);
            var newSetor = _uof.SetorRepository.Create(setor);
            _uof.Commit();
            var newSetorDto = _mapper.Map<SetorDTO>(newSetor);
            return new CreatedAtRouteResult("ObterSetor", new { id = newSetorDto.SetorId }, newSetorDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, SetorDTO setorDto)
        {
            if (id != setorDto.SetorId)
            {
                return BadRequest();
            }
            var setor = _mapper.Map<Setor>(setorDto);
            var newSetor=_uof.SetorRepository.Update(setor);
            _uof.Commit();
            var newSetorDto = _mapper.Map<SetorDTO>(setor);
            return Ok(newSetorDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id:int}")]
        public ActionResult<SetorDTO> Delete(int id)
        {
            var setor = _uof.SetorRepository.Get(s => s.SetorId == id);
            if (setor is null)
            {
                return NotFound();
            }
            var deletedSetor = _uof.SetorRepository.Delete(setor);
            _uof.Commit();
            var deletedSetorDeto = _mapper.Map<SetorDTO>(deletedSetor);
            return Ok(deletedSetorDeto);
        }
    }
}
