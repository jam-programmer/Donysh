using Domain.Enum;
using Microsoft.AspNetCore.Http;


namespace Application.DataTransferObjects.Page
{
    public class UpdatePageDto
    {
        public string Banner { set; get; }
        public IFormFile BannerFile { set; get; }
        public string Id { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public TabLocation Location { set; get; }
    }

}
