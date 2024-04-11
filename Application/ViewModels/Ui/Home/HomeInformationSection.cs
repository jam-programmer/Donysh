using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Ui.Home
{
    public class HomeInformationSection
    {
        public string Longitude { set; get; }
        public string Latitude { set; get; }
        public string? Email { set; get; }
        public string? PhoneNumber { set; get; }
        public string? Address { set; get; }
    }
}
