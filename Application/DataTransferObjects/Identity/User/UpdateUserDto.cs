using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Identity.User
{
    public class UpdateUserDto
    {
        public string?Id { set; get; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { set; get; }
        public bool Active { set; get; }
        public string? Password { get; set; }
        public string? PasswordConfirmed { get; set; }
        public List<string>? Role { set; get; }
    }
}
