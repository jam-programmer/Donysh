using Application.Services.Request;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestController : Controller
    {
        private readonly IRequest _request;

        public RequestController(IRequest request)
        {
            _request = request;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _request.GetRequestAsync(page, pageSize, search);
            return View(pageModel);
        }





        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var pageModel = await _request.GetById(id);
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Request/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _request.RemoveById(id);
            return result;
        }
    }
}
