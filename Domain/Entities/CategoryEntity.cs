using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class CategoryEntity:BaseEntity
    {
        public string? Title { set; get; }
    }
}
