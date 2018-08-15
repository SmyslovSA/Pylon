using Newtonsoft.Json;
using PagedList;
using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Models;
using Pylon.Website.Extension;
using System.Collections;
using System.Web;
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
		[Authorize(Roles = "customer, saler")]
		public ActionResult GetProduct(int id)
		{
			var productDTO = _productService.Get(id);
			ProductViewModel product = new ProductViewModel
			{
				Id = productDTO.Id,
				Name = productDTO.Name,
				CarModel = productDTO.Model,
				Fuel = productDTO.Fuel,
				Price = productDTO.Price,
				Year = productDTO.Year,
				ImageData = productDTO.ImageData,
				ImageMimeType = productDTO.ImageMimeType
			};
			return View(product);
		}

		[HttpGet]
		[Authorize(Roles = "customer, saler")]
        public ActionResult GetAll(int page = 1)
        {	
            var list = _productService.GetAll();
			var startArray = new ArrayList();
			var endArray = new ArrayList();
			var idArray = new ArrayList();
			foreach (var order in list)
			{
				foreach (var date in order.Orders)
				{
					startArray.Add(date.StartDate.ToShortDateString());
					endArray.Add(date.EndDate.ToShortDateString());
					idArray.Add(date.ProductId);
				}
			}
			string startData = JsonConvert.SerializeObject(startArray, Formatting.None);
			string endData = JsonConvert.SerializeObject(endArray, Formatting.None);
			string idData = JsonConvert.SerializeObject(idArray, Formatting.None);
			ViewBag.StartData = new HtmlString(startData);
			ViewBag.EndData = new HtmlString(endData);
			ViewBag.IdData = new HtmlString(idData);
			return View(list.ToPagedList(page,5));
        }

		[HttpPost]
		[Authorize(Roles = "customer, saler")]
		public ActionResult GetFilter(ProductFilterModel model)
		{
			if (model == null)
			{
				return RedirectToAction("GetAll");
			}
			ProductDTO product = new ProductDTO
			{
				Name = model.Name,
				Year = model.MinYear,
				Price = model.MinPrice,
				Model = model.CarModel,
				Fuel = model.Fuel
			};
			var list = _productService.GetFilter(product,model.MaxYear,model.MaxPrice);
			return View("GetAll",list.ToPagedList(1,5));
		}

		[HttpGet]
		[Authorize(Roles = "saler")]
		public ActionResult GetSalerProducts(int page = 1)
        {
			var list = _productService.GetByProfile(User.GetUserId());
            return View(list.ToPagedList(page,5));
        }

		[HttpGet]
		[Authorize(Roles = "saler")]
		public ActionResult AddProduct()
        {
            return View();
        }

		[HttpPost]
		[Authorize(Roles = "saler")]
		public RedirectToRouteResult AddProduct(ProductViewModel model, HttpPostedFileBase uploadFile)
        {
			ProductDTO productDTO = new ProductDTO
			{
				Name = model.Name,
				Price = model.Price,
				Model = model.CarModel,
				Fuel = model.Fuel,
				Year = model.Year,
				ImageData = uploadFile==null ? new byte[0] : new byte[uploadFile.ContentLength],
				ImageMimeType = uploadFile == null ? null : uploadFile.ContentType,
                ProfileID = User.GetUserId()
                };
			if(uploadFile != null && uploadFile.ContentType.Contains("image/"))
				uploadFile.InputStream.Read(productDTO.ImageData, 0, uploadFile.ContentLength);
            _productService.Add(productDTO);
            return RedirectToAction("GetAll");
        }

		[Authorize(Roles = "saler")]
		public RedirectToRouteResult UpdateProduct(ProductViewModel model, HttpPostedFileBase uploadFile)
		{
			ProductDTO productDTO = new ProductDTO
			{
				Name = model.Name,
				Price = model.Price,
				Model = model.CarModel,
				Fuel = model.Fuel,
				Year = model.Year,
				ImageData = uploadFile == null ? new byte[0] : new byte[uploadFile.ContentLength],
				ImageMimeType = uploadFile == null ? null : uploadFile.ContentType,
				Id = model.Id
			};
			if (uploadFile != null && uploadFile.ContentType.Contains("image/"))
				uploadFile.InputStream.Read(productDTO.ImageData, 0, uploadFile.ContentLength);
			_productService.Update(productDTO);
			return RedirectToAction("GetAll");
		}

		[Authorize(Roles = "saler")]
		public RedirectToRouteResult RemoveProduct(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("GetAll");
        }

		public FileContentResult GetImage(int Id)
		{
			var prod = _productService.Get(Id);
			return File(prod.ImageData, prod.ImageMimeType);
		}
	}
}