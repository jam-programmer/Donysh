using Application.DataTransferObjects.Company;
using Application.DataTransferObjects.Company.CompanyValidator;
using Application.Services.Company;
using Donysh.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompany _company;
        private readonly Generator _generator;

        public CompanyController(ICompany company, Generator generator)
        {
            _company = company;
            _generator = generator;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            ViewBag.Base = _generator.UrlSite() + "/Company/";
            var pageModel = await _company.GetCompaniesAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCompanyDto model)
        {
            var validate = new AddCompanyValidator();
            var result = await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _company.AddCompany(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Alert = "";
            foreach (var error in result.Errors)
            {
                ViewBag.Alert += error.ErrorMessage + "\r\n";
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _company.GetCompanyById(id);
            ViewBag.Base = _generator.UrlSite() + "/Company/";
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCompanyDto model)
        {
            var validate = new UploadCompanyValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _company.UpdateCompany(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Base = _generator.UrlSite() + "/Company/";
            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Company/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _company.DeleteCompanyById(id);
            return result;
        }



        #region Trash
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
         
            ViewBag.Base = _generator.UrlSite() + "/Company/";
            var pageModel = await _company.GetTrashCompaniesAsync(page, pageSize, search);
            return View(pageModel);
        }


        [HttpGet]
        [Route("/Admin/Company/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _company.BackCompanyById(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/Company/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _company.RemoveCompanyById(id);
            return result;
        }
        #endregion

       
    }
}
