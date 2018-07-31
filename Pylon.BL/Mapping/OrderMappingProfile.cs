using Pylon.DAL;

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
                    .ForPath(dbe => dbe.Product.Description, e => e.MapFrom(src => src.ProductDescription))
                    .ForPath(dbe => dbe.Product.Maker, e => e.MapFrom(src => src.ProductMaker))
                    .ReverseMap();
        }
    }
}
