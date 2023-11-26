using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Contact
{
    public class ContactDetail
    {
        public DateTimeOffset CreateTime { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Subject { set; get; }
        public string Description { set; get; }
    }
}
