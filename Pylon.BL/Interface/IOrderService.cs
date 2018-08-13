using System.Collections.Generic;

namespace Pylon.BL.Interface
{
    public interface IOrderService : IBaseService<OrderDTO>
    {
		ICollection<OrderDTO> GetFilter(OrderDTO order);
	}
}
