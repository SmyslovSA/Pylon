using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Website.Extension;
using Pylon.Website.Models;
using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
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
            return View(model);
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
                CompanyName = profile.CompanyName,
                Phone = profile.Phone,
                Id = User.GetUserId()
            };

            _profileService.ChangePersonalData(userDTO);
            return RedirectToAction("GetInfo");
        }
    }
}