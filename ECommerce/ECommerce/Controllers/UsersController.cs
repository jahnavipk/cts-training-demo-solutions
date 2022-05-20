using ECommerce.Interfaces;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jwtManagerRepo;

        public UsersController(IJWTManagerRepository jwtManagerRepo)
        {
            _jwtManagerRepo = jwtManagerRepo;
        }

        [HttpGet]
        public List<string> Get()
        {
            var users = new List<string> { "Ankit", "Dinesh", "Phani" };
            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users userdata)
        {
            var token = _jwtManagerRepo.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
