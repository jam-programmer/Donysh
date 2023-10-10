using Application.DataTransferObjects.Category;
using Application.DataTransferObjects.Category.CategoryValidator;
using Application.Services.Category;

using Microsoft.AspNetCore.Mvc;

namespace Donysh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategory _category;


        public CategoryController(ICategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _category.GetCategoriesAsync(page, pageSize, search);
            return View(pageModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddCategoryDto model)
        {
            var validate = new AddCategoryValidator();
            var results = validate.Validate(model);
            if (results.IsValid)
            {
                _category.AddCategory(model);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var pageModel = await _category.GetCategoryById(id);
            if (pageModel == null)
            {
                return Redirect("/404");
            }

            return View(pageModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDto model)
        {
            var validate = new UpdateCategoryValidator();
            var results = await validate.ValidateAsync(model);
            if (results.IsValid)
            {
                await _category.UpdateCategoryAsync(model);
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in results.Errors)
            {
                ViewBag.Alert = error.ErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Category/Delete/{id}")]
        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _category.DeleteCategoryAsync(id);
            return result;
        }



        #region Trash
        public async Task<IActionResult> Trash(int page = 1, int pageSize = 10, string search = "")
        {
            var pageModel = await _category.GetTrashCategoriesAsync(page, pageSize, search);
            return View(pageModel);
        }


        [HttpGet]
        [Route("/Admin/Category/Back/{id}")]
        public async Task<bool> Back(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _category.BackCategoryAsync(id);
            return result;
        }

        [HttpGet]
        [Route("/Admin/Category/Remove/{id}")]
        public async Task<bool> Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            var result = await _category.RemoveCategoryAsync(id);
            return result;
        }


        #endregion
    }

}
