using Microsoft.AspNetCore.Mvc;
using NumberCheck.Interfaces;

namespace NumberCheck.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomNumberController : ControllerBase
{
    private readonly IRandomGeneratorService _randomGeneratorService;
    private readonly IUserService _userService;

    public RandomNumberController(IRandomGeneratorService randomGeneratorService,
        IUserService userService)
    {
        _randomGeneratorService = randomGeneratorService;
        _userService = userService;
    }

    [HttpGet("GetNumber")]
    public ActionResult<string> Get([FromQuery] int userNumber, [FromQuery] string userName)
    {
        if (_userService.IsUser(userName))
        {
            if (_userService.IsUserCanCheckNumber(userName))
            {
                var number = _randomGeneratorService.GetRandomNumber();

                if (userNumber > number)
                {
                    _userService.IsSaveUserAttempt(userName);
                    return BadRequest($"Your number is greater, attempted {_userService.WhichAttemptOnUser(userName)}");
                }

                if (userNumber < number)
                {
                    _userService.IsSaveUserAttempt(userName);
                    return BadRequest($"Your number is lower, attempted {_userService.WhichAttemptOnUser(userName)}");
                }

                if (number == userNumber)
                {
                    return Ok("GREAT");
                }
            }
            return "You can't check number";
        }

        return "Use login";
    }
}