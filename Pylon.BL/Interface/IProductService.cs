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
        List<ProductDTO> GetProducts(string id);
        int AddProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(int id);
        List<ProductDTO> GetAllProducts();
    }
}
