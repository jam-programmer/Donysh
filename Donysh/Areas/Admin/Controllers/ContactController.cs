using Application.Services.Contact;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContact _contact;

        public ContactController(IContact contact)
        {
            _contact = contact;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _contact.GetContactAsync(page, pageSize, search);
            return View(pageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var pageModel = await _contact.GetById(id);
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Contact/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var result = await _contact.RemoveById(id);
            return result;
        }

    }
}

