using Pylon.DAL.Models;

namespace Pylon.BL.Mapping
{
    public class OrderMappingProfile : AutoMapper.Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDTO, Order>()
                    .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                    .ForMember(dbe => dbe.OrderNumber, e => e.MapFrom(src => src.OrderNumber))
                    .ForPath(dbe => dbe.Product.Id, e => e.MapFrom(src => src.ProductId))
                    .ForMember(dbe => dbe.ProfileId, e => e.MapFrom(src => src.ProfileId))
                    .ForMember(dbe => dbe.StartDate, e => e.MapFrom(src => src.StartDate))
                    .ForMember(dbe => dbe.EndDate, e => e.MapFrom(src => src.EndDate))
                    .ForPath(dbe => dbe.Product.Name, e => e.MapFrom(src => src.ProductName))
                    .ForPath(dbe => dbe.Product.Model, e => e.MapFrom(src => src.ProductModel))
                    .ForPath(dbe => dbe.Product.Price, e => e.MapFrom(src => src.ProductPrice))
					.ForPath(dbe => dbe.Product.ImageData, e => e.MapFrom(src => src.ProductImage))
					.ReverseMap();
        }
    }
}
