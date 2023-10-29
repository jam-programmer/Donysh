using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class ScopeWorkEntity:BaseEntity
    {
        public string? Title { set; get; }
        public List<ProjectEntity>? Projects { set; get; }   
    }
}
