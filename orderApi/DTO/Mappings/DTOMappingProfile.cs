using AutoMapper;
using orderApi.Model;

namespace orderApi.DTO.Mappings
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Chamado, ChamadoDTO>().ReverseMap();
            CreateMap<Setor, SetorDTO>().ReverseMap();
        }
    }
}
