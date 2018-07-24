using Pylon.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylon.BL.Mapping
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                .ForMember(dbe => dbe.Name, e => e.MapFrom(src => src.Name))
                .ForMember(dbe => dbe.Image, e => e.MapFrom(src => src.Image))
                .ForMember(dbe => dbe.Maker, e => e.MapFrom(src => src.Maker))
                .ForMember(dbe => dbe.PartNumber, e => e.MapFrom(src => src.PartNumber))
                .ForMember(dbe => dbe.Price, e => e.MapFrom(src => src.Price))
                .ReverseMap();
        }
    }
}
