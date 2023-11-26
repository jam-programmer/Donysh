using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Service
{
    public class AddServiceDto
    {
        public string? Title { set; get; }
        public string? Description { set; get; }
        public IFormFile? ImageFile { set; get; }
        public string? SmallDescription { set; get; }
    }
}
