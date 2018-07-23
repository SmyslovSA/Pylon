using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pylon.BL.Interface
{
    public interface IProductService
    {
        ProductDTO GetProduct(int id);
        int AddProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(ProductDTO product);
        List<ProductDTO> GetAllProducts();
    }
}
