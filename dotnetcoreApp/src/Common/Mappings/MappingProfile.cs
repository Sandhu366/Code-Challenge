using AutoMapper;
using Common.Dtos.Read;
using Domain;

namespace Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shout, ShoutReadDto>();
            CreateMap<Remark, RemarkReadDto>();
        }
    }
}
