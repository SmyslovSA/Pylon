using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Models;
using Pylon.Website.Extension;
using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
	[Authorize]
    public class ProfileController : Controller
    {
        private IProfileService _profileService;

        public ProfileController(IProfileService service)
        {
            _profileService = service;
        }

        [HttpGet]
        public ActionResult GetInfo()
        {
            var model = _profileService.GetProfile(User.GetUserId());
			ProfileViewModel profile = new ProfileViewModel
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Phone = model.Phone
			};
            return View(profile);
        }

        [HttpPost]
        public RedirectToRouteResult GhangePassword(string newPassword, string newPasswordConfirm)
        {
            //TODO: null validate
            _profileService.ChangePassword(User.GetUserId(),newPassword, newPasswordConfirm);
            return RedirectToAction("GetInfo");
        }

        [HttpPost]
        public RedirectToRouteResult GhangePersonalData(ProfileViewModel profile)
        {
            //TODO: redirect to InvalidInformationView 
            UserDTO userDTO = new UserDTO
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Phone = profile.Phone,
                Id = User.GetUserId()
            };

            _profileService.ChangePersonalData(userDTO);
            return RedirectToAction("GetInfo");
        }
    }
}