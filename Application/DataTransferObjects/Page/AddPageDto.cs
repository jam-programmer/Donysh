using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Page
{
    public class AddPageDto
    {
        public IFormFile BannerFile { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public TabLocation Location { set; get; }
    }
}
