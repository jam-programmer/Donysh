using Application.DataTransferObjects.Team.TeamValidator;
using Application.DataTransferObjects.Team;
using Application.Services.EmploymentAdvertisement;
using Microsoft.AspNetCore.Mvc;
using Application.DataTransferObjects.EmploymentAdvertisement;
using Application.DataTransferObjects.EmploymentAdvertisement.EmploymentAdvertisementValidator;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmploymentAdvertisementController : Controller
    {
        private readonly IEmploymentAdvertisement _employmentAdvertisement;

        public EmploymentAdvertisementController(IEmploymentAdvertisement employmentAdvertisement)
        {
            _employmentAdvertisement = employmentAdvertisement;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
         
            var pageModel = await _employmentAdvertisement.GetEmploymentAdvertisementsAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEmploymentAdvertisementDto model)
        {
            var validator = new AddEmploymentAdvertisementValidator();
            var result = await validator.ValidateAsync(model);
            if (result.IsValid)
            {
                await _employmentAdvertisement.AddEmploymentAdvertisement(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\n";
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _employmentAdvertisement.GetEmploymentAdvertisementById(id);
            if (pageModel == null)
            {

            }
         
            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmploymentAdvertisementDto model)
        {
            var validate = new UpdateEmploymentAdvertisementValidator();
            var result = await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _employmentAdvertisement.UpdateEmploymentAdvertisementAsync(model);
                return RedirectToAction(nameof(Index));
            }
         
            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\r\n";
            }
            return View(model);
        }



        #region Trash
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
         
            var pageModel = await _employmentAdvertisement.GetTrashEmploymentAdvertisementsAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/EmploymentAdvertisement/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            var result = await _employmentAdvertisement.DeleteEmploymentAdvertisementAsync(id);
            return result;
        }
        [HttpGet]
        [Route("/Admin/EmploymentAdvertisement/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            var result = await _employmentAdvertisement.BackEmploymentAdvertisementAsync(id);
            return result;
        }
        [HttpGet]
        [Route("/Admin/EmploymentAdvertisement/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            var result = await _employmentAdvertisement.RemoveEmploymentAdvertisementAsync(id);
            return result;
        }
        #endregion
    }
}
