using Pylon.BL.ModelsDTO;
using Pylon.DAL.Models;

namespace Pylon.BL.Mapping
{
	public class DatesMappingProfile : AutoMapper.Profile
	{
		public DatesMappingProfile()
		{
			CreateMap<DateDTO, Order>()
				   .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
				   .ForPath(dbe => dbe.Product.Id, e => e.MapFrom(src => src.ProductId))
				   .ForMember(dbe => dbe.StartDate, e => e.MapFrom(src => src.StartDate))
				   .ForMember(dbe => dbe.EndDate, e => e.MapFrom(src => src.EndDate))
				   .ReverseMap();
		}
	}
}
