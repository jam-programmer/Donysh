using Application.Services.Ui;
using iText;
using iText.Html2pdf;
using Microsoft.AspNetCore.Mvc;

namespace Donysh.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUserInterface _userInterface;

        public ProjectController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        public async Task<IActionResult> Projects(int page=1)
        {
            var pageModel = await _userInterface.GetListProject(page);
            return View(pageModel);
        }


        public async Task<IActionResult> ProjectDetail(string projectId)
        {
            var pageModel = await _userInterface.GetProjectById(projectId);
            return View(pageModel);
        }

      
   
        public async Task<IActionResult> GeneratePdf(string projectId)
        {
            var options = await _userInterface.ProjectPdfOption(projectId);
          
            using (var writer = new FileStream(options.FilePath!, FileMode.Create))
            {
                ConverterProperties properties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(options.Content, writer, properties);
            }

            return File(Path.Combine("PDF", options.File!), "application/pdf", options.File!);
        }

    
    }
}
