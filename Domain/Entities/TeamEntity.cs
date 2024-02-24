using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class TeamEntity:BaseEntity
    {
        public string? FullName { set; get; }
        public string? AvatarPath { set; get; }
        public string? JobTitle { set; get; }
        public string? Description { set; get;}
    }
}
