
using Microsoft.AspNetCore.Mvc;
using UserDataCalculator.Application.Contracts;
using UserDataCalculator.Application.DTOs;

namespace UserDataCalculator.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateUserDataController : ControllerBase
{
    private readonly IUserDataCalculation _userDataCalculator;
    public CalculateUserDataController(IUserDataCalculation userDataCalculator)
    {
        _userDataCalculator = userDataCalculator;
    }
    [HttpPost]
    public async Task<IActionResult> GetCalculationResult([FromBody] CalculateUserDataDto dto)
    {
        var res = _userDataCalculator.CalculateUserDailyCalorieLimitsAsync(dto);

        return Ok(res);
    }
}
