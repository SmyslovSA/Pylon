using Pylon.DAL;

namespace Pylon.BL.Mapping
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                .ForMember(dbe => dbe.Name, e => e.MapFrom(src => src.Name))
                //.ForMember(dbe => dbe.Image, e => e.MapFrom(src => src.Image))
                .ForMember(dbe => dbe.Maker, e => e.MapFrom(src => src.Maker))
                .ForMember(dbe => dbe.PartNumber, e => e.MapFrom(src => src.PartNumber))
                .ForMember(dbe => dbe.Price, e => e.MapFrom(src => src.Price))
                .ForMember(dbe => dbe.ProfileId, e => e.MapFrom(src => src.ProfileID))
                .ReverseMap();
        }
    }
}
