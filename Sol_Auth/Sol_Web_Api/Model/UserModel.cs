using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Web_Api.Model
{
    public class UserModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }

        public String UserIdentity { get; set; }

        public String Role { get; set; }

        public string Token { get; set; }
    }
}
