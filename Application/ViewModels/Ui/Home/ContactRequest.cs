using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Home
{
    public class ContactRequest
    {
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Subject { set; get; }
        public string Description { set; get; }
    }
}
