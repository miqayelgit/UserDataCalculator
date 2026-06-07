

using UserDataCalculator.Application.Contracts;
using UserDataCalculator.Application.DTOs;
using UserDataCalculator.Application.Enums;

namespace UserDataCalculator.Application.Services.Calculations;

public class UserDataCalculation : IUserDataCalculation
{
    public CalculationResultsDto CalculateUserDailyCalorieLimitsAsync(CalculateUserDataDto dto)
    {
        var decisive = dto.Gender == Gender.Male ? 5 : -161; //add enum

        var BMR = 10 * dto.Weight + 6.25 * dto.Height - 5 * dto.Age + decisive + dto.AdditionalCalories;

        var dailyCalorieLimit = (short)(BMR * dto.ActivityLevelRate);
        short dailyProteinAmount = (short)(dailyCalorieLimit * dto.ProteinPercent / 100 / 4);
        short dailyFatAmount = (short)(dailyCalorieLimit * dto.FatPercent / 100 / 9);
        short dailyCarbsAmount = (short)(dailyCalorieLimit * dto.CarbsPercent / 100 / 4);

        return new CalculationResultsDto
        {
            DailyCalorieLimit = dailyCalorieLimit,
            DailyProteinAmount = dailyProteinAmount,
            DailyFatAmount = dailyFatAmount,
            DailyCarbsAmount = dailyCarbsAmount
        };
    }

    //    public async Task CalculateFoodIntake(UserIntakeRecordDto dto)
    //    {
    //        var product = await _unitOfWork.ProductRepository.FirstOrDefaultAsync(x => x.Id == dto.ProductId);
    //        var calorieLimits = await _unitOfWork.DailyCalorieLimitRepository.FirstOrDefaultAsync(x => x.UserId == _userId);
    //        var nutrientsLimits = await _unitOfWork.DailyNutrientsIntakeAmountRepository.FirstOrDefaultAsync(x => x.UserId == _userId);

    //        if (product == null || calorieLimits == null || nutrientsLimits == null)
    //        {
    //            throw new ApplicationNotFoundException("Product or Daily limit or Nutirent limits Not Found");
    //        }

    //        float foodUnit = dto.FoodAmountInGrams / 100;

    //        nutrientsLimits.Protein = (short)(nutrientsLimits.Protein - foodUnit * product.ProteinPerHundredGram);
    //        nutrientsLimits.Fat = (short)(nutrientsLimits.Fat - foodUnit * product.FatPerHundredGram);
    //        nutrientsLimits.Carbs = (short)(nutrientsLimits.Carbs - foodUnit * product.CarbsPerHundredGram);
    //        nutrientsLimits.UpdatedAt = DateTime.UtcNow;


    //        var usedLimit = (short)(foodUnit * product.CaloriesPerHundredGram + calorieLimits.UsedLimit);
    //        calorieLimits.UsedLimit = usedLimit;
    //        calorieLimits.RemainingLimit = (short)(calorieLimits.DailyLimit - usedLimit);
    //        calorieLimits.UpdatedAt = DateTime.UtcNow;

    //        _unitOfWork.DailyNutrientsIntakeAmountRepository.Update(nutrientsLimits);
    //        _unitOfWork.DailyCalorieLimitRepository.Update(calorieLimits);
    //    }
}
