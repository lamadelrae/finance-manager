using FinanceManager.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        JwtHelpers JwtHelpers { get; set; }

        public UsersController(IConfiguration config)
        {
            JwtHelpers = new JwtHelpers(config);
        }

        [Route("GetToken")]
        public JsonResult GetToken(string username, string password)
        {
            return new JsonResult(JwtHelpers.GenerateToken(username, password));
        }
    }
}
