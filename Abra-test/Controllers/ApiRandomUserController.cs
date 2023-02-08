using Abra_test.Services.ApiRandomUserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abra_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRandomUserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public ApiRandomUserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{gender}")]
        public async Task<IActionResult> GetUsersData([FromRoute] string gender)
        {
            var result = await _usersService.GetUsersData(gender);
            return Ok(result);
        }
        [HttpGet("get-mails")]
        public async Task<IActionResult> GetListOfMails()
        {
            var result = await _usersService.GetListOfMails();
            return Ok(result);
        }
        [HttpGet("get-popular-country")]
        public async Task<IActionResult> GetMostPupalarCountry()
        {
            var result = await _usersService.GetMostPupalarCountry();
            return Ok(result);
        }
        [HttpGet("get-old-user")]
        public async Task<IActionResult> GetTheOldestUser()
        {
            var result = await _usersService.GetTheOldestUser();
            return Ok(result);
        }
    }
}
