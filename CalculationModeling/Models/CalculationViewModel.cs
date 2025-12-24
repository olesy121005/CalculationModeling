using CalculationModeling.Models;

namespace CalculationModeling.Models
{
    public class CalculationViewModel
    {
        public CalculationParameters Parameters { get; set; }
        public List<CalculationResult> Results { get; set; }
    }
}
