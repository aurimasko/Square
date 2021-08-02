using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Square
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Point, DTO.PointDTO>();
            CreateMap<DTO.PointDTO, Models.Point>();

            CreateMap<Models.List, DTO.ListDTO>();
            CreateMap<DTO.ListDTO, Models.List>();
        }
    }
}
