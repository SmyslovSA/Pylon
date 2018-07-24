using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Website.Models;
using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }
        
        [HttpGet]
        public ActionResult GetAll()
        {
            var list = _productService.GetAllProducts();
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
              ProductDTO productDTO = new ProductDTO
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    PartNumber = model.PartNumber,
                    Maker = model.Maker,
                };
            var result = _productService.AddProduct(productDTO);
            return View("GetAll");
        }
    }
}