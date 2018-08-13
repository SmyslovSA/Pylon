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
			if(id == null || role == string.Empty)
				return RedirectToAction("GetAllUsers");
			_adminService.AddRole(id, role);
			return RedirectToAction("GetAllUsers");
		}

		public ActionResult RemoveRole(string id, string role)
		{
			if (id == null || role == string.Empty)
				return RedirectToAction("GetAllUsers");
			_adminService.RemoveRole(id, role);
			return RedirectToAction("GetAllUsers");
		}

		public ActionResult BlockUser(string id)
		{
			_adminService.BlockUser(id);
			return RedirectToAction("GetAllUsers");
		}

		public ActionResult UnblockUser(string id)
		{
			_adminService.UnBlockUser(id);
			return RedirectToAction("GetAllUsers");
		}

		public ActionResult DeleteUser(string id)
		{
			_adminService.DeleteUser(id);
			return RedirectToAction("GetAllUsers");
		}
	}
}