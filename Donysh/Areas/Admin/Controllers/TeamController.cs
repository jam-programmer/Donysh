using Application.DataTransferObjects.Team;
using Application.DataTransferObjects.Team.TeamValidator;
using Application.Services.Team;
using Donysh.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeam _team;
        private readonly Generator _generator;

        public TeamController(ITeam team, Generator generator)
        {
            _team = team;
            _generator = generator;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            ViewBag.Base = _generator.UrlSite() + "/Team/";
            var pageModel = await _team.GetTeamsAsync(page, pageSize, search);
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTeamDto model)
        {
            var validator = new AddTeamValidator();
            var result = await validator.ValidateAsync(model);
            if (result.IsValid)
            {
                await _team.AddTeam(model);
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
            var pageModel = await _team.GetTeamById(id);
            if (pageModel==null)
            {

            }
            ViewBag.Base = _generator.UrlSite() + "/Team/";
            return View(pageModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTeamDto model)
        {
            var validate = new UpdateTeamValidator();
            var result= await validate.ValidateAsync(model);
            if (result.IsValid)
            {
                await _team.UpdateTeamAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Base = _generator.UrlSite() + "/Team/";
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
            ViewBag.Base = _generator.UrlSite() + "/Team/";
            var pageModel = await _team.GetTrashTeamsAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Team/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            var result = await _team.DeleteTeamAsync(id);
            return result;
        }
        [HttpGet]
        [Route("/Admin/Team/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            var result = await _team.BackTeamAsync(id);
            return result;
        }
        [HttpGet]
        [Route("/Admin/Team/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            var result = await _team.RemoveTeamAsync(id);
            return result;
        }
        #endregion
    }
}
