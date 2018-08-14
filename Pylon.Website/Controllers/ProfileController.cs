using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Models;
using Pylon.Website.Extension;
using System.Web;
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
				Phone = model.Phone,
				ImageData = model.ImageData,
				ImageMimeType = model.ImageMimeType
			};
			return View(profile);
        }

        [HttpPost]
        public ActionResult ChangePassword(string newPassword, string newPasswordConfirm)
        {
            _profileService.ChangePassword(User.GetUserId(),newPassword, newPasswordConfirm);
            return RedirectToAction("GetInfo");
        }

        [HttpPost]
        public ActionResult GhangePersonalData(ProfileViewModel profile)
        {
			if (!ModelState.IsValid)
			{
				return View("GetInfo", profile);
			}

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

		public FileContentResult GetImage(string Id)
		{
			var user = _profileService.GetProfile(Id);
			return File(user.ImageData, user.ImageMimeType);
		}

		[HttpPost]
		public ActionResult GhangeImage(HttpPostedFileBase uploadFile)
		{
			if (uploadFile == null || !uploadFile.ContentType.Contains("image/"))
				return RedirectToAction("GetInfo");

			UserDTO userDTO = new UserDTO
			{
				Id = User.GetUserId(),
				ImageData = new byte[uploadFile.ContentLength],
				ImageMimeType = uploadFile.ContentType,
			};
			uploadFile.InputStream.Read(userDTO.ImageData, 0, uploadFile.ContentLength);
			_profileService.ChangeImage(userDTO);
			return RedirectToAction("GetInfo");
		}
	}
}