using Pylon.BL.Interface;
using Pylon.DAL;
using Pylon.DAL.Interface;
using System.Collections.Generic;

namespace Pylon.BL.Sevices
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddProduct(ProductDTO product)
        {
            var prod = AutoMapper.Mapper.Map<Product>(product);
            _unitOfWork.ProductManager.Insert(prod);
            _unitOfWork.SaveChanges();
            return prod.Id;
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.ProductManager.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public ProductDTO GetProduct(int id)
        {
            var product =  _unitOfWork.ProductManager.GetById(id);
            return AutoMapper.Mapper.Map<ProductDTO>(product);
        }

        public void UpdateProduct(ProductDTO product)
        {
           var prod =  _unitOfWork.ProductManager.GetById(product.Id);
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Maker = product.Maker;
            prod.PartNumber = product.PartNumber;
            _unitOfWork.ProductManager.Update(prod);
            _unitOfWork.SaveChanges();
        }

        public ICollection<ProductDTO> GetAllProducts()
        {
            var list = _unitOfWork.ProductManager.Get();
            return AutoMapper.Mapper.Map<List<ProductDTO>>(list);
        }

        public ICollection<ProductDTO> GetProducts(string id)
        {
            var list = _unitOfWork.ProductManager.Get(f => f.ProfileId == id);
            return AutoMapper.Mapper.Map<List<ProductDTO>>(list);
        }
    }
}
