using System.Collections.Generic;

namespace Pylon.BL.Interface
{
    public interface IProductService : IBaseService<ProductDTO>
    {
		ICollection<ProductDTO> GetFilter(ProductDTO product, int maxYear, decimal maxPrice);
	}
}
