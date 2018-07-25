using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Website.Extension;
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
            return View(list);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddProduct(ProductViewModel model)
        {
            ProductDTO productDTO = new ProductDTO
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                PartNumber = model.PartNumber,
                Maker = model.Maker,
                ProfileID = User.GetUserId()
                };
            _productService.AddProduct(productDTO);
            return RedirectToAction("GetAll");
        }

        public RedirectToRouteResult RemoveProduct(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("GetAll");
        }
    }
}