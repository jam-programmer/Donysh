using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactEntity:BaseEntity
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Subject { set; get; }
        public string Description { set; get; }

    }
}
