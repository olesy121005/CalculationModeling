using CalculationModeling.Models;
using CalculationModeling.Models;

namespace CalculationModeling.Services
{
    public interface IHeatExchangeCalculator
    {
        List<CalculationResult> CalculateDetailed(CalculationParameters parameters);
    }
}
