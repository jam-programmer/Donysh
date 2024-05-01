using Donysh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.DataTransferObjects.EmploymentAdvertisement;
using Application.DataTransferObjects.Feedback;
using Application.Services.Company;
using Application.Services.EmploymentAdvertisement;
using Application.Services.Feedback;
using Application.Services.Service;
using Application.Services.Team;
using Application.Services.Ui;
using Application.ViewModels.Ui.Home;

namespace Donysh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInterface _userInterface;
        private readonly IService _service;
        private readonly ICompany _company;
        private readonly IFeedback _feedback;

        private readonly ITeam _team;

        private readonly IEmploymentAdvertisement _employment;

        public HomeController(ILogger<HomeController> logger, IUserInterface userInterface, IService service, ICompany company, IFeedback feedback, ITeam team, IEmploymentAdvertisement employment)
        {
            _logger = logger;
            _userInterface = userInterface;
            _service = service;
            _company = company;
            _feedback = feedback;
            _team = team;
            _employment = employment;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var pageModel = await _userInterface.GetHomeTopSection();
            return View(pageModel);
        }


        public async Task<IActionResult> About()
        {
            var pageModel = await _userInterface.GetAboutPage();
            return View(pageModel);
        }
        [Route("/Page/{title}")]
        public async Task<IActionResult> Page(string page,string title)
        {
            var pageModel = await _userInterface.GetPage(page);
            if (pageModel == null)
            {
                return Redirect("/");
            }
            return View(pageModel);
        }


        public async Task<IActionResult> WorkingWith()
        {
            var model = await _company.GetAllAsync();
            return View(model);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Request()
        {
            var services= await _service.GetServiceItemAsync();
            ViewBag.Services = services;
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> ReceiveRequestInfo([FromBody] RequestInfo request)
        {
            var result = await _userInterface.AddRequest(request);

            return Json(result);
        }

        public async Task<IActionResult> Contactus()
        {
            var pageModel = await _userInterface.GetHomeInformationSection();
            return View(pageModel);
        }



        [HttpPost]
        public async Task<JsonResult> ContactRequest([FromBody] RequestContact request)
        {
            var result = await _userInterface.AddContactRequest(request);

            return Json(result);
        }
        [HttpPost]
        [Route("/RequestFeedback")]
        public async Task<JsonResult> FeedbackRequest([FromForm] AddFeedbackDto request)
        {
             await _feedback.AddAsync(request);
            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> MemberInformation( string id)
        {
            var model = await _team.GetMemberInformationByIdAsync(id);
            return View(model);
        }
        [Route("/Home/ToCarriers")]
        public async Task<IActionResult> Employments()
        {
            var pageModel = await _userInterface.GetEmployments();
            return View("Carriers", pageModel);
        }
        [Route("/Home/CarrierDetail")]
        public async Task<IActionResult> EmploymentDetail(string id)
        {
            var pageModel = await _userInterface.GetEmploymentById(id);
            return View("CarrierDetail", pageModel);
        }
        [HttpPost]
        [Route("/RequestCV")]
        public async Task<JsonResult> ResumeRequest([FromForm] AddResumeDto request)
        {
            await _employment.AddResumeAsync(request);
            return Json(true);
        }

    }
}