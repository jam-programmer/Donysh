using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Service
{
    public class UpdateServiceDto
    {
        public string? Id { set; get; }
        public string? Title { set; get; }
        public string? Description { set; get; }
        public IFormFile? ImageFile { set; get; }
        public string? Image { set; get; }
        public string? SmallDescription { set; get; }
    }
}
