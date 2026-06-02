namespace UserDataCalculator.Application.DTOs;

public class CalculateUserDataDto
{
    public short Height { get; set; }
    public short Weight { get; set; }
    public byte Age { get; set; }
    public string Gender { get; set; } = null!;
    public byte ProteinPercent { get; set; }
    public byte FatPercent { get; set; }
    public byte CarbsPercent { get; set; }
    public short AdditionalCalories { get; set; }
    public float ActivityLevelRate { get; set; }

}
