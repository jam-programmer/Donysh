using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Setting
{
    public class AboutDto
    {
        public string? Banner { set; get; }
        public IFormFile File { set; get; }
        public string? Description { set; get; }
        public string? Id { set; get; }
    }
}
