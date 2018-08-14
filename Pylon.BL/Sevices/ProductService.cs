using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;
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

        public int Add(ProductDTO product)
        {
            var prod = AutoMapper.Mapper.Map<Product>(product);
            _unitOfWork.ProductManager.Insert(prod);
            _unitOfWork.SaveChanges();
            return prod.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductManager.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public ProductDTO Get(int id)
        {
            var product =  _unitOfWork.ProductManager.GetById(id);
            return AutoMapper.Mapper.Map<ProductDTO>(product);
        }

        public void Update(ProductDTO product)
        {
           var prod =  _unitOfWork.ProductManager.GetById(product.Id);
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Fuel = product.Fuel;
            prod.Year = product.Year;
			prod.Model = product.Model;
			prod.ImageData = product.ImageData.Length == 0 ? prod.ImageData : product.ImageData;
			prod.ImageMimeType = product.ImageMimeType == null ? prod.ImageMimeType : product.ImageMimeType;
			_unitOfWork.ProductManager.Update(prod);
            _unitOfWork.SaveChanges();
        }

        public ICollection<ProductDTO> GetAll()
        {
            var list = _unitOfWork.ProductManager.Get();
            return AutoMapper.Mapper.Map<List<ProductDTO>>(list);
        }

        public ICollection<ProductDTO> GetByProfile(string id)
        {
            var list = _unitOfWork.ProductManager.Get(f => f.ProfileId == id);
            return AutoMapper.Mapper.Map<List<ProductDTO>>(list);
        }

		public ICollection<ProductDTO> GetFilter(ProductDTO product, int maxYear, decimal maxPrice)
		{
			if (product.Year < 2000)
				product.Year = 2000;
			if (maxYear == 0 || maxYear < product.Year)
				maxYear = int.MaxValue;
			if (product.Price < 0)
				product.Price = 0;
			if (maxPrice == 0 || maxPrice < product.Price)
				maxPrice = decimal.MaxValue;

			var list = _unitOfWork.ProductManager.Get(
					p => (product.Name == null ? p.Name.Length > 0 : p.Name.Contains(product.Name)) &&
				    (product.Model == null ? p.Model.Length > 0 : p.Model.Contains(product.Model)) &&
					(p.Price >= product.Price && maxPrice >= p.Price) &&
					(p.Year >= product.Year && maxYear >= p.Year));

			return AutoMapper.Mapper.Map<List<ProductDTO>>(list);
		}
	}
}
