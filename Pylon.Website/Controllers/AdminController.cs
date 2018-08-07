using Pylon.BL.Interface;
using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
    {
		private readonly IAdminService _adminService;
		public AdminController(IAdminService service)
		{
			_adminService = service;
		}

        public ActionResult GetAllUsers()
        {
			var users =  _adminService.GetAll();
            return View(users);
        }

		public ActionResult AddRole(string id, string role)
		{
			_adminService.AddRole(id, role);
			return View("GetAllUsers");
		}

		public ActionResult RemoveRole(string id, string role)
		{
			_adminService.RemoveRole(id, role);
			return View("GetAllUsers");
		}
	}
}