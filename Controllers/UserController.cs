using Microsoft.AspNetCore.Mvc;
using NumberCheck.Interfaces;

namespace NumberCheck.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult AuthorizeUser([FromQuery] string userName)
    {
        if (_userService.IsUser(userName))
        {
            return Ok(userName);
        }

        if (_userService.SaveUserName(userName))
        {
            return Ok("Success");
        }

        return BadRequest(userName);
    }
}