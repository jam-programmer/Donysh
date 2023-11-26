using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;

namespace Domain.Entities
{
    public class PageEntity:BaseEntity
    {
        public string Title { set; get; }
        public string Body { set; get; }
        public TabLocation Location { set; get; }
    }
}
