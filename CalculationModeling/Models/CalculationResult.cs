namespace CalculationModeling.Models
{
    public class CalculationResult
    {
        public int Id { get; set; } // ← без ручной генерации

        public int ParametersId { get; set; }
        public CalculationParameters Parameters { get; set; }

        public double CoordinateY { get; set; }
        public double RelativeHeight { get; set; }
        public double Theta1 { get; set; }
        public double Theta2 { get; set; }
        public double MaterialTemp { get; set; }
        public double GasTemp { get; set; }
        public double TempDifference { get; set; }
    }
}
