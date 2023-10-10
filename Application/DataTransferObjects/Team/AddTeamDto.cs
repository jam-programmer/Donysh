using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Team
{
    public class AddTeamDto
    {
        public string? FullName { set; get; }
        public IFormFile? AvatarFile { set; get; }
        public string? JobTitle { set; get; }
    }
}
