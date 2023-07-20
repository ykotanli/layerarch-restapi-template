using AutoMapper;
using LayerTemplate.DataAccess.Models;
using LayerTemplate.Dto.ApiDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Person, UserProfileDto>().ReverseMap(); //altina bir satir daha yazmak yerine reversemap yazıldı.
        } 
    }
}
