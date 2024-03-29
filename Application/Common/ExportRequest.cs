using Application.DataTransferObjects.Project;

namespace Donysh.Models
{
    public class ExportRequest
    {
        public int Image { set; get; }
        public List<Export> request { set; get; }
    }
}
