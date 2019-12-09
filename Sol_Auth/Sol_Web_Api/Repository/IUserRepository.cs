
using Sol_Web_Api.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Web_Api.Repository
{
    public interface IUserRepository
    {
         Task<dynamic> LoginAsync(UserModel userModel);
        
    }
}
