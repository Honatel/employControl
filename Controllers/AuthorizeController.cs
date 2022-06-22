using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employesControl_V2.Models;
using employesControl_V2.Services;
using employesControl_V2.Services.interfaces;
using employesControl_V2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace employesControl_V2.Controllers
{
    [ApiController]
    [Route("/token")]
    public class AuthorizeController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuthVM authUser)
        {
            var userIsValid = await _userService.UserIsValid(authUser.UserName, authUser.Password);
            if (!userIsValid) return Unauthorized("Usuario ou senha inválidos");

            var validUser = await _userService.FindByUserName(authUser.UserName);

            var token = TokenService.GenerateToken(validUser);

            return Ok(new
            {
                user = authUser.UserName,
                token = token
            });
        }
    }
}