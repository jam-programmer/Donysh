using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Identity.User
{
    public class SignInDto
    {
        public string? UserName { set; get; }
        public string? Password { set; get; }
        public bool SaveInfo { set; get; }
    }
}
