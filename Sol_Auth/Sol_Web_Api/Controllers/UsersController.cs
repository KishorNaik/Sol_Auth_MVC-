using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sol_Web_Api.Model;
using Sol_Web_Api.Repository;

namespace Sol_Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository = null;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [AllowAnonymous]
        [HttpPost("loginasync")]
        public async Task<IActionResult> LoginAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return base.BadRequest();
            else
            {
                var data = await userRepository?.LoginAsync(userModel);

                return base.Ok((Object)data);
            }
        }

        [Authorize(Roles ="Users")]
        [HttpPost("testapi")]
        public IActionResult TestApi()
        {
            return base.Ok((Object)true);
        }


    }
}