using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObjects.Team
{
    public class UpdateTeamDto
    {
        public string? Id { set; get; }
        public string? FullName { set; get; }
        public string? AvatarPath { set; get; }
        public IFormFile? Avatar { set; get; }
        public string? JobTitle { set; get; }
    }
}
