using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Picture
{
    public class AddPictureDto
    {
        public string? ProjectForeignKey { set; get; }
        public string? Title { set; get; }
        public string? Alt { set; get; }
        public IFormFile? File { set; get; }
    }
}
