using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Sol_Web_Api.Model;

namespace Sol_Web_Api.Repository
{
    public class UserRepository : IUserRepository
    {
        async Task<dynamic> IUserRepository.LoginAsync(UserModel userModel)
        {
            dynamic data = null;
            try
            {
                return await Task.Run(() => {

                    // valid User Name and Password in server.

                    userModel.UserName = "kishor11";
                    userModel.UserIdentity = "abe472da-73f3-48ac-a1a9-cbd90de9648f";
                    userModel.Role = "Users";

                    // if it is Valid
                    if (userModel != null)
                    {
                        // authentication successful so generate jwt token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(AppSetting.Secret);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.Name, userModel.UserIdentity),
                                new Claim(ClaimTypes.Role,userModel.Role)
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        userModel.Token = tokenHandler.WriteToken(token);

                        userModel.Password = null;

                        data = userModel;
                    }
                    else
                    {
                        data = new { ErrorMessage = "User Name and Password does not match" };
                    }

                    return data;

                });
            }
            catch
            {
                throw;
            }
        }
    }
}
