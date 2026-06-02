
using UserDataCalculator.Application.DTOs;

namespace UserDataCalculator.Application.Contracts;

public interface IUserDataCalculation
{
    CalculationResultsDto CalculateUserDailyCalorieLimitsAsync(CalculateUserDataDto dto);
}
