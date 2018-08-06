using Pylon.DAL.Models;

namespace Pylon.BL.Mapping
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                .ForMember(dbe => dbe.Name, e => e.MapFrom(src => src.Name))
                .ForMember(dbe => dbe.Model, e => e.MapFrom(src => src.Model))
                .ForMember(dbe => dbe.Fuel, e => e.MapFrom(src => src.Fuel))
                .ForMember(dbe => dbe.Year, e => e.MapFrom(src => src.Year))
                .ForMember(dbe => dbe.Price, e => e.MapFrom(src => src.Price))
                .ForMember(dbe => dbe.ProfileId, e => e.MapFrom(src => src.ProfileID))
				.ForMember(dbe => dbe.ImageMimeType, e => e.MapFrom(src => src.ImageMimeType))
				.ForMember(dbe => dbe.ImageData, e => e.MapFrom(src => src.ImageData))
				.ReverseMap();
        }
    }
}
